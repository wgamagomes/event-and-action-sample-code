using System;

namespace EventSampleCodes.Searcher.WithEvent.Args
{
    public class SearchDirectoryArgs: EventArgs
    {
        public string CurrentDirectory { get; private set; }
        public int TotalDirectories { get; private set; }
        public int CompletedDirectories { get; private set; }

        public SearchDirectoryArgs(string currentDirectory, int totalDirectories, int completedDirectories)
        {
            CurrentDirectory = currentDirectory;
            TotalDirectories = totalDirectories;
            CompletedDirectories = completedDirectories;
        }
    }   
}
