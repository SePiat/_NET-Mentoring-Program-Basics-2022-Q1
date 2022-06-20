using HandlerOfGreetingSt;
using System;

namespace DotNET_Core___console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input username");
            var username = Console.ReadLine();
            var handler = new GreetingHandler();
            var usernameWithDate = handler.GreetHandle(username);
            Console.WriteLine(usernameWithDate);
            Console.ReadKey();
        }
    }
}
