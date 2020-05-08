using System;
using System.Collections.Generic;
using System.Text;

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
