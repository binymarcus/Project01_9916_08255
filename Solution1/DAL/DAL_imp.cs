using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DS;
using MyException;

namespace DAL
{
    public class DAL_imp : Idal
    {
        #region Add
        /// <summary>
        /// adds a request for service from a client to the system
        /// </summary>
        /// <param name="guestRequest"></param>
        public void AddGuestRequest(GuestRequest guestRequest)
        {//TODO: need to put try and catch
            guestRequest.GuestRequestKey1 = Configuration.GuestRequestKey++;
            DataSource.GuestRequestList.Add(Cloning.Clone(guestRequest));
        }
        /// <summary>
        /// adds a hosting unit to the system|throw error if hosting unit already exists
        /// </summary>
        /// <param name="hostingUnit"> the hosting unit from BE</param>
        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            hostingUnit.HostingUnitKey1 = ++Configuration.HostingUnitKey;
            DataSource.HostingUnitList.Add(Cloning.Clone(hostingUnit));
        }
        /// <summary>
        /// adds an order from a client to the system|throws error if order already exists
        /// </summary>
        /// <param name="order">Order defined in BE</param>
        public void AddOrder(Order order)
        {          
                order.OrderKey1 = Configuration.OrderKey++;
                DataSource.OrderList.Add(Cloning.Clone(order));
        }
        #endregion
        #region Update 
        /// <summary>
        /// updates a request of a client thats already in the system
        /// </summary>
        /// <exception cref="KeyNotFoundException">throws excpetion if key not found</exception>
        /// <param name="guestRequest"></param>
        public void UpdateGuestRequest(GuestRequest guestRequest)
        {
            var v = from item in DataSource.GuestRequestList
                    where item.GuestRequestKey1 == guestRequest.GuestRequestKey1
                    select item;

            if (v.Count() == 0)
                throw new KeyNotFoundException("GuestRequest key does not exist");

            DataSource.GuestRequestList.Remove(guestRequest);
            DataSource.GuestRequestList.Add(Cloning.Clone(guestRequest));
        }
        /// <summary>
        /// updates the information on an existing hosting unit|throws error if unit doesnt exist
        /// </summary>
        /// <exception cref="KeyNotFoundException">throws excpetion if key not found</exception>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {//TODO: need to put try and catch
            var v = from item in DataSource.HostingUnitList
                    where item.HostingUnitKey1 == hostingUnit.HostingUnitKey1
                    select item;

            if (v.Count() == 0)
                throw new Exception("hosting unit  does not exist");

