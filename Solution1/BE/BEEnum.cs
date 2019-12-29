using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BEEnum
    {
          enum Status {pending, mailSent,closedByClientsLackOfResponse, ClosedByClientResponse};
          enum Area { All,North,South,Center,Jerusalem}
          enum Option { Must,Optional,notInterested}
          enum Type { Zimmer,Hotel,Camping,BAndB }  
    }

}
