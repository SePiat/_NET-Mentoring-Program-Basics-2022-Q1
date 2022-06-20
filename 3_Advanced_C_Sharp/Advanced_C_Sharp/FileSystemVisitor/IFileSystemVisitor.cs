using System;
using System.Collections.Generic;
using Advanced_C_Sharp.Models;

namespace Advanced_C_Sharp.FileSystemVisitor
{
    public interface IFileSystemVisitor<out T> : IDisposable
    {
        void CreateSearchResult(string path);
        IEnumerator<T> GetEnumerator();
        public void ExcludeItemFromSearchResult(string itemToExlude);
        void AboardSearch();
        event EventHandler<SearchStartedEventArgs> SearchStarted;
        event EventHandler<SearchFinishedEventArgs> SearchFinished;

    }
}
