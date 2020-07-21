using System;

namespace RVTLibrary.Exceptions
{
    public class MethodRequiresException : ArgumentException
    {
        public MethodRequiresException(string paramName, string message)
            : base($"Argument {paramName} does not match the preconditions. {message}", paramName)
        {
        }
    }
}
