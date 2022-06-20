using System;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private static int GetIntByChar(char symbol)
        {
            return symbol - '0';
        }
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException(nameof(stringValue));
            }

            if (!stringValue.Any())
            {
                throw new FormatException(nameof(stringValue));
            }

            var result = 0;
            var isNegative = false;
            var firstNumberIndex = 0;
            
            switch (stringValue[0])
            {
                case '-':
                    if (stringValue.Length == 1)
                    {
                        throw new ArgumentException(nameof(stringValue));
                    }

                    firstNumberIndex = 1;
                    isNegative = true;
                    break;
                case '+':
                    if (stringValue.Length == 1) 
                    {
                        throw new ArgumentException(nameof(stringValue));
                    }
                    firstNumberIndex = 1;
                    break;
            }
            
            for (var i = firstNumberIndex; i < stringValue.Length; i++)
            {
                if (result != 0 && stringValue[i] == ' ')
                {
                    continue;
                }

                if (stringValue[i] < '0' || stringValue[i] > '9') 
                {
                    throw new FormatException(nameof(stringValue));
                }
               
                var intByChar = GetIntByChar(stringValue[i]);
                result = isNegative ? checked(result * 10 - intByChar) : checked(result * 10 + intByChar);                
            }
            return result;

        }
    }
}