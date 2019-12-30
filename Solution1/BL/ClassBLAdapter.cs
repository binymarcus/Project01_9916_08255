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
           DAL.Idal dal = DAL.FactoryDAL.getDAL();
        }
    }
}
