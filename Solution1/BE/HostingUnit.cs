using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class HostingUnit
    {
        long HostingUnitKey;// may need to be static and moved to configuration
        Host Owner; // the owner of the hosting unit
        string HostingUnitName; // hosting unit
        bool[,] Diary = new bool[12,31];  //matrix, repersent if occupied or vacent

        public ToString
            {
            //fill in
            }
    }
}
