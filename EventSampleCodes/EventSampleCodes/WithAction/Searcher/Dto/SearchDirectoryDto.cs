using System;

namespace EventSampleCodes.Searcher.WithAction.Dto
{
    public class SearchDirectoryDto
    {
        public string CurrentDirectory { get; private set; }
        public int TotalDirectories { get; private set; }
        public int CompletedDirectories { get; private set; }

        public SearchDirectoryDto(string currentDirectory, int totalDirectories, int completedDirectories)
        {
            CurrentDirectory = currentDirectory;
            TotalDirectories = totalDirectories;
            CompletedDirectories = completedDirectories;
        }
    }
}
