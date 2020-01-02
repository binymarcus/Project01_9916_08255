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
            #region gs
            GuestRequest guesty = new GuestRequest();
            GuestRequest guesty1 = new GuestRequest();
            GuestRequest guesty2 = new GuestRequest();

            guesty.EntryDate1 = new DateTime(2020, 7, 7);
            guesty.ReleaseDate1 = new DateTime(2020, 7, 15);
            guesty.PrivateName1 = "moshe";
            guesty.Children1 = 5;

            guesty1.EntryDate1 = new DateTime(2020, 5, 7);
            guesty1.ReleaseDate1 = new DateTime(2020, 7, 23);
            guesty1.PrivateName1 = "binyamin";
            guesty1.Children1 = 5;

            guesty2.EntryDate1 = new DateTime(2020, 5, 7);
            guesty2.ReleaseDate1 = new DateTime(2020, 6, 15);
            guesty2.PrivateName1 = "dovid";
            guesty2.Children1 = 5;

            try
            {
                bl.AddGuestRequest(guesty);
                bl.AddGuestRequest(guesty1);
                bl.AddGuestRequest(guesty2);

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

           try
            {
                bl.DeleteGuestRequest(guesty1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            foreach (GuestRequest i in bl.GetAllGuestRequest())
            {
                Console.WriteLine(i);
            }
            #endregion

            Console.ReadKey();
        }
    }
}
