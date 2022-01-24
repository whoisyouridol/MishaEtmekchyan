using System;
using System.Collections.Generic;
using System.Text;

namespace ManageCarsService.Exceptions
{
    public class CarNotFoundException : Exception
    {
        public CarNotFoundException(string error) : base(error) { }

    }
}
