using System;

namespace Advanced_C_Sharp.Models
{
    public class FilteredItemFoundEventArgs
    {
        public string Name;
        public string SearchParameter;
        public DateTime Time;
        public FilteredItemFoundEventArgs(string name, string searchParameter, DateTime time)
        {
            Name = name;
            SearchParameter = searchParameter;
            Time = time;
        }
    }
}
