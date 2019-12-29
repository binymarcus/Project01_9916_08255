using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;
using DS;

namespace BL
{
    public class IBL_imp : IBL
    {
        #region
        ///ibl logic///
        public bool CanOrder(GuestRequest guestRequest)
        {
            if (guestRequest.EntryDate1.DayOfYear <= guestRequest.ReleaseDate1.DayOfYear)
                return false;
            return true;
         }
        #endregion

        ///<summary>
        /// geta a method of checking the orders and returns all the orders that fit that method
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public List<Order> AllOrdersByCriteria(Delegate check)
        {
            List<Order> L = new List<Order>();
            var v = from item in dal.GetAllOrders()
                    where 
                    select item;

            if (v.Count() == 0)
                throw new Exception("There are no orders by this criteria");
            foreach (var item in v)
            {
                L.Add(item);
            }
            return L;
        }
        /// <summary>
        /// function recieves either two dates and calculates the time betweeen them, or one and calculates from the present 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int calcNumOfDaysBetween(params DateTime[] num)
        {
            int sum = 0;
            if (num.Length==2)
            {//this may have to change according to lenth of the actual months
                
                    sum += Math.Abs(num[0].Day - num[1].Day);
                sum += Math.Abs(30 * (num[0].Month - num[1].Month)); 
            }
            else //if only one date is sent to func
            {//this may have to change according to lenth of the actual months
                DateTime today = DateTime.Today;
                sum += Math.Abs(today.Day - num[0].Day);
                sum += Math.Abs(30 * (today.Month - num[0].Month));
            }
            return sum;
        }
        /// <summary>
        /// calculates the end date of a stay
        /// </summary>
        /// <param name="start"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public DateTime CalcEndDate(DateTime start, int num)
        {
            DateTime endDate = start.AddDays(num);
            return endDate;
        }
        /// <summary>
        /// checks for free units a a spacifec time ???(is this correct?)
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="numOfDaysForVacatrion"></param>
        /// <returns></returns>
        public List<HostingUnit> FreeUnits(DateTime startdate, int numOfDaysForVacatrion)
        {
            List<HostingUnit> L=new List<HostingUnit>();
            DateTime end = CalEndDate(startdate, numOfDaysForVacatrion);
             var v = from item in dal.GetAllHostingUnits()
                    where checkDates(startdate,end,item)==true
                             select item;

            if (v.Count() == 0)
                throw new Exception("There are no Free units in these dates");
            foreach (var item in v)
            {
                L.Add(item);
            }
            return L;

        }
        /// <summary>
        /// checks if dates are occupied or vacent
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        public bool checkDates(DateTime start, DateTime end, HostingUnit host)
        {

            for (int i = start.Month; i <= end.Month; i++)
            {
                int j;
                if (i == start.Month)
                    j = start.Day;
                else j = 0;
                for (; j < end.Day; j++)
                {
                    if (host.Diary1[i, j] == true)
                        return false;

                }
            }
            return true;
        }
        /// <summary>
        /// returns all the orders that are equall or older than the number of days received
        /// </summary>
        /// <param name="numOfDays">integer for the number of days</param>
        /// <returns></returns>
        public List<Order> OlderOrders(int numOfDays)
        {
            List<Order> L = new List<Order>();
            var v = from item in dal.GetAllOrders()
                    where DateTime.Today.DayOfYear-item.OrderDate1.DayOfYear>=numOfDays
                    select item;
            foreach (var item in v)
            {
                L.Add(item);
            }
            return L;

        }
        /// <summary>
        /// the function recieves a guest request and returns the number of orders sent to it.
        /// </summary>
        /// <param name="guest"></param>
        /// <returns>returns the number of orders sent</returns>
        public int GuestOrderSuggestions(GuestRequest guest) //not implamented
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// returns the number of orders sent to guests or orders filled out
        /// </summary>
        /// <param name="hosting"></param>
        /// <returns></returns>
        public int HostingUnitOrdersFilled(HostingUnit hosting)
        {
            throw new NotImplementedException();
        } //not implamented

        /************the next few functions are using grouping***********/

        public List<HostingUnit> GroupByAreaOfHostingUnit()//grouping
        {
            var v = from item in DataSource.HostingUnitList
                    group item by item.areaOfHOstingUnit1;
            return v;
        }
        /// <summary>
        /// returns guestrequests groups by num of guests
        /// </summary>
        /// <returns></returns>
        public List<GuestRequest> GroupedByNumOfGuests()//grouping
        {
            var v = from item in DataSource.GuestRequestList
                    group item by item.TotalGuests1;
            return v;
        }
        /// <summary>
        /// returns hosts by number of hosting units they have
        /// </summary>
        /// <returns></returns>
        public List<Host> groupedByNumOfhostingUnits()//grouping
        {
            dal.calcNumOfHostinUnits(); //call function
            var v = from item in DataSource.HostList
                    group item by item.NumOfHostinUnits1;
            return v;
        }
        /// <summary>
        /// returns guest requests groups by area
        /// </summary>
        /// <returns></returns>
        public List<GuestRequest> GroupedByAreaOfGuestRequest()//grouping
        {
            var v = from item in DataSource.GuestRequestList
                    group item by item.area1;
            return v;
        }
      
       
    }
}
