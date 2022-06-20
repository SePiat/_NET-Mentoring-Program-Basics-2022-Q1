using System;
using System.Linq;
using Advanced_C_Sharp.Exceptions;
using Advanced_C_Sharp.FileSystemVisitor;
using Advanced_C_Sharp.Models;

namespace Advanced_C_Sharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = "c:\\Work\\TestFoldorForHV";
            var searchParameter = string.Empty;
            do
            {
                try
                {
                    using (IFileSystemVisitor<ISearchResult> visitor = new FileSystemVisitor.FileSystemVisitor((name) => name.Contains(searchParameter), searchParameter))
                    {
                        visitor.CreateSearchResult(input);
                        Console.WriteLine();
                        Console.WriteLine("Search result:");
                        foreach (var result in visitor)
                        {
                            Console.WriteLine(result.Type + " " + result.ResourceName);
                        }

                        string response;
                        do
                        {
                            Console.WriteLine("Do you want exclude files/folders from the final list (y/n)?");
                            response = Console.ReadLine();
                            if (response != "y" && response != "Y") continue;
                            Console.WriteLine("Input the Item to Exclude");
                            var itemToExlude = Console.ReadLine();
                            visitor.ExcludeItemFromSearchResult(itemToExlude);
                            foreach (var result in visitor)
                            {
                                Console.WriteLine(result.Type + " " + result.ResourceName);
                            }
                        } while (response is "y" or "Y");
                    }

                    Console.WriteLine("Input the path of directory or 'aboard'");
                    input = Console.ReadLine();
                    while (input == "aboard")
                    {
                        Console.Clear();
                        Console.WriteLine("Input the path of directory or 'aboard'");
                        input = Console.ReadLine();
                    }
                    Console.WriteLine("Input the search parameter");
                    searchParameter = Console.ReadLine();
                }
                catch (VisitorDirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Input the path of directory or 'aboard'");
                    input = Console.ReadLine();
                    while (input == "aboard")
                    {
                        Console.Clear();
                        Console.WriteLine("Input the path of directory or 'aboard'");
                        input = Console.ReadLine();
                    }
                    Console.WriteLine("Input the search parameter");
                    searchParameter = Console.ReadLine();

                }

            } while (input.Any());
        }
    }
}

