using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
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


        }

        [Fact]
        public void GetBook()
        {
          
            //Que metodo dentro de mi microservice libro se esta encargando
            //de realizar la consulta dellibros de la Bd ??
            //1.Emular  a la instancia de entity framework core - LibraryContext 
            //para emular las acciones y eventos de un objeto en un ambiente de unit test
            //utilizamos objetos de tipo mock
            var mockContext = new Mock<LibraryContext>();
            //2.emular al mapping IMapper
            var mockMapper = new Mock<IMapper>();
            //3. Instanciar a la clase Handler y pasarle como parametros los mocks que he creado 
            Query.Handler handler = new Query.Handler(mockContext.Object, mockMapper.Object);

        }
    }
}
