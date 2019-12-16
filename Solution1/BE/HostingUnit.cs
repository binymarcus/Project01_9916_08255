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

        public long HostingUnitKey1 { get => HostingUnitKey; set => HostingUnitKey = value; }
        public string HostingUnitName1 { get => HostingUnitName; set => HostingUnitName = value; }
        public bool[,] Diary1 { get => Diary; set => Diary = value; }
        internal Host Owner1 { get => Owner; set => Owner = value; }

        public override string ToString()
        {
            //fill in
            return base.ToString();
        }
    }
}
