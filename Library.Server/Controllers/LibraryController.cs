using AutoMapper;
using Library.Data.DTOs;
using Library.Data.Entities;
using Library.Data.Repositories;
using System;
using System.Linq;
using System.Web.Http;

namespace Library.Server.Controllers
{
    [RoutePrefix("api/Library")]
    public class LibraryController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public LibraryController(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IHttpActionResult GetBooks()
        {
            var books = _bookRepository.GetAll().ToList().Select(b => _mapper.Map<BookModel>(b));
            return Ok(books);
        }

        [HttpPost]
        public IHttpActionResult AddBook(BookModel model)
        {
            if (!ModelState.IsValid) return BadRequest("model is not valid");

            var sameBook = _bookRepository.FirstOrDefault(b => b.Name == model.Name && b.Author == model.Author);
            if (sameBook != null) return BadRequest("the same book is aready exist");

            var book = new Book()
            {
                Name = model.Name,
                Author = model.Author
            };

            if (model.PublishingYear.HasValue && model.PublishingYear <= DateTime.Now.Year)
                book.PublishingYear = model.PublishingYear;

            if (string.IsNullOrEmpty(model.PublishingHouse))
                book.PublishingHouse = model.PublishingHouse;

            _bookRepository.Add(book);

            return Ok();
        }
    }
}
