using System;

namespace CabMaker
{
    static class StringExtensions
    {
        /// <summary>
        /// Adds surrounding quotes to a string if not already present.
        /// </summary>
        /// <remarks>
        /// This only works on non-null strings. A null string will be returned as-is (null).
        /// </remarks>
        public static string EnsureQuoted(this string input)
        {
            string result = input;

            if (input != null && !(input.StartsWith("\"") && input.EndsWith("\"")))
            {
                result = String.Format("\"{0}\"", input);
            }

            return result;
        }
    }
}
