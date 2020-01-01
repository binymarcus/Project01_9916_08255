using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    public class UnexceptableDetailsException : Exception
    {

        public UnexceptableDetailsException(string messege) : base(messege)
        {

        }

    }
}
