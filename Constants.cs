namespace CabMaker
{
    public static class Constants
    {
        public static CompressionType DefaultCompressionType = CompressionType.MSZIP;
        public static CompressionWindowSize DefaultCompressionWindowSize;

        static Constants()
        {
            DefaultCompressionWindowSize = CompressionWindowSizes[3];
        }

        /// <summary>
        /// Size of the LZX sliding window.
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/previous-versions/bb417343(v=msdn.10)"/>
        public static CompressionWindowSize[] CompressionWindowSizes = new []
        {
            new CompressionWindowSize(15, "32 KB"),   // 2^15
            new CompressionWindowSize(16, "64 KB"),   // 2^16
            new CompressionWindowSize(17, "128 KB"),  // etc.
            new CompressionWindowSize(18, "256 KB"),
            new CompressionWindowSize(19, "512 KB"),
            new CompressionWindowSize(20, "1 MB"),
            new CompressionWindowSize(21, "2 MB")
        };

        public const int MaxLinesInDdf = 1024;
    }
}
