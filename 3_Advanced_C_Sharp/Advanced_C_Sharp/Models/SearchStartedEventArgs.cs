using System;

namespace Advanced_C_Sharp.Models
{
    public class SearchStartedEventArgs
    {
        public DateTime Time;
        public string PathOfSearch;

        public SearchStartedEventArgs(DateTime time, string pathOfSearch)
        {
            Time = time;
            PathOfSearch = pathOfSearch;
        }
    }
}
