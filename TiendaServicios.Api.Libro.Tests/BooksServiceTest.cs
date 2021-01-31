using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TiendaServicios.Api.Libro.Aplication;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;
using Xunit;
namespace TiendaServicios.Api.Libro.Tests
{
    
    public class BooksServiceTest
    {
        private IEnumerable<LibraryMaterials> GetTestData()
        {
            A.Configure<LibraryMaterials>()
                .Fill(x => x.Title).AsArticleTitle()
                .Fill(x => x.LibraryMaterialId);
            var list = A.ListOf<LibraryMaterials>(30);
            list[0].LibraryMaterialId = 0;
            return list;
        }
        private Mock<LibraryContext> CreateContext()
        {
            var testData = GetTestData().AsQueryable();

            var dbSet = new Mock<DbSet<LibraryMaterials>>();
            dbSet.As<IQueryable<LibraryMaterials>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbSet.As<IQueryable<LibraryMaterials>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbSet.As<IQueryable<LibraryMaterials>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbSet.As<IQueryable<LibraryMaterials>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbSet.As<IAsyncEnumerable<LibraryMaterials>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
            .Returns(new AsyncEnumerator<LibraryMaterials>(testData.GetEnumerator()));

            dbSet.As<IQueryable<LibraryMaterials>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<LibraryMaterials>(testData.Provider));
            
            var context = new Mock<LibraryContext>();
            context.Setup(x => x.LibraryMaterials).Returns(dbSet.Object);
            return context;
        }

        [Fact]
        public async void GetBookById()
        {
            var mockContext = CreateContext();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });
            var mapper = mapConfig.CreateMapper();
            var request = new FilterQuery.UnicBook();
            request.BookId = 0;

            var handler = new FilterQuery.Handler(mockContext.Object, mapper);

           var book = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.NotNull(book);
            Assert.True(book.LibraryMaterialId == 0);
        }

        [Fact]
        public async void GetBook()
        {
            System.Diagnostics.Debugger.Launch();
            //Que metodo dentro de mi microservice libro se esta encargando
            //de realizar la consulta dellibros de la Bd ??
            //1.Emular  a la instancia de entity framework core - LibraryContext 
            //para emular las acciones y eventos de un objeto en un ambiente de unit test
            //utilizamos objetos de tipo mock
            var mockContext = CreateContext();
            //2.emular al mapping IMapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();
            //3. Instanciar a la clase Handler y pasarle como parametros los mocks que he creado 
            Query.Handler handler = new Query.Handler(mockContext.Object, mapper);
            Query.Execute request = new Query.Execute();
            var list = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(list.Any());

        }

        [Fact]
        public async void BookInsert()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "DataBaseBook")
                .Options;
            var context = new LibraryContext(options);

            var request = new New.Execute();
            request.Title = "Libro de Microservicios";
            request.BookAuthor = Guid.Empty;
            request.DatePublication = DateTime.Now;

            var handler = new New.Handler(context);

           var book = await handler.Handle(request, new System.Threading.CancellationToken());
            Assert.True(book != null);
        }
    }
}
