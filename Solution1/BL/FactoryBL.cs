using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class FactoryBL
    {
       private static IBL instence;
        public static IBL getIBL()
        {
            if (instence == null)
                instence = new IBL_imp();
            return instence;
        }
        private FactoryBL() {} //constructur
    }
}
