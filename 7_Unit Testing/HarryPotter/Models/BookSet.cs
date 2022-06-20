using System;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotter.Models
{
    public class BookSet
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly DiscountCatalog _discounts = new DiscountCatalog();

        public double Price
        {
            get
            {
                var discount = _discounts.GetDiscount(_books.Count);
                return _books.Sum(x => x.Price) * discount;
            }
        }

        public bool Contains(Book book)
        {
            return _books.Exists(x => x.Volume == book.Volume);
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }
    }
}
