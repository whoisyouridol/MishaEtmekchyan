using System;
using System.Collections.Generic;
using System.Text;

namespace ManageCarsService.Exceptions
{
    public class CouldNotAddCarException : Exception
    {
        public CouldNotAddCarException(string error):base(error) { }
    }
}
