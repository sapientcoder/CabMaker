using System;

namespace CabMaker
{
    public class StringUtil
    {
        public static bool IsNullOrWhiteSpace(string input)
        {
            return (input == null || input.Trim().Length < 1);
        }
    }
}
