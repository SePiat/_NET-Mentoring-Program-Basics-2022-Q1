using System;

namespace Advanced_C_Sharp.Exceptions
{
    public class VisitorDirectoryNotFoundException : Exception
    {
        public VisitorDirectoryNotFoundException(string path)
            : base($"The directory with path {path} is not found") { }
    }
}
