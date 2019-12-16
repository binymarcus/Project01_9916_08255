using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Host
    {
        long HostKey; // may need to be static and moved to configuration
        string PrivateName;//the host first name
        string FamilyName;//the hosts last name
        long phoneNumber; //the phone number
        string MailAddress;//hosts email addres
        BankAccount BankAccount; //host bank account
        bool CollectionClearance;// bool to check if we are cleared to take money from bank

        public long HostKey1 { get => HostKey; set => HostKey = value; }
        public string PrivateName1 { get => PrivateName; set => PrivateName = value; }
        public string FamilyName1 { get => FamilyName; set => FamilyName = value; }
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string MailAddress1 { get => MailAddress; set => MailAddress = value; }
        public bool CollectionClearance1 { get => CollectionClearance; set => CollectionClearance = value; }
        internal BankAccount BankAccount1 { get => BankAccount; set => BankAccount = value; }

        /*************may need to make more variables-erase at the end of project*************/

        public override string ToString()
        {
            //needs to be done
            return base.ToString();
        }
    }
}
