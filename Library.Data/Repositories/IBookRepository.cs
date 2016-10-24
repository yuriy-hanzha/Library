using Library.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Library.Data.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Book GetBook(Guid id);
    }

    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Delete(GetBook(id));
        }

        public void Delete(Book entity)
        {
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<Book> FindBy(Expression<Func<Book, bool>> predicate)
        {
            var query = _context.Books.Where(predicate);
            return query;
        }

        public Book First(Expression<Func<Book, bool>> predicate)
        {
            var entity = _context.Books.First(predicate);
            return entity;
        }

        public Book FirstOrDefault(Expression<Func<Book, bool>> predicate)
        {
            var entity = _context.Books.FirstOrDefault(predicate);
            return entity;
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books.AsNoTracking();
        }

        public Book GetBook(Guid id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Book Update(Book entity)
        {
            if (entity == null) return null;

            var existing = _context.Books.FirstOrDefault(b => b.Id == entity.Id);
            if(existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.Entry(existing).Property("AddedDate").IsModified = false;
            }
            _context.SaveChanges();
            return existing;
        }
    }

}
