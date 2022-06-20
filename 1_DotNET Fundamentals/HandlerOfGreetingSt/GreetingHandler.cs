using System;

namespace HandlerOfGreetingSt
{
    public class GreetingHandler
    {
        public string GreetHandle(string username)
        {
            return $"{DateTime.Now.ToShortTimeString()} Hello, {username}";
        }
    }
}
