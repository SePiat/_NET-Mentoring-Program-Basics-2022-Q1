using HarryPotter.Models;
using HarryPotter.Services;
using NUnit.Framework;

namespace HarryPotter.Tests
{
    [TestFixture]
    public class HarryPotterUnitTests
    {
        
        [TestCase(8, new int[5] { 1, 0, 0, 0, 0 })]       
        [TestCase(2 * 8 * 0.95, new int[5] { 1, 1, 0, 0, 0 })]
        [TestCase(3 * 8 * 0.9, new int[5] { 1, 1, 1, 0, 0 })]
        [TestCase(5 * 8 * 0.75, new int[5] { 1, 1, 1, 1, 1 })]
        [TestCase(2 * 8 * 0.95 + 1 * 8, new int[5] { 2, 1, 0, 0, 0 })]
        [TestCase(3 * 8 * 0.9 + 1 * 8, new int[5] { 2, 1, 1, 0, 0 })]
        [TestCase(4 * 8 * 0.8 + 4 * 8 * 0.8, new int[5] { 2, 2, 2, 1, 1 })]
        [TestCase(3 * (8 * 5 * 0.75) + 2 * (8 * 4 * 0.8), new int[5] { 5, 5, 4, 5, 4 })]
        public void GivenListDiscountsAndSetsOfBook_WhenCalculateTotalPrice_ReturnsCalculateTotalPrice(double expected, int[] bookVolumeQuantities)
        {
            var basket = new Basket();
            for (var i = 0; i < bookVolumeQuantities.Length; i++)
            {
                basket.AddBooks((BookEnum)(i + 1), bookVolumeQuantities[i]);
            }

            var actual = basket.TotalPrice;

            Assert.AreEqual(expected, actual);
        }
    }
}