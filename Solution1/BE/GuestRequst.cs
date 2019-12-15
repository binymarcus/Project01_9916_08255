using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    //need to check about enums
    public  class GuestRequest
    {
         long GuestRequestKey;
         string PriavteName;
         string FamilyName;
         string MailAddress;
         DateTime RegistrationDate;
         DateTime EntryDate;
         DateTime ReleaseDate;
         string SubArea; 
         int Adults;
         int Children;

        public GuestRequest( string priavteName, string familyName, string mailAddress, DateTime registrationDate, DateTime entryDate, DateTime releaseDate, string subArea, int adults, int children)
        {
            SGuestRequestKey++;
            GuestRequestKey = SGuestRequestKey;
            PriavteName = priavteName; 
            FamilyName = familyName;
            MailAddress = mailAddress;
            RegistrationDate = registrationDate;
            EntryDate = entryDate;
            ReleaseDate = releaseDate;
            SubArea = subArea;
            Adults = adults;
            Children = children;
        }

        public override string ToString()
        {
            //need to write once class finished
            return base.ToString();
        }
        //may need add other things. will do later. erase at end of project
    }
}
