using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class Host
    {
        long HostKey;
        string PrivateName;//the host first name
        string FamilyName;//the hosts last name
        long phoneNumber; //the phone number
        string MailAddress;//hosts email addres
        BankBranch BankBranchDetails;
        int BankAccountNumber;
        bool CollectionClearance;// bool to check if we are cleared to take money from bank
        int NumOfHostinUnits;
        #region properties
        public long HostKey1 { get => HostKey; set => HostKey = value; }
        public string PrivateName1 { get => PrivateName; set => PrivateName = value; }
        public string FamilyName1 { get => FamilyName; set => FamilyName = value; }
        public long PhoneNumber1 { get => phoneNumber; set => phoneNumber = value; }
        public string MailAddress1 { get => MailAddress; set => MailAddress = value; }
        public BankBranch BankBranchDetails1 { get => BankBranchDetails; set => BankBranchDetails = value; }
        public int BankAccountNumber1 { get => BankAccountNumber; set => BankAccountNumber = value; }
        public bool CollectionClearance1 { get => CollectionClearance; set => CollectionClearance = value; }
        public int NumOfHostinUnits1 { get => NumOfHostinUnits; set => NumOfHostinUnits = value; }
        #endregion
        public override string ToString()
        {
            string to = "Host Key: " + Convert.ToString(HostKey);
            to += "\n Private name: " + PrivateName;
            to += "\n Last name: " + FamilyName;
            to += "\n Phone number: " + Convert.ToString(phoneNumber);
            to += "\n Mailing address: " + MailAddress;
            to += "\n bank branch details: " + BankBranchDetails.ToString();
            to += "\n bank account number: " + BankAccountNumber;
            to += "\n collection clearance: " + CollectionClearance;
            to += "\n number of hosting units: " + NumOfHostinUnits;
            return to;
        }
    }
}
