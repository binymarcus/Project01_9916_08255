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
        long FhoneNumber; //הטעות במקור
        string MailAddress;//hosts email addres
        BankAccount BankAccount; //host bank account
        bool CollectionClearance;// if paid or not

        public override ToString
            {
            //fill in
            }
    }
}
