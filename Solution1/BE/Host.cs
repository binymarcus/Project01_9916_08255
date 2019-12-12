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
        /*************may need to make more variables-erase at the end of project*************/

        public override string ToString()
        {
            //needs to be done
            return base.ToString();
        }
    }
}
