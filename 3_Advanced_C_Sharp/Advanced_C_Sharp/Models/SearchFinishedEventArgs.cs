using System;

namespace Advanced_C_Sharp.Models
{
    public class SearchFinishedEventArgs
    {
        public DateTime Time;
        public string PathOfSearch;
        public double DurTotalMilliseconds;

        public SearchFinishedEventArgs(DateTime time, string puthOfSearch, double durTotalMilliseconds)
        {
            this.Time = time;
            this.PathOfSearch = puthOfSearch;
            this.DurTotalMilliseconds = durTotalMilliseconds;
        }
    }
}
