using System;
using System.Collections.Generic;
using System.Text;

namespace MyCustomList.Exceptions
{
    class NotSingleElementException : Exception
    {
        public NotSingleElementException() : base(string.Format("This element was not single in array"))
        {

        }
    }
}
