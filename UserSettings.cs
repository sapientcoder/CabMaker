using System;
using System.Collections.Generic;

namespace CabMaker
{
    [Serializable]
    public class UserSettings
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public string FileName { get; set; }
        public bool IncludeSubfolders { get; set; }

        public object CompressionType { get; set; }
        public object CompressionWindowSize { get; set; }
    }
}
