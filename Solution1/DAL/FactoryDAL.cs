using System;

/// <summary>
/// Also Factory and Also singelton method
/// </summary>
/// 
namespace DAL
{
    public class FactoryDAL
    {
        
        private static Idal instence = null;
        
        public static Idal getDAL()
        {
            if(instence == null)
                instence = new DAL_imp();
            return instence;
        }

        private FactoryDAL() { } //constructur

        
    }


}
