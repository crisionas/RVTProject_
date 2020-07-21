using System;

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
