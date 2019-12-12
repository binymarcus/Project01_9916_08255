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
        Status Status;//enum that holds the satus of the order
        DateTime CreateDate;//date order was made
        DateTime OrderDate;//date the email was sent to client 

        public override string ToString()
        {
            //needs to be done 
            return base.ToString();
        }
    }
}
