using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Advanced_C_Sharp.Exceptions;
using Advanced_C_Sharp.Helpers;
using Advanced_C_Sharp.Models;

namespace Advanced_C_Sharp.FileSystemVisitor
{
    public class FileSystemVisitor : IFileSystemVisitor<SearchResult>, IEnumerable<SearchResult>, IDisposable
    {
        public FileSystemVisitor(Predicate<string> filter, string searchParameter)
        {
            _filter = filter;
            _searchParameter = searchParameter;
            this.SearchStarted += ConsoleOutput.WriteStartEventMessage;
            this.SearchFinished += ConsoleOutput.WriteFinishEventMessage;
            this.FileFound += ConsoleOutput.WriteFileFoundEventMessage;
            this.DirectoryFound += ConsoleOutput.WriteDirectoryFoundEventMessage;
            this.FilteredFileFound += ConsoleOutput.WriteFilteredFileFoundEventMessage;
            this.FilteredDirectoryFound += ConsoleOutput.WriteFilteredDirectoryFoundEventMessage;
        }

        public IList<SearchResult> SearchResults = new List<SearchResult>();
        private readonly Predicate<string> _filter;
        private string _searchParameter;
        public event EventHandler<SearchStartedEventArgs> SearchStarted;
        public event EventHandler<SearchFinishedEventArgs> SearchFinished;
        public event EventHandler<ItemFoundEventArgs> FileFound;
        public event EventHandler<ItemFoundEventArgs> DirectoryFound;
        public event EventHandler<FilteredItemFoundEventArgs> FilteredFileFound;
        public event EventHandler<FilteredItemFoundEventArgs> FilteredDirectoryFound;

        private void CreateSearchResultRecursion(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var directory = new DirectoryInfo(path);

            if (!directory.Exists)
            {
                throw new VisitorDirectoryNotFoundException(path);
            }

            if (_filter == null || _filter(directory.Name))
            {
                if (string.IsNullOrEmpty(_searchParameter))
                {
                    DirectoryFound?.Invoke(this, new ItemFoundEventArgs(directory.FullName, DateTime.Now));
                }
                else
                {
                    FilteredDirectoryFound?.Invoke(this, new FilteredItemFoundEventArgs(directory.FullName, _searchParameter, DateTime.Now));
                }

                SearchResults.Add(new SearchResult(directory.FullName, ResourceType.Folder));
            }

            foreach (var file in directory.GetFiles())
            {
                if (_filter != null && !_filter(directory.Name)) continue;
                if (string.IsNullOrEmpty(_searchParameter))
                {
                    FileFound?.Invoke(this, new ItemFoundEventArgs(file.Name, DateTime.Now));
                }
                else
                {
                    FilteredFileFound?.Invoke(this, new FilteredItemFoundEventArgs(file.Name, _searchParameter, DateTime.Now));
                }
                SearchResults.Add(new SearchResult(file.FullName, ResourceType.File));
            }

            foreach (var dir in directory.GetDirectories())
            {
                CreateSearchResultRecursion(dir.FullName);
            }
        }

        public void CreateSearchResult(string path)
        {
            var startTime = DateTime.Now;
            SearchStarted?.Invoke(this, new SearchStartedEventArgs(startTime, path));
            CreateSearchResultRecursion(path);
            var finishTime = DateTime.Now;
            var durTotalMilliseconds = finishTime.Subtract(startTime).TotalMilliseconds;
            SearchFinished?.Invoke(this, new SearchFinishedEventArgs(finishTime, path, durTotalMilliseconds));
        }

        public IEnumerator<SearchResult> GetEnumerator()
        {
            return SearchResults.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ExcludeItemFromSearchResult(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                SearchResults.Remove(SearchResults.FirstOrDefault(x => x.ResourceName.Equals(item)));
            }
            else
            {
                throw new ArgumentNullException(nameof(item));
            }
        }

        public void AboardSearch()
        {
            SearchResults.Clear();
        }
        public void Dispose()
        {
            this.SearchStarted -= ConsoleOutput.WriteStartEventMessage;
            this.SearchFinished -= ConsoleOutput.WriteFinishEventMessage;
            this.FileFound -= ConsoleOutput.WriteFileFoundEventMessage;
            this.DirectoryFound -= ConsoleOutput.WriteDirectoryFoundEventMessage;
            this.FilteredFileFound -= ConsoleOutput.WriteFilteredFileFoundEventMessage;
            this.FilteredDirectoryFound -= ConsoleOutput.WriteFilteredDirectoryFoundEventMessage;
        }
    }

}
