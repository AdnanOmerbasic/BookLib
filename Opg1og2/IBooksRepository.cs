using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1og2
{
    public interface IBooksRepository
    {
        public Book Add(Book book);
        public IEnumerable<Book> GetAll(int? filtrerPrice = null, int? sortByPrice = null);
        public Book GetById(int id);
        public Book Delete(int id);
        public Book Update(int id, Book book);

    }
}
