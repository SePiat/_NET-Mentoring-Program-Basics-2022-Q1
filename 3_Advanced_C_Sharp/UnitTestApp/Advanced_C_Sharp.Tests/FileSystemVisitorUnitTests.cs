using Advanced_C_Sharp.Exceptions;
using Advanced_C_Sharp.Models;
using NUnit.Framework;
using System;

namespace Advanced_C_Sharp.Tests
{
    [TestFixture]
    class FileSystemVisitorUnitTests
    {
        [Test]
        public void GivenExcludeItemFromSearchResult_WhenExcludOneItem_ThenSearchResultShouldContainNoElement()
        {
            var testSearchResult = new SearchResult("testName", ResourceType.File);
            var visitor = new FileSystemVisitor.FileSystemVisitor((name) => name.Contains(""), "");

            visitor.SearchResults.Add(testSearchResult);
            visitor.ExcludeItemFromSearchResult("testName");

            Assert.That(visitor.SearchResults.Count, Is.EqualTo(0));
        }

        [Test]
        public void GivenExcludeItemFromSearchResul_WhenTryUseNullMethodParameter_ThenThrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                var visitor = new FileSystemVisitor.FileSystemVisitor((name) => name.Contains(""), "");
                visitor.ExcludeItemFromSearchResult(null);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GivenAboardSearch_WhenRemoveOneItem_ThenRemovedOneItem()
        {
            var testSearchResult = new SearchResult("testName", ResourceType.File);
            var visitor = new FileSystemVisitor.FileSystemVisitor((name) => name.Contains(""), "");

            visitor.SearchResults.Add(testSearchResult);
            visitor.AboardSearch();

            Assert.That(visitor.SearchResults.Count, Is.EqualTo(0));
        }

        [Test]
        public void GivenCreateSearchResult_WhenNullPathParameter_ThenShouldThrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                var visitor = new FileSystemVisitor.FileSystemVisitor((name) => name.Contains(""), "");
                visitor.CreateSearchResult(null);
            }, Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GivenCreateSearchResult_WheWrongPathParameter_ThenShouldThrowsVisitorDirectoryNotFoundException()
        {
            Assert.That(() =>
            {
                var visitor = new FileSystemVisitor.FileSystemVisitor((name) => name.Contains(""), "");
                visitor.CreateSearchResult("aaa");
            }, Throws.InstanceOf<VisitorDirectoryNotFoundException>());
        }
    }
}
