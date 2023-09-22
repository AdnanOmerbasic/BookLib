using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1og2
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }



        public void ValidationTitle()
        {
            if (Title.Length < 3)
            {
                throw new ArgumentOutOfRangeException($"Titlen skal være længere end 3 tegn: {Title}");
            }
        }

        public void ValidationPrice()
        {
            if(Price < 0 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException($"Prisen skal være mere end 0 og mindre end 1200: {Price}");
            }
        }

        public void Validation()
        {
            ValidationTitle();
            ValidationPrice();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Title)}={Title}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
