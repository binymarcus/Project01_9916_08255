using System;
using System.Collections.Generic;
using System.Text;
using DAL;


namespace BL
{
    class ClassBLAdapter
    {
        public ClassBLAdapter()
        {
            DAL.IDAL dal = DAL.FactoryDAL.getDAL();
        }
    }
}
