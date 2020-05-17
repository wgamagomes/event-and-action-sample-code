namespace EventSampleCodes.Searcher.WithAction.Dto
{
    public class FileFoundDto 
    {
        public string FoundFile { get; private set; }
        public bool CancelRequested { get; set; }

        public FileFoundDto(string foundFile)
        {
            FoundFile = foundFile;
        }
    }
}
