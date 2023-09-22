using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opg1og2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1og2.Tests
{
    [TestClass()]
    public class BookTests
    {
        private Book book1 = new Book { Id = 5, Title = "League of Legends", Price = 500 };
        private Book bookNegativePrice = new Book { Id = 5, Title = "Siuuu", Price = -1 };
        private Book bookOver1200 = new Book { Id = 10, Title = "Siuuu", Price = 1299 };
        private Book bookTitleLessThan3 = new Book { Id = 5, Title = "Ha", Price = 500 };


        [TestMethod()]
        public void ValidationTitleTest()
        {
            book1.ValidationTitle();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookTitleLessThan3.ValidationTitle());

        }

        [TestMethod()]
        public void ValidationPriceTest()
        {
            book1.ValidationPrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookNegativePrice.ValidationPrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookOver1200.ValidationPrice());

        }

        [TestMethod()]
        public void ValidationTest()
        {
            book1.Validation();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("{Id=5, Title=League of Legends, Price=500}", book1.ToString());
        }
    }   
}