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
        #region add
        /// <summary>
        /// adds a request for service from a client to the system
        /// </summary>
        /// <param name="guestRequest"></param>
        public void AddGuestRequest(GuestRequest guestRequest)
        {//TODO: need to put try and catch
            guestRequest.GuestRequestKey1 = Configuration.GuestRequestKey++;
            guestRequest.RegistrationDate1 = DateTime.Now;
            DataSource.GuestRequestList.Add(Cloning.Clone(guestRequest));
        }
        /// <summary>
        /// adds a hosting unit to the system
        /// </summary>
        /// <param name="hostingUnit"> the hosting unit from BE</param>
        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            try
            {
                foreach (var item in GetAllHostingUnits())
                {
                    if (item.HostingUnitName1 == hostingUnit.HostingUnitName1)
                        throw new UnexceptableDetailsException("cannot enter two hosting units with the same name");
                }
            }
            catch
            {

            }
            finally
            {
                hostingUnit.HostingUnitKey1 = Configuration.HostingUnitKey++;
                DataSource.HostingUnitList.Add(Cloning.Clone(hostingUnit));
            }
        }
        /// <summary>
        /// adds an order from a client to the system
        /// </summary>
        /// <param name="order">Order defined in BE</param>
        public void AddOrder(Order order)
        {
            order.CreateDate1 = DateTime.Now;
            order.OrderKey1 = Configuration.OrderKey++;
            DataSource.OrderList.Add(Cloning.Clone(order));

        }
        /// <summary>
        /// adds a host to the system
        /// </summary>
        /// <param name="host">Host defined in BE</param>
        public void AddHost(Host host)
        {
            host.HostKey1 = Configuration.HostKey++;
            DataSource.HostList.Add(Cloning.Clone(host));
        }
        #endregion

        #region update
        /// <summary>
        /// updates a request of a client thats already int the system
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="guestRequest"></param>
        public void UpdateGuestRequest(GuestRequest guestRequest)
        {
            GuestRequest cloned = Cloning.Clone(guestRequest);

            var v = from item in DataSource.GuestRequestList
                    where item.GuestRequestKey1 == cloned.GuestRequestKey1
                    select item;

            if (v.Count() == 0)
                throw new KeyNotFoundException("GuestRequest key does not exist");

            foreach (var item in v.ToList())
            { DataSource.GuestRequestList.Remove(item); }
            //DataSource.GuestRequestList.Remove(guestRequest);
            DataSource.GuestRequestList.Add(Cloning.Clone(guestRequest));
        }
        /// <summary>
        /// updates the information on an existing hosting unit|throws error if unit doesnt exist
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            var v = from item in DataSource.HostingUnitList
                    where item.HostingUnitKey1 == hostingUnit.HostingUnitKey1
                    select item;

            if (v.Count() == 0)
                throw new NoItemsFound("hosting unit  does not exist");

            foreach (var item in v.ToList())
            { DataSource.HostingUnitList.Remove(item); }
            //DataSource.HostingUnitList.Remove(hostingUnit);
            DataSource.HostingUnitList.Add(Cloning.Clone(hostingUnit));
        }
        /// <summary>
        /// updates the terms of an order from a client|throws error if order already exists
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="order">Order defined in BE</param>
        public void UpdateOrder(Order order)
        {//TODO: need to put try and catch
            var v = from item in DataSource.OrderList
                    where item.OrderKey1 == order.OrderKey1
                    select item;

            if (v.Count() == 0)
                throw new NoItemsFound("hosting unit  does not exist");
            foreach (var item in v.ToList())
            { DataSource.OrderList.Remove(item); }
            //DataSource.OrderList.Remove(order);
            DataSource.OrderList.Add(Cloning.Clone(order));

        }
        #endregion

        #region delete
        /// <summary>
        /// deletes an existing guest request
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="guestRequest"></param>
        public void DeleteGuestRequest(GuestRequest guestRequest)
        {//TODO: need to put try and catch
            var v = from item in DataSource.GuestRequestList
                    where item.GuestRequestKey1 == guestRequest.GuestRequestKey1
                    select item;
            var a = from item in DataSource.OrderList
                    where item.GuestRequestKey1 == guestRequest.GuestRequestKey1
                    select item;
            if (v.Count() == 0)
                throw new KeyNotFoundException("GuestRequest key not found");

            foreach (var item in v.ToList())
            { DataSource.GuestRequestList.Remove(item); }
            //DataSource.GuestRequestList.Remove(guestRequest);
            if (a.Count() != 0)
            {
                foreach (var item in a.ToList())
                { DataSource.OrderList.Remove(item); }
            }
        }

        /// <summary>
        /// removes an existing hosting unit from the system|throws error uf unit doesnt exist
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        public void DeleteHostingUnit(HostingUnit hostingUnit)
        {//TODO: need to put try and catch
            var v = from item in DataSource.HostingUnitList
                    where item.HostingUnitKey1 == hostingUnit.HostingUnitKey1
                    select item;
            var a = from item in DataSource.OrderList
                    where item.HostingUnitKey1 == hostingUnit.HostingUnitKey1
                    select item;

            if (v.Count() == 0)
                throw new KeyNotFoundException("hosting unit  key does not exist");

            foreach (var item in v.ToList())
            { DataSource.HostingUnitList.Remove(item); }
            // DataSource.HostingUnitList.Remove(hostingUnit);
            if (a.Count() != 0)
            {
                foreach (var item in a.ToList())
                { DataSource.OrderList.Remove(item); }
            }
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
                throw new NoItemsFound("there are no hosting units in the system.");
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
                throw new NoItemsFound("there are no guest requests in the system.");
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
                throw new NoItemsFound("there are no orders in the system.");
            return L;
        }
        public List<Order> GetAllOrdersByHostKey(long hostkey)
        {
            List<Order> L = new List<Order>();
            foreach (var item in DataSource.OrderList)
                if(hostkey == item.hostKey1)
                {
                    L.Add(Cloning.Clone(item));
                }
            if (L.Count() == 0)
                throw new NoItemsFound("there are no orders in the system.");
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
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 1,
              BranchAddress1 = "begin 1",
              BranchCity1 = "jerusalem"
             },
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 2,
              BranchAddress1 = "begin 2",
              BranchCity1 = "jerusalem"
             },
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 3,
              BranchAddress1 = "begin 3",
              BranchCity1 = "jerusalem"
             },
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 4,
              BranchAddress1 = "begin 4",
              BranchCity1 = "jerusalem"
             },
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 5,
              BranchAddress1 = "begin 5",
              BranchCity1 = "jerusalem"
             }
            };

            return L;
        }
        public List<Host> GetAllHosts()
        {
            List<Host> L = new List<Host>();
            foreach (var item in DataSource.HostList)
                L.Add(Cloning.Clone(item));
                      return L;
        }        /// <summary>
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
                    if (item1.HostKey1 == item2.Owner1.HostKey1)
                        item1.NumOfHostinUnits1++;
                }
            }
        }
        public HostingUnit GetHostingUnitByName(string name)
        {
            foreach (var item in GetAllHostingUnits())
            {
                if (name == item.HostingUnitName1)
                    return item;
            }
            throw new Exception("the hosting unit does not exist");

        }
        #endregion

        #region get by key
        public Order GetOrderByKey(long key)
        {
            foreach (var item in GetAllOrders())
            {
                if (key == item.OrderKey1)
                    return item;
            }
            throw new Exception("The order does not exist!");
        }

        public GuestRequest GetGuestRequestByKey(long key)
        {
            foreach (var item in GetAllGuestRequest())
            {
                if (key == item.GuestRequestKey1)
                    return item;
            }
            throw new Exception("the guest request does not exist");
        }
        public HostingUnit GetHostingUnitByKey(long key)
        {
            foreach (var item in GetAllHostingUnits())
            {
                if (key == item.HostingUnitKey1)
                    return item;
            }
            throw new Exception("the hosting unit does not exist");

        }
        public List<GuestRequest> GetallGuestRequestByName(string pname, string fname)
        {
            /*foreach (var item in GetAllGuestRequest())
            {
                if (pname == item.PrivateName1 && fname == item.FamilyName1)                 
                        return item;                                 
            }
            throw new Exception("the guest request does not exist");*/
            List<GuestRequest> L = new List<GuestRequest>();
            foreach (var item in DataSource.GuestRequestList)
            {
                if (item.PrivateName1 == pname && item.FamilyName1 == fname)
                {
                    L.Add(Cloning.Clone(item));
                }
            }
            if (L.Count() == 0)
                throw new NoItemsFound("there are no guest requests in the system.");
            return L;
        }

        public List<HostingUnit> GetAllHostingUnitsByHostKey(long key1)
        {
            List<HostingUnit> L = new List<HostingUnit>();
            foreach (var item in GetAllHostingUnits())
            {
                if (key1 == item.Owner1.HostKey1)
                {
                    L.Add(Cloning.Clone(item));
                }
            }
            return L;
        }
        #endregion

        #region updateDiary
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

       


        #endregion


    }
}

