using EventSampleCodes.Searcher.WithEvent.Args;
using System;
using System.IO;

namespace EventSampleCodes.Searcher.WithEvent
{
    public class FileSearcherWithEvent
    {
        //Represents the method that will handle an event when the event provides data
        public event EventHandler<FileFoundArgs> FileFound;
        public event EventHandler<SearchDirectoryArgs> DirectoryChanged;


        public void Search(string path, string searchPattern, bool searchSubDirectories = false)
        {
            if (searchSubDirectories)
            {
                var allDirectories = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);
                var completedDirectories = 0;
                var totalDirectories = allDirectories.Length + 1;
               
                foreach (var directory in allDirectories)
                {
                    DirectoryChanged?.Invoke(this,
                        new SearchDirectoryArgs(directory, totalDirectories, completedDirectories++));
                   
                    SearchDirectory(directory, searchPattern);
                }
               
                DirectoryChanged?.Invoke(this,
                    new SearchDirectoryArgs(path, totalDirectories, completedDirectories++));

                SearchDirectory(path, searchPattern);
            }
            else
            {
                SearchDirectory(path, searchPattern);
            }
        }

        private void SearchDirectory(string directory, string searchPattern)
        {
            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                var args = new FileFoundArgs(file);
                FileFound?.Invoke(this, args);

                if (args.CancelRequested)
                    break;
            }
        }
    }
}