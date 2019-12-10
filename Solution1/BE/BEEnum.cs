using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
enum Status{pending, mailSent,closedByClientsLackOfResponse, ClosedByClientResponse};
enum Area { All,North,South,Center,Jerusalem}
//enum NorthSubSArea { /*needs to be filled*/}
//enum SouthSubArea { /*needs to be filled*/}
//enum CenterSubArea { /*needs to be filled*/}
//enum JerusalmSubArea { /*needs to be filled*/}
enum Type { Zimmer,Hotel,Camping,BAndB}
enum choice { Must,Optional,notInterested}
}
