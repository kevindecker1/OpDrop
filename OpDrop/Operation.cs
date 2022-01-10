using System;
using System.Collections.Generic;
using System.Text;

namespace OpDrop
{
    internal class Operation
    {
        private Action _action { get; set; }

        internal Operation(Action action)
        {
            _action = action;
        }

        internal void DoWork()
        {
            if (_action != null)
            {
                _action();
            }
        }
    }
}
