using BE;
using BL;
using System;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL bL = FactoryBL.getIBL();
            GuestRequest guesty = new GuestRequest();
            guesty.EntryDate1 = new DateTime(2020, 7, 7);
            guesty.ReleaseDate1 = new DateTime(2020, 7, 15);
            guesty.PrivateName1 = "moshe";
            try
            {
                bL.AddGuestRequest(guesty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            guesty.area1 = BEEnum.Area.Center;
            guesty.Children1 = 3;
            /*
            try
            {
                bL.UpdateGuestRequest(guesty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }*/
           
            Console.WriteLine(guesty.ToString());
            bL.DeleteGuestRequest(guesty);
            Console.WriteLine(guesty.ToString());
            Console.ReadKey();
        }
    }
}