            DataSource.HostingUnitList.Remove(hostingUnit);
            DataSource.HostingUnitList.Add(Cloning.Clone(hostingUnit));
        }
        public HostingUnit updateDiary(HostingUnit host, GuestRequest guest)
        {

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
                    host.Diary1[i, j] = true;
                }
            }
            return host;
        }
        /// <summary>
        /// updates the terms of an order from a client|throws error if order already exists
        /// </summary>     
        /// <exception cref="KeyNotFoundException">throws excpetion if key not found</exception>
        /// <param name="order">Order defined in BE</param>
        public void UpdateOrder(Order order)
        {//TODO: need to put try and catch

            DataSource.OrderList.Remove(order);
            DataSource.OrderList.Add(Cloning.Clone(order));

        }
        #endregion
        #region Delete
        /// <summary>
        /// deletes an existing guest request
        /// </summary>
        /// <exception cref="KeyNotFoundException">throws excpetion if key not found</exception>
        /// <param name="guestRequest"></param>
        public void DeleteGuestRequest(GuestRequest guestRequest)
        {//TODO: need to put try and catch
            var v = from item in DataSource.GuestRequestList
                where item.GuestRequestKey1 == guestRequest.GuestRequestKey1
                select item;

                if (v.Count() == 0)
                    throw new KeyNotFoundException("GuestRequest key not found");
           
                DataSource.GuestRequestList.Remove(guestRequest);
        }

        /// <summary>
        /// removes an existing hosting unit from the system
        /// </summary>
        /// <exception cref="KeyNotFoundException">throws excpetion if key not found</exception>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        public void DeleteHostingUnit(HostingUnit hostingUnit)
        {//TODO: need to put try and catch
            var v = from item in DataSource.HostingUnitList
                    where item.HostingUnitKey1 == hostingUnit.HostingUnitKey1
                    select item;

            if (v.Count() == 0)
                throw new Exception("GuestRequest key does not exist");

            DataSource.HostingUnitList.Remove(hostingUnit);
        }
        #endregion
        #region Get
        /// <summary>
        /// finds and returns a list of all the hosting units in the sytem
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <returns>all the hosting units in the system</returns>
        public List<HostingUnit> GetAllHostingUnits()
        {
            List<HostingUnit> L = new List<HostingUnit>();
            foreach (var item in DataSource.HostingUnitList)
                L.Add(Cloning.Clone(item));
            if (L.Count() == 0)
                throw new NoItemsFound("There are no hosting units in the system");
            return L;
        }
        /// <summary>
        /// shows all clients currently in the system
        /// </summary>
       /// <exception cref="NoItemsFound"></exception>
        /// <returns>List of the Clients in the system-by request</returns>
        public List<GuestRequest> GetAllGuestRequest()//this may need to change from guest request
        {

            List<GuestRequest> L = new List<GuestRequest>();
            foreach (var item in DataSource.GuestRequestList)
                L.Add(Cloning.Clone(item));
            if (L.Count() == 0)
                throw new NoItemsFound("There are no guest requests in the system");
            return L;
        }
        /// <summary>
        /// gets all the orders in the system
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <returns><list of the Orders/returns>
        public List<Order> GetAllOrders()
        {
            List<Order> L = new List<Order>();
            foreach (var item in DataSource.OrderList)
                L.Add(Cloning.Clone(item));
            if (L.Count() == 0)
                throw new NoItemsFound("There are no orders in the system");
            return L;
        }
        /// <summary>
        /// reutrns all the banks
        /// </summary>
        /// <returns></returns>
        public List<BankBranch> GetAllBanks()
        {
            List<BankBranch> L = new List<BankBranch>
            {
             new BankBranch("leumi" , 1, 1, "begin 1", "jerusalem"),
             new BankBranch("diskont" , 1, 2,"sunest 2", "jerusalem"),
             new BankBranch("hapolim" , 1, 3, "green 3", "efrat"),
             new BankBranch("leumi" , 1, 4, "begin 4", "jerusalem"),
             new BankBranch("leumi" , 1, 5, "begin 5", "jerusalem")
            };

            return L;
        }
        /// <summary>
        /// finds the order by its key
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="key"></param>
        /// <returns>Order</returns>
        public Order GetOrderByKey(long key)
        {
            foreach (var item in GetAllOrders())
            {
                if (key == item.OrderKey1)
                    return item;
            }
            throw new NoItemsFound("The order does not exist!");
        }
        /// <summary>
        /// returns the guest request by its key
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="key"></param>
        /// <returns></returns>
        public GuestRequest GetGuestRequestByKey(long key)
        {
            foreach (var item in GetAllGuestRequest())
            {
                if (key == item.GuestRequestKey1)
                    return item;
            }
            throw new NoItemsFound("the guest request does not exist");
        }
        /// <summary>
        /// returns the hosting unit by its key
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="key"></param>
        /// <returns></returns>
        public HostingUnit GetHostingUnitByKey(long key)
        {
            foreach (var item in GetAllHostingUnits())
            {
                if (key == item.HostingUnitKey1)
                    return item;
            }
            throw new NoItemsFound("the hosting unit does not exist");

        }
        #endregion

        /// <summary>
        /// sets num of hosting units each host has
        /// </summary>
        /// <returns></returns>
        public void CalcNumOfHostingUnits()
        {
              foreach (var item1 in DataSource.HostList)
              {
                item1.NumOfHostinUnits1 = 0;
                     foreach (var item2 in DataSource.HostingUnitList)
                     {
                           if(item1.HostKey1 == item2.Owner1.HostKey1)
                               item1.NumOfHostinUnits1++;
                     }
              }
        }

       
       

    }
}

