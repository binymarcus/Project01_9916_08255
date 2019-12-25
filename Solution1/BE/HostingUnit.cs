using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class HostingUnit
    {
        long HostingUnitKey;
        Host Owner; // the owner of the hosting unit
        string HostingUnitName; // hosting unit
        bool[,] Diary = new bool[12,31];  //matrix, repersent if occupied or vacant

        public long HostingUnitKey1 { get => HostingUnitKey; set => HostingUnitKey = value; }
        public string HostingUnitName1 { get => HostingUnitName; set => HostingUnitName = value; }
        public bool[,] Diary1 { get => Diary; set => Diary = value; }
        public Host Owner1 { get => Owner; set => Owner = value; }

        public override string ToString()
        {
            //fill in
            return base.ToString();
        }
        bool checkDates(DateTime start,DateTime end)
        {
            for (int i = start.Month; i <= end.Month; i++)
            {
                int j;
                if (i == start.Month)
                    j = start.Day;
                else j = 0;
                for (; j < end.Day; j++)
                {
                    if (Diary[i, j] == true)
                        return false;

                }
            }
            return true;
        }
    }
}
