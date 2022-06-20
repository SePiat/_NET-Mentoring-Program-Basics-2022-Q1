using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
             static void WriteFirstCharacter(string inputLine)
             {
                if (string.IsNullOrEmpty(inputLine))
                {
                    throw new ArgumentException("String must not be empty or null");
                }
                Console.WriteLine(inputLine[0]);
             }

             try
             {
                 WriteFirstCharacter(string.Empty);
             }
             catch (ArgumentException e)
             {
                 Console.WriteLine($"Incorrect input string.{e.Message}");
             }
             Console.ReadKey();
        }
    }
}