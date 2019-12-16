using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BEEnum
        {
          enum Status {pending, mailSent,closedByClientsLackOfResponse, ClosedByClientResponse};
          enum Area { All,North,South,Center,Jerusalem}
          enum ChildrensAttractions { Must,Optional,notInterested}
          enum Jacuzzi { Must,Optional,notInterested}
          enum Pool { Must, Optional, notInterested }
          enum Type { Zimmer,Hotel,Camping,BAndB }
          enum Garden { Must,Optional,notInterested}
        }

}
