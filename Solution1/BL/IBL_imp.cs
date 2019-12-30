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
            List<HostingUnit> L = new List<HostingUnit>();
            DateTime end = CalEndDate(startdate, numOfDaysForVacatrion);
            var v = from item in dal.GetAllHostingUnits()
                    where checkDates(startdate, end, item) == true
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
                    where DateTime.Today.DayOfYear - item.OrderDate1.DayOfYear >= numOfDays
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
        public int HostingUnitOrdersFilled(HostingUnit hosting) //not implamented
        {
            throw new NotImplementedException();
        }

        /************the next few functions are using grouping***********/
        public List<IGrouping<BEEnum.Area, GuestRequest>> GroupedByAreaOfGuestRequest()//grouping
        {
            var v = from item in FactoryDAL.getDAL().GetAllGuestRequest()
                    group item by item.area1;

            return v.ToList();
        }
        public List<IGrouping<BEEnum.Area, HostingUnit>> GroupByAreaOfHostingUnit()//grouping
        {
            var v = from item in FactoryDAL.getDAL().GetAllHostingUnits()
                    group item by item.areaOfHostingUnit;
            return v.ToList();
        }
        /// <summary>
        /// returns guestrequests groups by num of guests
        /// </summary>
        /// <returns></returns>
        public List<IGrouping<int, GuestRequest>> GroupedByNumOfGuests()//grouping
        {
            var v = from item in FactoryDAL.getDAL().GetAllGuestRequest()
                    group item by item.TotalGuests1;
            return v.ToList();
        }
        /// <summary>
        /// returns hosts by number of hosting units they have
        /// </summary>
        /// <returns></returns>
        public List<IGrouping<int, Host>> groupedByNumOfhostingUnits()//grouping
        {
            CalcNumOfHostingUnits(); //call function
            var v = from item in DataSource.HostList
                    group item by item.NumOfHostinUnits1;
            return v.ToList();
        }
        /**************end of grouping*************/
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            if (guestRequest.EntryDate1 >= guestRequest.ReleaseDate1)
                throw new UnexceptableDetailsException("Entry date must be at least one day before exit date.");
            try
            {
                FactoryDAL.getDAL().AddGuestRequest(guestRequest);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddOrder(Order order)
        {
            if (order.Status==BEEnum.Status.ClosedByClientResponse|| order.Status == BEEnum.Status.closedByClientsLackOfResponse)
            {
                throw new UnexceptableDetailsException("order cannot be closed.");
            }
            try
            {
                FactoryDAL.getDAL().AddOrder(order);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            if (hostingUnit.Owner1 == null)
                throw new UnexceptableDetailsException("All hosting units must have an owner");
            try
            {
                FactoryDAL.getDAL().AddHostingUnit(hostingUnit);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateGuestRequest(GuestRequest guestRequest)
        {
            if (guestRequest.EntryDate1 >= guestRequest.ReleaseDate1)
                throw new UnexceptableDetailsException("Entry date must be at least one day before exit date.");
            try
            {
                FactoryDAL.getDAL().UpdateGuestRequest(guestRequest);
            }
            catch (Exception)
            {
              throw;
            }
        }
        public void UpdateOrder(Order order)
        {          
            if( FactoryDAL.getDAL().GetOrderByKey(order.OrderKey1).Status==BEEnum.Status.mailSent)//may need to change it from mail sent
            {
                throw new UnexceptableDetailsException("order cannot be changed once deal is closed.");
            }
            try
            {

                if (order.Status == BEEnum.Status.mailSent&& FactoryDAL.getDAL().GetOrderByKey(order.OrderKey1).Status!= BEEnum.Status.mailSent)
                {
                   Configuration.commmission+=10* calcNumOfDaysBetween(FactoryDAL.getDAL().GetGuestRequestByKey(order.GuestRequestKey1).EntryDate1, FactoryDAL.getDAL().GetGuestRequestByKey(order.GuestRequestKey1).ReleaseDate1) ;//dont knwo what to do with this
                   UpdateHostingUnit(FactoryDAL.getDAL().GetHostingUnitByKey(order.HostingUnitKey1).)
                }
                FactoryDAL.getDAL().UpdateOrder(order);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            if (hostingUnit.Owner1==null)//may need to change it from mail sent
            {
                throw new UnexceptableDetailsException("order cannot be changed once deal is closed.");
            }
            try
            {
                FactoryDAL.getDAL().UpdateOrder(order);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteGuestRequest(GuestRequest guestRequest)
        {
            throw new NotImplementedException();
        }

        public void DeleteHostingUnit(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }




        public List<HostingUnit> GetAllHostingUnits()
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> GetAllGuestRequest()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<BankBranch> GetAllBanks()
        {
            throw new NotImplementedException();
        }

        public void CalcNumOfHostingUnits()
        {
            throw new NotImplementedException();
        }

        public int calcNumOfDaysBetween(params DateTime[] num)
        {
            int sum = 0;
            if (num.Length == 2)
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


    }
}

