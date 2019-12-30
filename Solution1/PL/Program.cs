using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL bL =  FactoryBL.getIBL();
            GuestRequest guesty = new GuestRequest();
            bL.AddGuestRequest(guesty);
            bL.AddGuestRequest(guesty);
            bL.
        }
    }
}
