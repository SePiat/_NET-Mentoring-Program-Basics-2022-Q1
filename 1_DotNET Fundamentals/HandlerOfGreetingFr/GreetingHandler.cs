using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlerOfGreetingFr
{
    public class GreetingHandler
    {
        public string GreetHandle(string username)
        {
            return $"{DateTime.Now.ToShortTimeString()} Hello, {username}";
        }
    }
}
