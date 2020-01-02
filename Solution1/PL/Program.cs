using BE;
using BL;
using System;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL bl = FactoryBL.getIBL();
            GuestRequest guesty = new GuestRequest();
            guesty.EntryDate1 = new DateTime(2020, 7, 7);
            guesty.ReleaseDate1 = new DateTime(2020, 7, 15);
            guesty.PrivateName1 = "moshe";
            guesty.Children1 = 5;

            try
            {
                bl.AddGuestRequest(guesty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            guesty.area1 = BEEnum.Area.Center;
            guesty.Children1 = 3;
            guesty.PrivateName1 = "notmoshe";

            try
             {
                 bl.UpdateGuestRequest(guesty);
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
             }

          /*  try
            {
                bl.DeleteGuestRequest(guesty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            */
            foreach (GuestRequest i in bl.GetAllGuestRequest())
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
