using System;

namespace BE
{
    //need to check about enums
    public  class GuestRequest
    {
        private long GuestRequestKey;// may need to be static and moved to config
        private string PriavteName;
        private string FamilyName;
        private string MailAddress;
        private DateTime RegistrationDate;
        private DateTime EntryDate;
        private DateTime ReleaseDate;
        //another enum for subArea 
        //enum Type -type of hotel
        private int Adults;
        private int Children;
    
        public override string ToString()
        {
            //need to write once class finished
            return base.ToString();
        }
        //may need add other things. will do later. erase at end of project
    }
}
