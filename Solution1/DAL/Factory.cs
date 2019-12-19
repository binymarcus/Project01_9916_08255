using System;

/// <summary>
/// Also Factory and Also singelton method
/// </summary>
/// 
namespace DAL
{
    public class FactoryDAL
    {
        public static IDAL getDAL()
        {
            if(instance == null)
                instence = new DAL_imp();
            return instence;
        }

        private FactoryDAL() { } //constructur

        private static IDAL instence = null;
    }


}
