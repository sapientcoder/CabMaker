using System;

namespace CabMaker
{
    /// <summary>
    /// Utility class for working with enumerations.
    /// </summary>
    internal class EnumUtil
    {
        public static TEnum SafeParse<TEnum>(string value, TEnum defaultValue) where TEnum : struct
        {
            TEnum result;

            bool success = Enum.TryParse<TEnum>(value, true, out result);

            return success ? result : defaultValue;
        }
    }
}
