using System;
using System.Text;

namespace CabMaker
{
    static class StringExtensions
    {
        /// <summary>
        /// Adds surrounding double quotes to a string if not already present.
        /// </summary>
        /// <returns>
        /// Input string surrounded by double quotes (or <c>null</c> if input string was null)
        /// </returns>
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
