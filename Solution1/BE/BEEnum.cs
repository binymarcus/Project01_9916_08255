using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BEEnum
    {
          public enum Status {pending, mailSent,closedByClientsLackOfResponse, dealMade,dealMadeWithOtherHost};
         public enum Area { All,North,South,Center,Jerusalem}
         public enum Option { Must,Optional,notInterested}
         public enum _Type { Zimmer,Hotel,Camping,BAndB }  
    }

}
