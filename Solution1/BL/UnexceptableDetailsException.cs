using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    [Serializable]
    class UnexceptableDetailsException : Exception
    {
        public UnexceptableDetailsException()
        {

        }

        public UnexceptableDetailsException(string messege) : base(messege)
        {

        }

    }
}
