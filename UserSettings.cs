using System;

namespace CabMaker
{
    [Serializable]
    public class UserSettings
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public string FileName { get; set; }
        public bool IncludeSubfolders { get; set; }
    }
}
