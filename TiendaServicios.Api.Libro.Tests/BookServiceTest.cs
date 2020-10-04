using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Application;
using TiendaServicios.Api.Libro.Model;
using TiendaServicios.Api.Libro.Persistence;
using Xunit;

namespace TiendaServicios.Api.Libro.Tests
{
    public class BookServiceTest
    {

        private IEnumerable<Book> GetTestData()
        {
            A.Configure<Book>()
                .Fill(x => x.Title)
                .AsArticleTitle()
                .Fill(x => x.BookId, () => Guid.NewGuid());

            var list = A.ListOf<Book>(30);

            list[0].BookId = Guid.Empty;

            return list;
        }

        private Mock<Context> CreateContext()
        {
            var testData = GetTestData().AsQueryable();

            var dbset = new Mock<DbSet<Book>>();
            dbset.As<IQueryable<Book>>().Setup(x => x.Provider).Returns(testData.Provider);
            dbset.As<IQueryable<Book>>().Setup(x => x.Expression).Returns(testData.Expression);
            dbset.As<IQueryable<Book>>().Setup(x => x.ElementType).Returns(testData.ElementType);
            dbset.As<IQueryable<Book>>().Setup(x => x.GetEnumerator()).Returns(testData.GetEnumerator());

            dbset.As<IAsyncEnumerable<Book>>()
                            .Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                            .Returns(new AsyncEnumerator<Book>(testData.GetEnumerator()));


            var context = new Mock<Context>();
            context.Setup(x => x.Books).Returns(dbset.Object);

            return context;
        }

        [Fact]
        public async Task GetBooks()
        {
            System.Diagnostics.Debugger.Launch();
            var mockContext = CreateContext();
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            var handler = new Request.Handler(mockContext.Object, mapper);

            Request.Execute request = new Request.Execute();


            var list = await handler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(list.Any());
        }
    }
}
