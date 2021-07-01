using CoreProject.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.Models.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {

        }
        public ValidationException(string message) : base(message)
        {

        }
    }
}
