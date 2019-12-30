using System;
using System.Collections.Generic;
using BE;

namespace DAL
{
    public interface Idal
    {
     /// <summary>
        /// adds a request for service from a client to the system
        /// </summary>
        /// <param name="guestRequest"></param>
     void AddGuestRequest(GuestRequest guestRequest);
     /// <summary>
        /// updates a rewuest of a client thats already int the system
        /// </summary>
        /// <param name="guestRequest"></param>
     void UpdateGuestRequest(GuestRequest guestRequest);
     /// <summary>
        /// deletes a guest request 
        /// </summary>
        /// <param name="guestRequest"></param>
     void DeleteGuestRequest(GuestRequest guestRequest);
     /// <summary>
        /// adds a hosting unit to the system
        /// </summary>
        /// <param name="hostingUnit"> the hosting unit from BE</param>
      void AddHostingUnit(HostingUnit hostingUnit);
     /// <summary>
        /// removes an existing hosting unit from the system
        /// </summary>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
      void DeleteHostingUnit(HostingUnit hostingUnit);
     /// <summary>
        /// updates the information on an existing hosting unit
        /// </summary>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
      void UpdateHostingUnit(HostingUnit hostingUnit);
     /// <summary>
        /// adds an order from a client to the system
        /// </summary>
        /// <param name="order">Order defined in BE</param>
      void AddOrder(Order order);
     /// <summary>
        /// updates the terms of an order from a client
        /// </summary>
        /// <param name="order">Order defined in BE</param>
     void UpdateOrder(Order order);
     /// <summary>
        /// finds and returns a list of all the hosting units in the sytem
        /// </summary>
        /// <returns>all the hosting units in the system</returns>
      List<HostingUnit> GetAllHostingUnits();
     /// <summary>
        /// shows all clients currently in the system
        /// </summary>
        /// <returns>List of the Clients in the system-by request</returns>
      List<GuestRequest> GetAllGuestRequest();//this may need to change from guest request
     /// <summary>
        /// gets all the orders in the system
        /// </summary>
        /// <returns><list of the Orders/returns>
      List<Order> GetAllOrders();
     /// <summary>
        /// reutrns all the banks- may be stings, unclear
        /// </summary>
        /// <returns></returns>
     List<BankBranch> GetAllBanks();
        Order GetOrderByKey(long key);
        GuestRequest GetGuestRequestByKey(long key);
        HostingUnit GetHostingUnitByKey(long key);
        HostingUnit updateDiary(HostingUnit host, GuestRequest guest);

     /// <summary>
     /// reutrns num of hosting units each host has
     /// </summary>
     /// <returns></returns>
     void CalcNumOfHostingUnits();

    }
}
