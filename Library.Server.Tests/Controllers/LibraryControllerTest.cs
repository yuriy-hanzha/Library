using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Server.Controllers;
using AutoMapper;
using Library.Data.Repositories;
using System.Web.Http.Results;
using Library.Data.DTOs;
using Moq;

namespace Library.Server.Tests.Controllers
{
    [TestClass]
    public class LibraryControllerTest
    {
        private LibraryController controller;

        [TestInitialize]
        public void SetupContext()
        {
            var mockMapper = new Mock<IMapper>();
            var mockBookRepo = new Mock<IBookRepository>();

            controller = new LibraryController(mockMapper.Object, mockBookRepo.Object);
        }

        [TestMethod]
        public void GetBooks_ShouldReturnAllBooks()
        {
            // Arrange

            // Act 
            var response = controller.GetBooks() as OkNegotiatedContentResult<IEnumerable<BookModel>>;
            var books = response.Content as IEnumerable<BookModel>;

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(books);
        }

        [TestMethod]
        public void AddBook_ShouldAddBook()
        {
            // Arrange

            // Act
            var result = controller.AddBook(new BookModel()
            {
                Name = "Test Book Name",
                Author = "Test Book Author"
            });

            var response = result as OkResult;

            // Assert
            Assert.IsNotNull(response);
        }
    }
}
