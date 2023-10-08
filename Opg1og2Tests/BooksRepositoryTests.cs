using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opg1og2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1og2.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {
        private readonly Book book1 = new Book { Id = 22, Title = "Tester123", Price = 1000 };
        private readonly Book book2 = new Book { Id = 23, Title = "Test12", Price= 999 };

        private readonly List<Book> _books;
        [TestMethod()]
        public void BooksRepositoryTest()
        {
            // arrange
            var repository = new BooksRepository();

            // assert
            Assert.AreEqual(5, repository.GetAll().Count());
        }

        [TestMethod()]
        [DataRow(5, "Test title", 1)]
        public void AddTestOk(string title, double price)
        {
            // arrange
            var repository = new BooksRepository();
            var bookToAdd = new Book { Title = title, Price = price };

            // act
            var addedBook = repository.Add(bookToAdd);

            // assert
            Assert.IsNotNull(addedBook);
            Assert.AreEqual(title, addedBook.Title);
            Assert.AreEqual(price, addedBook.Price);

            var bookInList = repository.GetAll().FirstOrDefault(b => b.Id == addedBook.Id);
            Assert.IsNotNull(bookInList);
            Assert.AreEqual(bookToAdd.Title, bookInList.Title);
            Assert.AreEqual(bookToAdd.Price, bookInList.Price);
        }
        [TestMethod()]
        [DataRow(30, "Test 2", 1999)]
        [DataRow(31,"Ha", 1000)]
        public void AddTestInvalid(int id, string title, double price)
        {
            //arrange
            var repository = new BooksRepository();
            var bookToAdd = new Book {Id = id,Title = title, Price = price };
            
            // act & assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.Add(bookToAdd));
        }
        [TestMethod()]
        public void GetAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow(12, "jajjaja", 1000 )]
        public void GetByIdOkTest(int id, string title, double price)
        {
            //arrange
            var repository = new BooksRepository();
            var idOK = new Book { Id = id, Title = title, Price = price};

            //act
            var AddBook = repository.Add(idOK);
            var result = repository.GetById(AddBook.Id);

            //assert
            Assert.IsNotNull(AddBook);
            Assert.AreEqual(AddBook.Id, result.Id);
            Assert.AreEqual(AddBook.Title, result.Title);
            Assert.AreEqual(AddBook.Price, idOK.Price);

        }

        [TestMethod()]
        [DataRow(10)]
        public void GetByIdInvalidTest(int id)
        {
            var repository = new BooksRepository();

            var invalidID = repository.GetById(id);

            Assert.IsNull(invalidID);
        }


        [TestMethod()]
        [DataRow(10)]
        public void DeleteInvalidTest(int id)
        {
            var repository = new BooksRepository();

            var bookNotFound = repository.Delete(id);

            Assert.IsNull(bookNotFound);
        }

        [TestMethod()]
        [DataRow(12)]
        public void DeleteOKtest(int id)
        {
            Assert.Fail();      
        }
        public void UpdateTest()
        {
            Assert.Fail();
        }
    }
}