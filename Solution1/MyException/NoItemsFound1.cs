using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    public class NoItemsFound:Exception
    {
        public NoItemsFound(string messege) : base(messege)
        {

        }

    }
}
