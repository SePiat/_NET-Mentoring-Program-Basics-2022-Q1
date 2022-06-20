using System;

namespace Advanced_C_Sharp.Models
{
    public class ItemFoundEventArgs
    {
        public string Name;
        public DateTime Time;
        public ItemFoundEventArgs(string name, DateTime time)
        {
            Name = name;
            Time = time;
        }
    }
}
