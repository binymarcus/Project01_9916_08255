using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class BankAccount
    {   
         int BankAccountNumber;
       
        public int BankAccountNumber1 { get => BankAccountNumber; set => BankAccountNumber = value; }

        public override string ToString()
        {
            return ("bank account number: " + BankAccountNumber);
        }

    }

    public class BankBranch
    {
        string BankName;
        int BankNumber;// may need to be static and moved to configuration
        int BranchNumbner;
        string BranchAddress;
        string BranchCity;

        public string BankName1 { get => BankName; set => BankName = value; }
        public int BankNumber1 { get => BankNumber; set => BankNumber = value; }
        public int BranchNumbner1 { get => BranchNumbner; set => BranchNumbner = value; }
        public string BranchAddress1 { get => BranchAddress; set => BranchAddress = value; }
        public string BranchCity1 { get => BranchCity; set => BranchCity = value; }

        public override string ToString()
        {
            string to = "Bank name: " + BankName;
            to += "\n Bank Number: " + BankNumber;
            to += "\n Branch number: " + BranchNumbner;
            to += "\n Branch adrress: " + BranchAddress;
            to += "\n Branch City: " + BranchCity+"\n---------------------";
            return to;
        }
    }
}
