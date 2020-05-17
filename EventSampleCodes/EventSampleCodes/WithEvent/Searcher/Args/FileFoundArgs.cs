using System;

namespace EventSampleCodes.Searcher.WithEvent.Args
{
    public class FileFoundArgs : EventArgs
    {
        public string FoundFile { get; private set; }
        public bool CancelRequested { get; set; }

        public FileFoundArgs(string foundFile)
        {
            FoundFile = foundFile;
        }
    }   
}
