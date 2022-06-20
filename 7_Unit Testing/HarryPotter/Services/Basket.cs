using HarryPotter.Models;
using System.Collections.Generic;
using System.Linq;

namespace HarryPotter.Services
{
    public class Basket
    {
        private readonly List<BookSet> _bookSets = new();

        public double TotalPrice
        {
            get
            {
                return _bookSets.Sum(x => x.Price);
            }
        }

        public void AddBook(Book book)
        {
            var availableBookSets = _bookSets.Where(x => !x.Contains(book));

            if (availableBookSets.Count() != 0)
            {
                ChooseOptimalBookSet(availableBookSets, book).AddBook(book);
            }
            else
            {
                var newBookSet = new BookSet();
                newBookSet.AddBook(book);
                _bookSets.Add(newBookSet);
            }
        }

        public void AddBooks(BookEnum bookVolume, int quantity)
        {
            for (var i = 1; i <= quantity; i++)
            {
                AddBook(new Book(bookVolume));
            }
        }

        public void AddBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                AddBook(book);
            }
        }

        private BookSet ChooseOptimalBookSet(IEnumerable<BookSet> availableBookSets, Book book)
        {
            BookSet optimalBookSet = null;
            var totalPrice = double.MaxValue;

            foreach (var bookSet in availableBookSets)
            {
                bookSet.AddBook(book);
                if (TotalPrice < totalPrice)
                {
                    totalPrice = TotalPrice;
                    optimalBookSet = bookSet;
                }
                bookSet.RemoveBook(book);
            }

            return optimalBookSet;
        }
    }
}
