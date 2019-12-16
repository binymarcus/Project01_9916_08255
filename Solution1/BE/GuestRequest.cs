using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    //need to check about enums
    public class GuestRequest
    {
         long GuestRequestKey=++Configuration.GuestRequestKey;//no idea if this works, cool if it does.
         string PriavteName;
         string FamilyName;
         string MailAddress;
         DateTime RegistrationDate;
         DateTime EntryDate;
         DateTime ReleaseDate;
         string SubArea; 
         int Adults;
         int Children;
        public long GuestRequestKey1 { get => GuestRequestKey; set => GuestRequestKey = value; }
        public string PriavteName1 { get => PriavteName; set => PriavteName = value; }
        public string FamilyName1 { get => FamilyName; set => FamilyName = value; }
        public string MailAddress1 { get => MailAddress; set => MailAddress = value; }
        public DateTime RegistrationDate1 { get => RegistrationDate; set => RegistrationDate = value; }
        public DateTime EntryDate1 { get => EntryDate; set => EntryDate = value; }
        public DateTime ReleaseDate1 { get => ReleaseDate; set => ReleaseDate = value; }
        public string SubArea1 { get => SubArea; set => SubArea = value; }
        public int Adults1 { get => Adults; set => Adults = value; }
        public int Children1 { get => Children; set => Children = value; }

        public override string ToString()
        {
            //need to write once class finished
            return base.ToString();
        }
        //may need add other things. will do later. erase at end of project
    }
}
