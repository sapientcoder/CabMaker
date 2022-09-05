using System;
using System.Collections.Generic;

namespace CabMaker
{
    [Serializable]
    public class UserSettings
    {
        public string FileName { get; set; }
        public object CompressionType { get; set; }
        public object CompressionWindowSize { get; set; }
    }
}
