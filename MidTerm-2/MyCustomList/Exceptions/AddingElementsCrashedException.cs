using System;
using System.Collections.Generic;
using System.Text;

namespace MyCustomList.Exceptions
{
    class AddingElementsCrashedException : Exception
    {
        public AddingElementsCrashedException() : base(string.Format("An error occured while adding new elements "))
        {

        }
    }
}
