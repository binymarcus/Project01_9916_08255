using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class HostingUnit
    {
        long HostingUnitKey;// may need to be static and moved to configuration
        Host Owner; // the owner of the hosting unit
        string HostingUnitName; // hosting unit
        bool[,] Diary = new bool[12,31];  //matrix, repersent if occupied or vacant
        public override string ToString()
        {
            //fill in
            return base.ToString();
        }
    }
}
