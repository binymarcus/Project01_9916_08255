using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    //need to check about enums
    public  class GuestRequest
    {
        private long GuestRequestKey;// may need to be static and moved to config
        private string PriavteName;
        private string FamilyName;
        private string MailAddress;
        private Status Status; //Status enum
        private DateTime RegistrationDate;
        private DateTime EntryDate;
        private DateTime ReleaseDate;
        private Area Area;
        private string subArea; 
        private Type Type; //enum Type -type of hotel
        private int Adults;
        private int Children;
        private choice pool; // pool enum
        private choice Jacuzzi;//jacuzzi enum
        private choice Garden;//garden enum
        private choice ChildrensAttractions;//ChildrensAttractions enum
    
        public override string ToString()
        {
            //need to write once class finished
            return base.ToString();
        }
        //may need add other things. will do later. erase at end of project
    }
}
