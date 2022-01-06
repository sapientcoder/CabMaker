using System;

namespace CabMaker
{
    [Serializable]
    public class CompressionWindowSize
    {
        public CompressionWindowSize(int exponent, string size)
        {
            Exponent = exponent;
            Size = size;
        }

        public int Exponent { get; set; }
        public string Size { get; set; }
        public string Description => $"{Exponent} ({Size})";

        public override string ToString()
        {
            return $"{Exponent} ({Description})";
        }
    }
}
