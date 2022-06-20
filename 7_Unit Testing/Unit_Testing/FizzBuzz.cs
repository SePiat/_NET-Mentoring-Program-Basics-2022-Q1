using System;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public string GetFizzBizzResult(int number)
        {
            if (number is < 1 or > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (number % 3 == 0)
            {
                return "Fizz";
            }

            if (number % 5 == 0)
            {
                return "Buzz";
            }

            return number.ToString();
        }
    }
}
