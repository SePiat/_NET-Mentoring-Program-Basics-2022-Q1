using System;
using Advanced_C_Sharp.Models;

namespace Advanced_C_Sharp.Helpers
{
    public static class ConsoleOutput
    {
        public static void WriteStartEventMessage(object sender, SearchStartedEventArgs startEventArgs)
        {
            if (sender is FileSystemVisitor.FileSystemVisitor)
            {
                Console.WriteLine($"Search started at: {startEventArgs.Time.ToLongTimeString()} in folder {startEventArgs.PathOfSearch}");
            }
        }
        public static void WriteFinishEventMessage(object sender, SearchFinishedEventArgs finishEventArgs)
        {
            if (sender is FileSystemVisitor.FileSystemVisitor)
            {
                Console.WriteLine($"Search finished at: {finishEventArgs.Time.ToLongTimeString()} in folder {finishEventArgs.PathOfSearch} with duration: {finishEventArgs.DurTotalMilliseconds}ms");
            }
        }

        public static void WriteFileFoundEventMessage(object sender, ItemFoundEventArgs fileFoundEventArgs)
        {
            if (sender is FileSystemVisitor.FileSystemVisitor)
            {
                Console.WriteLine($"File: {fileFoundEventArgs.Name} found at {fileFoundEventArgs.Time}");
            }
        }
        public static void WriteDirectoryFoundEventMessage(object sender, ItemFoundEventArgs directoryFoundEventArgs)
        {
            if (sender is FileSystemVisitor.FileSystemVisitor)
            {
                Console.WriteLine($"Directory: {directoryFoundEventArgs.Name} found at {directoryFoundEventArgs.Time}");
            }
        }

        public static void WriteFilteredFileFoundEventMessage(object sender, FilteredItemFoundEventArgs fileFoundEventArgs)
        {
            if (sender is FileSystemVisitor.FileSystemVisitor)
            {
                Console.WriteLine($"Filtered file: {fileFoundEventArgs.Name} found at {fileFoundEventArgs.Time} with search parameter: {fileFoundEventArgs.SearchParameter}");
            }
        }
        public static void WriteFilteredDirectoryFoundEventMessage(object sender, FilteredItemFoundEventArgs directoryFoundEventArgs)
        {
            if (sender is FileSystemVisitor.FileSystemVisitor)
            {
                Console.WriteLine($"Filtered directory: {directoryFoundEventArgs.Name} found at {directoryFoundEventArgs.Time} with search parameter: {directoryFoundEventArgs.SearchParameter}");
            }
        }
    }
}
