using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class FactoryBL
    {
        public static IBL getIBL()
        {
            if (instence == null)
                instence = new IBL_imp();
            return instence;
        }

        private FactoryIBL() { } //constructur

        private static IBL instence = null;
    }
}
