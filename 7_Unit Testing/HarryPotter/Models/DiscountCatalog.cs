using System.Collections.Generic;

namespace HarryPotter.Models
{
    public class DiscountCatalog
    {
        private readonly Dictionary<int, double> _catalogue = new Dictionary<int, double>
        {
            {1, 0},
            {2, 0.05},
            {3, 0.1},
            {4, 0.20},
            {5, 0.25}
        };

        public double GetDiscount(int numberOfBooks)
        {
            return 1 - _catalogue[numberOfBooks];
        }
    }
}
