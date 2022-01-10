using System;
using System.Collections.Generic;
using System.Text;

namespace OpDrop
{
    public class ActionRequiredException : Exception
    {
        public ActionRequiredException() { }

        public ActionRequiredException(string message)
            : base(message)
        {

        }
    }
}
