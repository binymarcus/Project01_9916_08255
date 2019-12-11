using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    //need to check about enums
    public  class GuestRequest
    {
         long GuestRequestKey;// may need to be static and moved to config
         string PriavteName;
         string FamilyName;
         string MailAddress;
         Status Status; //Status enum
         DateTime RegistrationDate;
         DateTime EntryDate;
         DateTime ReleaseDate;
         Area Area;
         string subArea; 
         Type Type; //enum Type -type of hotel
         int Adults;
         int Children;
         choice pool; // pool enum
         choice Jacuzzi;//jacuzzi enum
         choice Garden;//garden enum
         choice ChildrensAttractions;//ChildrensAttractions enum
    
        public override string ToString()
        {
            //need to write once class finished
            return base.ToString();
        }
        //may need add other things. will do later. erase at end of project
    }
}
