using EventSampleCodes.Searcher.WithAction;
using EventSampleCodes.Searcher.WithEvent;
using EventSampleCodes.Searcher.WithEvent.Args;
using System;

namespace EventSampleCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Event

            var fileListerWithEvent = new FileSearcherWithEvent();
            int filesFound = 0;

            fileListerWithEvent.FileFound += (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.FoundFile);
                filesFound++;
            };

            fileListerWithEvent.DirectoryChanged += (sender, eventArgs) =>
            {
                Console.Write($"Entering '{eventArgs.CurrentDirectory}'.");
                Console.WriteLine($" {eventArgs.CompletedDirectories} of {eventArgs.TotalDirectories} completed...");
            }; 

            fileListerWithEvent.Search(".", "*.dll", true);

            #endregion

            #region Action

            var fileListerWithAction = new FileSearcherWithAction();
            filesFound = 0;

            fileListerWithAction.FileFound = (dto) =>
            {
                Console.WriteLine(dto.FoundFile);
                filesFound++;
            };

            fileListerWithAction.DirectoryChanged = (dto) =>
            {
                Console.Write($"Entering '{dto.CurrentDirectory}'.");
                Console.WriteLine($" {dto.CompletedDirectories} of {dto.TotalDirectories} completed...");
            }; 

            fileListerWithEvent.Search(".", "*.dll", true);

            #endregion
        }

        static void Test1()
        {
            var fileLister = new FileSearcherWithEvent();
            int filesFound = 0;


            EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.FoundFile);
                filesFound++;
            };

            EventHandler<SearchDirectoryArgs> onDirectoryChanged = (sender, eventArgs) =>
            {
                Console.Write($"Entering '{eventArgs.CurrentDirectory}'.");
                Console.WriteLine($" {eventArgs.CompletedDirectories} of {eventArgs.TotalDirectories} completed...");
            };


            fileLister.FileFound += onFileFound;
            fileLister.DirectoryChanged += onDirectoryChanged;

            fileLister.Search(".", "*.dll", true);

            fileLister.FileFound -= onFileFound;
            fileLister.DirectoryChanged -= onDirectoryChanged;
        }
    }
}
