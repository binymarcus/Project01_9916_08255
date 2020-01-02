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
            try
            {
                Console.WriteLine("_________________________________________________________________________\n" +
                    " All Guest Requests:");
                foreach (GuestRequest i in bl.GetAllGuestRequest())
                {
                    Console.WriteLine(i);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
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
            Host parp = new Host();
            bl.AddHost(parp);
            unit1.Owner1 = parp;
            unit2.Owner1 = new Host();
            unit3.Owner1 = parp;
           
            try//test for  adding hosting units
            {
                bl.AddHostingUnit(unit1);
                bl.AddHostingUnit(unit2);
                bl.AddHostingUnit(unit3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try//test for getAllHostingUnits after adding
            {
                Console.WriteLine(" _________________________________________________________________________\n All Hosting Units:");
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
            try//test to make sure the original didnt changewithout update
            {
                Console.WriteLine(" _________________________________________________________________________\n All Hosting Units:");
                foreach (var item in bl.GetAllHostingUnits())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try//test to make sure update works
            {
                bl.UpdateHostingUnit(unit1);
                bl.UpdateHostingUnit(unit2);
                bl.UpdateHostingUnit(unit3);

            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try//printing out to see if update works
            {
                Console.WriteLine(" _________________________________________________________________________\n All Hosting Units:");
                foreach (var item in bl.GetAllHostingUnits())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try//tets for delete hosting unit
            {
                bl.DeleteHostingUnit(unit2);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            try//printing to see if deleted one was printed
            {
                Console.WriteLine(" _________________________________________________________________________\n All Hosting Units:");
                foreach (var item in bl.GetAllHostingUnits())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            HostingUnit unit4 = new HostingUnit();
            unit4.AreaOfHostingUnit = BEEnum.Area.Jerusalem;
            unit4.Owner1 = new Host();
            bl.AddHostingUnit(unit4);
            try//basic test for grouping, may be cn=hanged
            {
                Console.WriteLine(" _________________________________________________________________________\n Areas that exist in the hosting units");

                foreach (var item in bl.GroupByAreaOfHostingUnit())
                {
                    Console.WriteLine(item.Key.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try//test for calcnumofhosts, using parp which is in two seperate hosting units , set higher inthe code
            {
                Console.WriteLine(" _________________________________________________________________________\n Test for number of hosting units in one host");

                bl.CalcNumOfHostingUnits();
                Console.WriteLine(parp.NumOfHostinUnits1);
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try// test for the function all units with attractions
            {
                Console.WriteLine("_________________________________________________________________________\n All units with children attractions:");
                foreach (var item in bl.allUnitsWithchildrensattractions())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            #endregion
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();
            order1.GuestRequestKey1 = guesty.GuestRequestKey1;
            order1.HostingUnitKey1 = unit1.HostingUnitKey1;
            order2.GuestRequestKey1 = guesty.GuestRequestKey1;
            order2.HostingUnitKey1 = unit3.HostingUnitKey1;
            order3.GuestRequestKey1 = guesty.GuestRequestKey1;
            order3.HostingUnitKey1 = unit4.HostingUnitKey1;

            try
            {
                bl.AddOrder(order1);
                bl.AddOrder(order2);


            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try
            {
                Console.WriteLine(" _________________________________________________________________________\n All Orders :");

                foreach (var item in bl.GetAllOrders())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            order1.Status1 = BEEnum.Status.mailSent;
            unit1.Owner1.CollectionClearance1 = true;
            order2.Status1 = BEEnum.Status.dealMade;
            try
            {
                bl.UpdateOrder(order1);
                bl.UpdateOrder(order2);
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try
            {
                Console.WriteLine(" _________________________________________________________________________\n All Orders :");

                foreach (var item in bl.GetAllOrders())
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
                Console.WriteLine(" _________________________________________________________________________\n All Orders older than x :");

                foreach (var item in bl.OlderOrders(0))
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                Console.WriteLine(" _________________________________________________________________________");

                Console.WriteLine("number of orders sent to this guest suggestion: "+bl.GuestOrderSuggestions(guesty));
            }
            catch (Exception e)
            {

                Console.WriteLine(e); ;
            }
            try
            {
                Console.WriteLine(" _________________________________________________________________________\n All the Banks :");

                foreach (var item in bl.GetAllBanks())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e); 
            }
            Console.ReadKey();
        }
    }
}