using System;

/// <summary>
/// Also Factory and Also singelton method
/// </summary>
/// 
namespace DAL
{
    public class FactoryDAL
    {
        
        private static IDAL instence = null;
        
        public static IDAL getDAL()
        {
            if(instence == null)
                instence = new DAL_imp();
            return instence;
        }

        private FactoryDAL() { } //constructur

        
    }


}
