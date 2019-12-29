using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    //need to check about enums
    public class GuestRequest
    {
         long GuestRequestKey;
         string PrivateName;
         string FamilyName;
         string MailAddress;
         DateTime RegistrationDate;
         DateTime EntryDate;
         DateTime ReleaseDate;
         string SubArea; 
         int Adults;
         int Children;
         int TotalGuests;
        //*******enums***********//
        BEEnum.Option pool;
        BEEnum.Option Jacuzzi;
        BEEnum.Option Garden;
        BEEnum.Option ChildrensAttractions;
        BEEnum.Type type;
        BEEnum.Area area;
        BEEnum.Status status;

        //****properties****//

        public long GuestRequestKey1 { get => GuestRequestKey; set => GuestRequestKey = value; }
        public string PrivateName1 { get => PrivateName; set => PrivateName = value; }
        public string FamilyName1 { get => FamilyName; set => FamilyName = value; }
        public string MailAddress1 { get => MailAddress; set => MailAddress = value; }
        public DateTime RegistrationDate1 { get => RegistrationDate; set => RegistrationDate = value; }
        public DateTime EntryDate1 { get => EntryDate; set => EntryDate = value; }
        public DateTime ReleaseDate1 { get => ReleaseDate; set => ReleaseDate = value; }
        public string SubArea1 { get => SubArea; set => SubArea = value; }
        public int Adults1 { get => Adults; set => Adults = value; }
        public int Children1 { get => Children; set => Children = value; }
        public int TotalGuests1 { get => (Children+Adults) ; set => TotalGuests = value; }
        public BEEnum.Option pool1 { get => pool; set => pool = value;}
        public BEEnum.Option Jacuzzi1 { get => Jacuzzi; set => Jacuzzi = value;}
        public BEEnum.Option Garden1 { get => Garden; set => Garden = value;}
        public BEEnum.Option ChildrensAttractions1 { get => ChildrensAttractions; set => ChildrensAttractions = value;}
        public BEEnum.Type type1 { get => type; set => type = value;}
        public BEEnum.Area area1 { get => area; set => area = value;}
        public BEEnum.Status status1 { get => status; set => status = value;}

        public override string ToString()
        {
              string toString = "";
            toString += "GuestRequestKey: " + Convert.ToString(GuestRequestKey) + "\n";
            toString += "PrivateName: " + PrivateName + "\n";
            toString += "FamilyName: " + FamilyName + "\n";
            toString += "MailAddress: " + MailAddress + "\n";
            toString += "Status: " + status.ToString() + "\n";
            toString += "RegistrationDate: " + RegistrationDate.ToString() + "\n";
            toString += "EntryDate: " + EntryDate.ToString() + "\n";
            toString += "ReleaseDate: " + ReleaseDate.ToString() + "\n";
            toString += "Area: " + area.ToString() + "\n";
            toString += "Type: " + type.ToString() + "\n";
            toString += "Adults: " + Convert.ToString(Adults) + "\n";
            toString += "Children: " + Convert.ToString(Children) + "\n";
            toString += "TotalGuests: " + Convert.ToString(TotalGuests) + "\n";
            toString += "Pool: " + pool.ToString() + "\n";
            toString += "Jacuzzi: " + Jacuzzi.ToString() + "\n";
            toString += "Garden: " + Garden.ToString() + "\n";
            toString += "ChildrensAttractions: " + ChildrensAttractions.ToString() + "\n";
            return toString;
        }
        //may need add other things. will do later. erase at end of project
    }
}
