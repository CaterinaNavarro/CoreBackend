using System;
using System.Collections.Generic;
using System.Text;

namespace CoreProject.Models.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {

        }
        public ItemNotFoundException(string message) : base(message)
        {

        }
    }
}
