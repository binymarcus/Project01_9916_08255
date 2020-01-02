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
            */
            foreach (GuestRequest i in bl.GetAllGuestRequest())
            {
                Console.WriteLine(i);
            }
            #endregion
            #region hosting unit tests
            HostingUnit unit1 = new HostingUnit();
            HostingUnit unit2 = new HostingUnit();
            HostingUnit unit3 = new HostingUnit();
            unit1.AreaOfHostingUnit = BEEnum.Area.All;
            unit2.AreaOfHostingUnit = BEEnum.Area.Center;
            unit3.AreaOfHostingUnit = BEEnum.Area.North;
            unit1.hasChildrensAttractions1 = true;
            unit2.hasJaccuzzi1 = true;
            unit3.hasPool1 = true;
            unit1.Owner1 = new Host();
            unit2.Owner1 = new Host();
            unit3.Owner1 = new Host();
            try
            {
                bl.AddHostingUnit(unit1);
                bl.AddHostingUnit(unit2);
                bl.AddHostingUnit(unit3);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                foreach (var item in bl.GetAllHostingUnits())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            unit1.HostingUnitName1 = "zimmer";
            unit2.hasPool1 = true;
            unit3.HostingUnitName1 = "jimmering";
            try
            {
                foreach (var item in bl.GetAllHostingUnits())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try
            {
                bl.UpdateHostingUnit(unit1);
                bl.UpdateHostingUnit(unit2);
                bl.UpdateHostingUnit(unit3);

            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try
            {
                foreach (var item in bl.GetAllHostingUnits())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try
            {
                bl.DeleteHostingUnit(unit2);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            try
            {
                foreach (var item in bl.GetAllHostingUnits())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            #endregion
            Console.ReadKey();
        }
    }
}
