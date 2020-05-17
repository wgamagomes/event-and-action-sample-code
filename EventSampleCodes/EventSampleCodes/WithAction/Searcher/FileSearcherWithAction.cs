using EventSampleCodes.Searcher.WithAction.Dto;
using System;
using System.IO;

namespace EventSampleCodes.Searcher.WithAction
{
    public class FileSearcherWithAction
    {        
        public Action<FileFoundDto> FileFound;
        public Action<SearchDirectoryDto> DirectoryChanged;


        public void Search(string path, string searchPattern, bool searchSubDirectories = false)
        {
            if (searchSubDirectories)
            {
                var allDirectories = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);
                var completedDirectories = 0;
                var totalDirectories = allDirectories.Length + 1;

                foreach (var directory in allDirectories)
                {
                    DirectoryChanged?.Invoke(new SearchDirectoryDto(directory, totalDirectories, completedDirectories++));

                    SearchDirectory(directory, searchPattern);
                }

                DirectoryChanged?.Invoke(new SearchDirectoryDto(path, totalDirectories, completedDirectories++));

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
                var dto = new FileFoundDto(file);
                FileFound?.Invoke(dto);

                if (dto.CancelRequested)
                    break;
            }
        }
    }
}