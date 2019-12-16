using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class BankAccount
    {
        //all these are set as private by us, can be changed-delete before handing in
         int BankNumber;// may need to be static and moved to configuration
         string BankName;
         int BranchNumbner;
         string BranchAddress;
         string BranchCity;
         int BankAccountNumber;//or this needs to be static, probably not

        public string BranchCity1 { get => BranchCity; set => BranchCity = value; }
        public int BankAccountNumber1 { get => BankAccountNumber; set => BankAccountNumber = value; }
        public string BranchAddress1 { get => BranchAddress; set => BranchAddress = value; }
        public int BranchNumbner1 { get => BranchNumbner; set => BranchNumbner = value; }
        public string BankName1 { get => BankName; set => BankName = value; }
        public int BankNumber1 { get => BankNumber; set => BankNumber = value; }

        public override string ToString()
        {
            //needs to be done
            return base.ToString();
        }

    }
}
