using System;
using System.Collections.Generic;
using System.Text;

namespace RVTLibrary.Exceptions
{
    class MethodResultException : ArgumentException
    {
        public MethodResultException(string paramName, string message)
    : base($"Argument {paramName} does not match the preconditions.{message}", paramName)
        {
        }
    }
}
