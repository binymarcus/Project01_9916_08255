using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;
using DS;
using MyException;

namespace BL
{
    public class IBL_imp : IBL
    {
        Idal dal = FactoryDAL.getDAL();

        ///<summary>
        /// geta a method of checking the GuestRequests and returns all the GuestRequests that fit that method
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="check"></param>
        /// <returns></returns>
        public List<GuestRequest> AllOrdersByCriteria(Predicate<GuestRequest> check)//used FUNC as Predicate as requested
        {
            List<GuestRequest> L = new List<GuestRequest>();
            var v = from item in dal.GetAllGuestRequest()
                    where check(item)
                    select item;

            if (v.Count() == 0)
                throw new NoItemsFound("There are no GuestRequests by this criteria");
            foreach (var item in v)
            {
                L.Add(item);
            }
            return L;
        }
        /// <summary>
        /// checks for free units a a spacifec time ???(is this correct?)
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="startdate"></param>
        /// <param name="numOfDaysForVacatrion"></param>
        /// <returns></returns>
        /// 
        public List<HostingUnit> FreeUnits(DateTime startdate, int numOfDaysForVacatrion)
        {
            
            List<HostingUnit> L = new List<HostingUnit>();
             DateTime end = FactoryBL.getIBL().CalcEndDate(startdate, numOfDaysForVacatrion);
             var v = from item in dal.GetAllHostingUnits()
                     where checkDates(startdate, end, item) == true
                     select item;


             if (v.Count() == 0)
                 throw new NoItemsFound("There are no Free units in these dates");
             foreach (var item in v)
             {
                 L.Add(item);
             }
             return L;

        }
        /// <summary>
        /// checks if dates are occupied or vacant
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
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="numOfDays">integer for the number of days</param>
        /// <returns></returns>
        public List<Order> OlderOrders(int numOfDays)
        {
            List<Order> L = new List<Order>();
            
                var v = from item in dal.GetAllOrders()
                        where (DateTime.Today.DayOfYear - item.OrderDate1.DayOfYear >= numOfDays) || (DateTime.Today.DayOfYear - item.CreateDate1.DayOfYear >= numOfDays)
                        select item;

                foreach (var item in v)
                {
                    L.Add(item);
                    item.Status1 = BEEnum.Status.closedByClientsLackOfResponse;
                    UpdateOrder(item);
                }
                if (L.Count() == 0)
                    throw new NoItemsFound("There are no orders older then the number of days sent.");
                return L;
            

        }
        /// <summary>
        /// the function recieves a guest request and returns the number of orders sent to it.
        /// </summary>
        /// <param name="guest"></param>
        /// <returns>returns the number of orders sent</returns>
        public int GuestOrderSuggestions(GuestRequest guest)
        {
            int sum = 0;
            foreach (var item in dal.GetAllOrders())
            {
                if (item.GuestRequestKey1 == guest.GuestRequestKey1 &&( item.Status1 == BEEnum.Status.mailSent||item.Status1==BEEnum.Status.dealMade))
                {
                    sum++;
                }
            }
            return sum;
        }
        /// <summary>
        /// returns the number of orders sent to guests or orders filled out
        /// </summary>
        /// <param name="hosting"></param>
        /// <returns></returns>
        public int HostingUnitOrdersFilled(HostingUnit hosting) 
        {
            var v = GetAllOrders().FindAll(x => x.HostingUnitKey1 == hosting.HostingUnitKey1);
            return v.Count();
        }
        #region grouping
        public List<IGrouping<BEEnum.Area, GuestRequest>> GroupedByAreaOfGuestRequest()//grouping
        {
            var v = from item in dal.GetAllGuestRequest()
                    group item by item.area1;

            return v.ToList();
        }
        public List<IGrouping<BEEnum.Area, HostingUnit>> GroupByAreaOfHostingUnit()//grouping
        {
            var v = from item in dal.GetAllHostingUnits()
                    group item by item.AreaOfHostingUnit;
            return v.ToList();
        }
        /// <summary>
        /// returns guestrequests groups by num of guests
        /// </summary>
        /// <returns></returns>
        public List<IGrouping<int, GuestRequest>> GroupedByNumOfGuests()//grouping
        {
            var v = from item in dal.GetAllGuestRequest()
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
        #endregion

        #region add
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            if (guestRequest.EntryDate1 >= guestRequest.ReleaseDate1)
                throw new UnexceptableDetailsException("Entry date must be at least one day before exit date.");
            try
            {
                dal.AddGuestRequest(guestRequest);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddOrder(Order order)
        {
            if (order.Status1 == BEEnum.Status.dealMade || order.Status1 == BEEnum.Status.closedByClientsLackOfResponse || order.Status1 == BEEnum.Status.dealMadeWithOtherHost)
            {
                throw new UnexceptableDetailsException("order cannot be closed.");
            }
            if (!canOrder(order))
                throw new UnexceptableDetailsException("we are sorry, but the dates are unavaileble. please visit us another time.");
            try
            {
                order.CreateDate1 = DateTime.Now;
                dal.AddOrder(order);
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
                dal.AddHostingUnit(hostingUnit);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddHost(Host host)
        {
            try
            {
                dal.AddHost(host);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #endregion

        #region update
        public void UpdateGuestRequest(GuestRequest guestRequest)
        {
            if (guestRequest.EntryDate1 >= guestRequest.ReleaseDate1)
                throw new UnexceptableDetailsException("Entry date must be at least one day before exit date.");
            try
            {
                dal.UpdateGuestRequest(guestRequest);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateOrder(Order order)
        {         //if closed then closed, doesnt matter how 
            if (dal.GetOrderByKey(order.OrderKey1).Status1 == BEEnum.Status.dealMade || dal.GetOrderByKey(order.OrderKey1).Status1 == BEEnum.Status.dealMadeWithOtherHost || dal.GetOrderByKey(order.OrderKey1).Status1 == BEEnum.Status.closedByClientsLackOfResponse)//may need to change it from mail sent
            {
                throw new UnexceptableDetailsException("order cannot be changed once deal is closed.");
            }
            try
            {

                if (order.Status1 == BEEnum.Status.dealMade)
                {
                    GuestRequest temp = dal.GetGuestRequestByKey(order.GuestRequestKey1);
                    HostingUnit hosting = dal.GetHostingUnitByKey(order.HostingUnitKey1);
                    hosting.Commission1= Configuration.commmission * calcNumOfDaysBetween(temp.EntryDate1, temp.ReleaseDate1);//dont knwo what to do with this
                    UpdateHostingUnit(dal.updateDiary(hosting, dal.GetGuestRequestByKey(order.GuestRequestKey1)));
                    temp.status1 = order.Status1;
                    UpdateGuestRequest(temp);
                    foreach (var item in dal.GetAllOrders())
                    {
                        if (item.GuestRequestKey1 == order.GuestRequestKey1)
                            item.Status1 = order.Status1;
                    }
                }
                if (order.Status1 == BEEnum.Status.mailSent && dal.GetHostingUnitByKey(order.HostingUnitKey1).Owner1.CollectionClearance1 == false)
                    throw new UnexceptableDetailsException("you can't send a mail, until you have signed a permission to charge the bank");

                //temporary till we learn how to send an email
                if (order.Status1 == BEEnum.Status.mailSent)
                {
                    order.OrderDate1 = DateTime.Now;
                    Console.WriteLine(" since there is no email we print the information\n" +order.ToString());
                }
                dal.UpdateOrder(order);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            if ((hostingUnit.Owner1.CollectionClearance1 == false) && (dal.GetHostingUnitByKey(hostingUnit.HostingUnitKey1).Owner1.CollectionClearance1 == true))
            {
                throw new UnexceptableDetailsException("unable to update hosting unit because you cant change clearence once cleared!");
            }
            try
            {
                dal.UpdateHostingUnit(hostingUnit);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region delete
        public void DeleteGuestRequest(GuestRequest guestRequest)
        {
            dal.DeleteGuestRequest(guestRequest);
        }
        public void DeleteHostingUnit(HostingUnit hostingUnit)
        {
            if (!checkdeletehosting(hostingUnit))
                throw new UnexceptableDetailsException("Cannot delete a hosting unit that has an active order.");
            dal.DeleteHostingUnit(hostingUnit);
        }
        #endregion

        #region Get
        public List<HostingUnit> GetAllHostingUnits()
        {
            try
            {
                return dal.GetAllHostingUnits();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public List<GuestRequest> GetAllGuestRequest()
        {
            try
            {
                return dal.GetAllGuestRequest();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public GuestRequest GetGuestRequestByKey(long key)
        {
            try
            {
                return dal.GetGuestRequestByKey(key);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public HostingUnit GetHostingUnitByKey(long key)
        {
            try
            {
                return dal.GetHostingUnitByKey(key);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<GuestRequest> GetallGuestRequestByName(string pname, string fname)
        {
            try
            {
                return dal.GetallGuestRequestByName(pname, fname);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Order> GetAllOrders()
        {
            try
            {
                return dal.GetAllOrders();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Host> GetAllHosts()
        {
            try
            {
                return dal.GetAllHosts();
            }
            catch (Exception)
            {

                throw;
            }    
        }
        
        public List<BankBranch> GetAllBanks()
        {
            try
            {
                return dal.GetAllBanks();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public List<Order> GetAllOrdersByHostKey(long hostkey)
        {
            try
            {
                return dal.GetAllOrdersByHostKey(hostkey);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        #endregion
        #region calc
        public void CalcNumOfHostingUnits()
        {
            try
            {
                dal.CalcNumOfHostingUnits();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// function recieves either two dates and calculates the time betweeen them, or one and calculates from the present 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        /// <summary>
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
        /// </summary>
        /// calculates the end date of a stay
        /// </summary>
        /// <param name="start"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public DateTime CalcEndDate(DateTime start, int num) //uses anonymous delegate
        {
            Func<DateTime, int, DateTime> _CalcEndDate = delegate (DateTime _start, int _num)
            {
                DateTime endDate = _start.AddDays(_num);
                return endDate;
            };

            return _CalcEndDate(start, num);

            /*DateTime endDate = start.AddDays(num);
            return endDate;*/
        }
        #endregion
        #region private functions for ibm_imp
        private bool canOrder(Order order)
        {
            HostingUnit host = dal.GetHostingUnitByKey(order.HostingUnitKey1);
            GuestRequest guest = dal.GetGuestRequestByKey(order.GuestRequestKey1);
            for (int i = guest.EntryDate1.Month; i <= guest.ReleaseDate1.Month; i++)
            {
                int j = 0;
                if (i == guest.EntryDate1.Month)
                    j = guest.EntryDate1.Day;
                int stop = 31;
                if (i == guest.ReleaseDate1.Month)
                    stop = guest.ReleaseDate1.Day;
                for (; j < stop; j++)
                {
                    if (host.Diary1[i, j] == true)
                        return false;
                }
            }
            return true;

        }
        private bool checkdeletehosting(HostingUnit hosty)
        {
            try
            {
                foreach (var item in dal.GetAllOrders())
                {
                    if (item.HostingUnitKey1 == hosty.HostingUnitKey1)
                        return false;
                }
            }
            catch
            {
                return true;
            }
            return true;
        }
        #endregion
        #region lists of hosting unit appliances
        public List<HostingUnit> allUnitsWithPools()
        {
            List<HostingUnit> L = new List<HostingUnit>();
            var v = from item in dal.GetAllHostingUnits()
                    where item.hasPool1
                    select item;
            foreach (var item in v)
            {
                L.Add(item);

            }

            return L;
        }
        public List<HostingUnit> allUnitsWithJaccuzzis()
        {

            List<HostingUnit> L = new List<HostingUnit>();
            var v = from item in dal.GetAllHostingUnits()
                    where item.hasJaccuzzi1
                    select item;
            foreach (var item in v)
            {
                L.Add(item);

            }

            return L;
        }
        public List<HostingUnit> allUnitsWithGardens()
        {

            List<HostingUnit> L = new List<HostingUnit>();
            var v = from item in dal.GetAllHostingUnits()
                    where item.hasGarden1
                    select item;
            foreach (var item in v)
            {
                L.Add(item);

            }

            return L;
        }
        public List<HostingUnit> allUnitsWithchildrensattractions()
        {

            List<HostingUnit> L = new List<HostingUnit>();
            var v = from item in dal.GetAllHostingUnits()
                    where item.hasChildrensAttractions1
                    select item;
            foreach (var item in v)
            {
                L.Add(item);

            }

            return L;
        }
        #endregion
        public HostingUnit findFirstBestUnitInArea(GuestRequest guest)
        {
            var v = dal.GetAllHostingUnits().FindAll(x => x.AreaOfHostingUnit == guest.area1);
            if (guest.ChildrensAttractions1 == BEEnum.Option.Must && guest.pool1 == BEEnum.Option.Must && guest.Jacuzzi1 == BEEnum.Option.Must && guest.Garden1 == BEEnum.Option.Must)
            {
                var l = v.FindAll(x => x.hasChildrensAttractions1 && x.hasGarden1 && x.hasJaccuzzi1 && x.hasPool1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            if (guest.ChildrensAttractions1 == BEEnum.Option.Must && guest.pool1 == BEEnum.Option.Must && guest.Jacuzzi1 == BEEnum.Option.Must && guest.Garden1 == BEEnum.Option.notInterested)
            {
                var l = v.FindAll(x => x.hasChildrensAttractions1 && !x.hasGarden1 && x.hasJaccuzzi1 && x.hasPool1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            if (guest.ChildrensAttractions1 == BEEnum.Option.Must && guest.pool1 == BEEnum.Option.Must && guest.Jacuzzi1 == BEEnum.Option.notInterested && guest.Garden1 == BEEnum.Option.Must)
            {
                var l = v.FindAll(x => x.hasChildrensAttractions1 && x.hasGarden1 && !x.hasJaccuzzi1 && x.hasPool1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            if (guest.ChildrensAttractions1 == BEEnum.Option.Must && guest.pool1 == BEEnum.Option.notInterested && guest.Jacuzzi1 == BEEnum.Option.Must && guest.Garden1 == BEEnum.Option.Must)
            {
                var l = v.FindAll(x => x.hasChildrensAttractions1 && x.hasGarden1 && x.hasJaccuzzi1 && !x.hasPool1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            if (guest.ChildrensAttractions1 == BEEnum.Option.notInterested && guest.pool1 == BEEnum.Option.Must && guest.Jacuzzi1 == BEEnum.Option.Must && guest.Garden1 == BEEnum.Option.Must)
            {
                var l = v.FindAll(x => !x.hasChildrensAttractions1 && x.hasGarden1 && x.hasJaccuzzi1 && x.hasPool1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            if (guest.ChildrensAttractions1 == BEEnum.Option.Must && guest.pool1 == BEEnum.Option.Optional && guest.Jacuzzi1 == BEEnum.Option.Must && guest.Garden1 == BEEnum.Option.Must)
            {
                var l = v.FindAll(x => x.hasChildrensAttractions1 && x.hasGarden1 && x.hasJaccuzzi1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            if (guest.ChildrensAttractions1 == BEEnum.Option.Must && guest.pool1 == BEEnum.Option.Must && guest.Jacuzzi1 == BEEnum.Option.Optional && guest.Garden1 == BEEnum.Option.Must)
            {
                var l = v.FindAll(x => x.hasChildrensAttractions1 && x.hasGarden1 && x.hasPool1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            if (guest.ChildrensAttractions1 == BEEnum.Option.Must && guest.pool1 == BEEnum.Option.Must && guest.Jacuzzi1 == BEEnum.Option.Must && guest.Garden1 == BEEnum.Option.Optional)
            {
                var l = v.FindAll(x => x.hasChildrensAttractions1 && x.hasJaccuzzi1 && x.hasPool1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            if (guest.ChildrensAttractions1 == BEEnum.Option.Optional && guest.pool1 == BEEnum.Option.Must && guest.Jacuzzi1 == BEEnum.Option.Must && guest.Garden1 == BEEnum.Option.Must)
            {
                var l = v.FindAll(x => x.hasGarden1 && x.hasJaccuzzi1 && x.hasPool1);
                if (l.Count == 0)
                {
                    throw new UnexceptableDetailsException("There are no hosting units that meet your demands in your area");
                }
                return l.First();

            }
            return v.First();
        }

     
         public Order findLongestOrderPending()
         {
             var v = dal.GetAllOrders().FindAll(x => x.Status1 == BEEnum.Status.pending);
             Order longest = v.First();
             foreach (var item in v)
             {
                 if (item.OrderDate1.DayOfYear < longest.OrderDate1.DayOfYear)
                     longest = item;
             }
             return longest;
         }

        public HostingUnit GetHostingUnitByName(string name)
        {

            try
            {
                return dal.GetHostingUnitByName(name);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public List<HostingUnit> GetAllHostingUnitsByHostKey(long key1)
        {
            try
            {
                return dal.GetAllHostingUnitsByHostKey(key1);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

