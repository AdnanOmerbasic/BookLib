using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1og2
{
    public class BooksRepository: IBooksRepository
    {
        private readonly List<Book> _books = new();

        public BooksRepository()
        {
            //books = new List<Book>();
            _books.Add(new Book() { Id = 1, Title = "Agile Samurai", Price = 500});
            _books.Add(new Book() { Id = 2, Title = "C# book", Price = 400 });
            _books.Add(new Book() { Id = 3, Title = "Javascript book", Price = 400 });
            _books.Add(new Book() { Id = 4, Title = "Python book", Price = 400 });
            _books.Add(new Book() { Id = 5, Title = "Network book", Price = 600 });
        }

        public Book Add(Book book)
        {
            book.Validation();
            _books.Add(book);
            return book;
        }

        public IEnumerable<Book> GetAll(int? filtrerPrice = null, int? sortByPrice = null)
        {
            IEnumerable<Book> books = new List<Book>(_books);
            if(filtrerPrice != null)
            {
               books = books.Where(book => book.Price > filtrerPrice);
            }
            if(sortByPrice != null)
            {
                books = books.OrderBy(b => b.Price);
            }
            return books;
        } 

        public Book GetById(int id)
        {
            foreach(Book book in _books)
            {
                if(book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }

        public Book Delete(int id)
        {
            Book book = GetById(id);
            if(book != null)
            {
                _books.Remove(book);
                return book;
            }
            return null;
        }

        public Book Update(int id, Book book)
        {
            book.Validation();
            foreach (Book b in _books)
            {
                if(b.Id == id)
                {
                    b.Id = book.Id;
                    b.Title = book.Title;
                    b.Price = book.Price;
                }
            }
            return null;
        }
    }
}
