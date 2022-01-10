using System;
using System.Collections.Generic;
using System.Text;

namespace OpDrop
{
    public class IdentifierRequiredException : Exception
    {
        public IdentifierRequiredException() { }

        public IdentifierRequiredException(string message)
            : base(message)
        {

        }
    }
}
