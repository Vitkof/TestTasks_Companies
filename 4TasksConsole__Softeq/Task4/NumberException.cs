
using System;

namespace Task4
{
    class NumberException : ArgumentException
    {
        public short Value { get; set; }
        public string Msg { get; } = "Number not in range [1,1000]";

        public NumberException(short val)
        {
            Value = val;
        }
    }
}
