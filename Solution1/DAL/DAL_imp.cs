using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DS;

namespace DAl
{
    public class DAL_imp
    {
        public DAL_imp()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// adds a request for service from a client to the system|throws an error if request already exists
        /// </summary>
        /// <param name="guestRequest"></param>
        void AddGuestRequest(GuestRequest guestRequest)
        {//TODO: need to put try and catch
            var v = from item in DataSource.GuestRequestList
                    where item.GuestRequestKey1 == guestRequest.GuestRequestKey1
                    select item;

            if (v.Count() != 0)
                throw new Exception("GuestRequest key already exists");

            DataSource.GuestRequestList.Add(guestRequest);
        }
        /// <summary>
        /// updates a request of a client thats already int the system|throws an error if doesn't exist
        /// </summary>
        /// <param name="guestRequest"></param>
        void UpdateGuestRequest(GuestRequest guestRequest)
        {//TODO: need to put try and catch
            //TODO: need to put try and catch
            var v = from item in DataSource.GuestRequestList
                    where item.GuestRequestKey1 == guestRequest.GuestRequestKey1
                    select item;

            if (v.Count() == 0)
                throw new KeyNotFoundException("GuestRequest key dose not exist");

            DataSource.GuestRequestList.Remove(guestRequest);
            DataSource.GuestRequestList.Add(guestRequest);
        }
        /// <summary>
        /// deletes an existing guest request|sends an error if doesnt exist
        /// </summary>
        /// <param name="guestRequest"></param>
        void DeleteGuestRequest(GuestRequest guestRequest)
        {//TODO: need to put try and catch
            var v = from item in DataSource.GuestRequestList
                where item.GuestRequestKey1 == guestRequest.GuestRequestKey1
                select item;

                if (v.Count() == 0)
                    throw new KeyNotFoundException("GuestRequest key not found");
           
                DataSource.GuestRequestList.Remove(guestRequest);
        }
        /// <summary>
        /// adds a hosting unit to the system|throw error if hosting unit already exists
        /// </summary>
        /// <param name="hostingUnit"> the hosting unit from BE</param>
        void AddHostingUnit(HostingUnit hostingUnit)
        {//TODO: need to put try and catch
            var v = from item in DataSource.HostingUnitList
                    where item.HostingUnitKey1 == hostingUnit.HostingUnitKey1
                    select item;

            if (v.Count() != 0)
                throw new Exception("hostingUnit key already exists");

            DataSource.HostingUnitList.Add(hostingUnit);
        }
        /// <summary>
        /// removes an existing hosting unit from the system|throws error uf unit doesnt exist
        /// </summary>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        void DeleteHostingUnit(HostingUnit hostingUnit)
        {//TODO: need to put try and catch
            var v = from item in DataSource.HostingUnitList
                    where item.HostingUnitKey1 == hostingUnit.HostingUnitKey1
                    select item;

            if (v.Count() == 0)
                throw new Exception("GuestRequest key does not exist");

            DataSource.HostingUnitList.Remove(hostingUnit);
        }
        /// <summary>
        /// updates the information on an existing hosting unit|throws error if unit doesnt exist
        /// </summary>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        void UpdateHostingUnit(HostingUnit hostingUnit)
        {//TODO: need to put try and catch
            var v = from item in DataSource.HostingUnitList
                    where item.HostingUnitKey1 == hostingUnit.HostingUnitKey1
                    select item;

            if (v.Count() == 0)
                throw new Exception("GuestRequest key does not exist");

            DataSource.HostingUnitList.Remove(hostingUnit);
            DataSource.HostingUnitList.Add(hostingUnit);
        }

        /// <summary>
        /// adds an order from a client to the system|throws error if order already exists
        /// </summary>
        /// <param name="order">Order defined in BE</param>
        void AddOrder(Order order)
        {
            {//TODO: need to put try and catch
                var v = from item in DataSource.OrderList
                        where item.OrderKey1 == order.OrderKey1
                        select item;

                if (v.Count() != 0)
                    throw new Exception("order key allready exists");

                DataSource.OrderList.Add(order);

            }
        }
        /// <summary>
        /// updates the terms of an order from a client|throws error if order already exists
        /// </summary>
        /// <param name="order">Order defined in BE</param>
        void UpdateOrder(Order order)
        {//TODO: need to put try and catch
            var v = from item in DataSource.OrderList
                    where item.OrderKey1 == order.OrderKey1
                    select item;

            if (v.Count() == 0)
                throw new Exception("GuestRequest key does not exist");

            DataSource.OrderList.Remove(order);
            DataSource.OrderList.Add(order);

        }

        /// <summary>
        /// finds and returns a list of all the hosting units in the sytem
        /// </summary>
        /// <returns>all the hosting units in the system</returns>
        List<HostingUnit> GetAllHostingUnits()
        {
            List<HostingUnit> L = new List<HostingUnit>();
            foreach (var item in DataSource.HostingUnitList)
                L.Add(Cloning.Clone(item));
            return L;
        }

        /// <summary>
        /// shows all clients currently in the system
        /// </summary>
        /// <returns>List of the Clients in the system-by request</returns>
        List<GuestRequest> GetAllGuestRequest()//this may need to change from guest request
        {

            List<GuestRequest> L = new List<GuestRequest>();
            foreach (var item in DataSource.GuestRequestList)
                L.Add(Cloning.Clone(item));
            return L;
        }

        /// <summary>
        /// gets all the orders in the system
        /// </summary>
        /// <returns><list of the Orders/returns>
        List<Order> GetAllOrders()
        {
            List<Order> L = new List<Order>();
            foreach (var item in DataSource.OrderList)
                L.Add(Cloning.Clone(item));
            return L;
        }

        /// <summary>
        /// reutrns all the banks
        /// </summary>
        /// <returns></returns>
        List<BankBranch> GetAllBanks()
        {
            List<BankBranch> L = new List<BankBranch>
            {
             new BankBranch("leumi" , 1, 1, "begin 1", "jerusalem"),
             new BankBranch("leumi" , 1, 2, "begin 2", "jerusalem"),
             new BankBranch("leumi" , 1, 3, "begin 3", "jerusalem"),
             new BankBranch("leumi" , 1, 4, "begin 4", "jerusalem"),
             new BankBranch("leumi" , 1, 5, "begin 5", "jerusalem")
            };

            return L;
        }

    }
}

