using System;

namespace CabMaker
{
    /// <summary>
    /// Represents one row in a DDF file.
    /// </summary>
    /// <see cref="https://download.microsoft.com/download/4/d/a/4da14f27-b4ef-4170-a6e6-5b1ef85b1baa/[ms-cab].pdf"/>
    public class DdfFileRow
    {
        public string FullName { get; set; }
        public string Path { get; set; }
    }
}
