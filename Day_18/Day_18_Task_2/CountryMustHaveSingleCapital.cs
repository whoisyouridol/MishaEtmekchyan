using System;
using System.Runtime.Serialization;

namespace Day_18_Task_2
{
    internal class CountryMustHaveSingleCapital : Exception
    {
        public CountryMustHaveSingleCapital()
        {
        }

        public CountryMustHaveSingleCapital(string message) : base(message)
        {
        }

        public CountryMustHaveSingleCapital(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CountryMustHaveSingleCapital(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}