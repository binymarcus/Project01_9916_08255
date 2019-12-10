using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Order
    {
        long HostingUnitKey; // may need to be static and moved to configuration
        long GuestRequestKey; // may need to be static and moved to configuration
        long OrderKey; // may need to be static and moved to configuration
        Status Status;
        DateTime CreateDate;
        DateTime OrderDate;

        public ToString
            {
            //fill in
            }
    }
}
