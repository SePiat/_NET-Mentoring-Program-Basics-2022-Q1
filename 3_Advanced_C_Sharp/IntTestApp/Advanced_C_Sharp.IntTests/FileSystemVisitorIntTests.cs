using System.Collections.Generic;
using System.IO;
using Advanced_C_Sharp.Models;
using NUnit.Framework;

namespace Advanced_C_Sharp.IntTests
{
    public class FileSystemVisitorIntTests
    {
        [Test]
        public void GivenCreateSearchResult_WhenAddTestItemsToFileSystem_ThenShouldHaveSearchResult()
        {
            var visitor = new FileSystemVisitor.FileSystemVisitor((name) => name.Contains(""), "");
            const string dirName = @"C:\TestDir";

            var dirInfo = new DirectoryInfo(dirName);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(@"TestDir2");
            var fileInfo = new FileInfo(dirName + "\\TestFile.txt");
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }

            visitor.CreateSearchResult(dirName);

            var results = new List<string>();
            foreach (var result in visitor.SearchResults)
            {
                results.Add(result.ResourceName);
                results.Add(result.Type.ToString());
            }
            CollectionAssert.AreEqual(new List<string>() { "C:\\TestDir", "Folder", "C:\\TestDir\\TestFile.txt", "File", "C:\\TestDir\\TestDir2", "Folder" }, results);
        }

        [Test]
        public void GivenCreateSearchResult_WhenCreateResultWithNullSearchParamterInFileSystemVisitor_ThenShouldHaveSearchResult()
        {
            var visitor = new FileSystemVisitor.FileSystemVisitor((name) => name.Contains(""), null);
            const string dirName = @"C:\TestDir";

            var dirInfo = new DirectoryInfo(dirName);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(@"TestDir2");
            var fileInfo = new FileInfo(dirName + "\\TestFile.txt");
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }

            visitor.CreateSearchResult(dirName);
            IList<SearchResult> _searchResults = new List<SearchResult>(){new("C:\\TestDir", ResourceType.Folder),
                new("C:\\TestDir\\TestFile.txt", ResourceType.File),
                new("C:\\TestDir\\TestDir2", ResourceType.Folder)
            };

            var results = new List<string>();
            foreach (var result in visitor.SearchResults)
            {
                results.Add(result.ResourceName);
                results.Add(result.Type.ToString());
            }
            CollectionAssert.AreEqual(new List<string>() { "C:\\TestDir", "Folder", "C:\\TestDir\\TestFile.txt", "File", "C:\\TestDir\\TestDir2", "Folder" }, results);
        }

        [Test]
        public void GivenCreateSearchResult_WhenCreateResultWithNullPredicateInFileSystemVisitor_ThenShouldHaveSearchResult()
        {
            var visitor = new FileSystemVisitor.FileSystemVisitor(null, "");
            const string dirName = @"C:\TestDir";

            var dirInfo = new DirectoryInfo(dirName);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(@"TestDir2");
            var fileInfo = new FileInfo(dirName + "\\TestFile.txt");
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }

            visitor.CreateSearchResult(dirName);
            IList<SearchResult> _searchResults = new List<SearchResult>(){new("C:\\TestDir", ResourceType.Folder),
                new("C:\\TestDir\\TestFile.txt", ResourceType.File),
                new("C:\\TestDir\\TestDir2", ResourceType.Folder)
            };

            var results = new List<string>();
            foreach (var result in visitor.SearchResults)
            {
                results.Add(result.ResourceName);
                results.Add(result.Type.ToString());
            }
            CollectionAssert.AreEqual(new List<string>() { "C:\\TestDir", "Folder", "C:\\TestDir\\TestFile.txt", "File", "C:\\TestDir\\TestDir2", "Folder" }, results);
        }

        [Test]
        public void GivenCreateSearchResult_WhenCreateResultWithNullPredicateAndSearchParameterInFileSystemVisitor_ThenShouldHaveSearchResult()
        {
            var visitor = new FileSystemVisitor.FileSystemVisitor(null, null);
            const string dirName = @"C:\TestDir";

            var dirInfo = new DirectoryInfo(dirName);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(@"TestDir2");
            var fileInfo = new FileInfo(dirName + "\\TestFile.txt");
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }

            visitor.CreateSearchResult(dirName);
            IList<SearchResult> _searchResults = new List<SearchResult>(){new("C:\\TestDir", ResourceType.Folder),
                new("C:\\TestDir\\TestFile.txt", ResourceType.File),
                new("C:\\TestDir\\TestDir2", ResourceType.Folder)
            };

            var results = new List<string>();
            foreach (var result in visitor.SearchResults)
            {
                results.Add(result.ResourceName);
                results.Add(result.Type.ToString());
            }
            CollectionAssert.AreEqual(new List<string>() { "C:\\TestDir", "Folder", "C:\\TestDir\\TestFile.txt", "File", "C:\\TestDir\\TestDir2", "Folder" }, results);
        }
    }
}