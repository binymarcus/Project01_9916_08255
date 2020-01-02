using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;
using MyException;

namespace BL
{
    public interface IBL
    {
        #region functions from IDAL
        #region Add
        /// <summary>
        /// adds a request for service from a client to the system
        /// </summary>
        /// <param name="guestRequest"></param>
        void AddGuestRequest(GuestRequest guestRequest);
        /// <summary>
        /// adds a hosting unit to the system
        /// </summary>
        /// <param name="hostingUnit"> the hosting unit from BE</param>
        void AddHostingUnit(HostingUnit hostingUnit);
        /// <summary>
        /// adds an order from a client to the system
        /// </summary>
        /// <param name="order">Order defined in BE</param>
        void AddOrder(Order order);
        /// <summary>
        /// adds a hostto the system
        /// </summary>
        /// <param name="host"> the host from BE</param>
        void AddHost(Host host);
        #endregion 
        #region Update
        /// <summary>
        /// updates a rewuest of a client thats already int the system
        /// </summary>
        /// <param name="guestRequest"></param>
        void UpdateGuestRequest(GuestRequest guestRequest);
        /// <summary>
        /// updates the terms of an order from a client
        /// </summary>
        /// <param name="order">Order defined in BE</param>
        void UpdateOrder(Order order);
        /// <summary>
        /// updates the information on an existing hosting unit
        /// </summary>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        void UpdateHostingUnit(HostingUnit hostingUnit);
        #endregion
        #region delete
        /// <summary>
        /// deletes a guest request 
        /// </summary>
        /// <param name="guestRequest"></param>
        void DeleteGuestRequest(GuestRequest guestRequest);
        /// <summary>
        /// removes an existing hosting unit from the system
        /// </summary>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        void DeleteHostingUnit(HostingUnit hostingUnit);
        #endregion
        #region Get
        /// <summary>
        /// finds and returns a list of all the hosting units in the sytem
        /// </summary>
        /// <returns>all the hosting units in the system</returns>
        List<HostingUnit> GetAllHostingUnits();
        /// <summary>
        /// shows all clients currently in the system
        /// </summary>
        /// <returns>List of the Clients in the system-by request</returns>
        List<GuestRequest> GetAllGuestRequest();
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
        #endregion
        /// <summary>
        /// reutrns num of hosting units each host has
        /// </summary>
        /// <returns></returns>
        void CalcNumOfHostingUnits();
        #endregion

        #region mandotory functions from BL
        /// <summary>
        /// checks and returns all the hosting units that are emoty in the specifies days
        /// </summary>
        /// <param name="startDate"> a date time for the start of the thearetical vacation</param>
        /// <param name="numOfDaysForVacatrion">the number of days for the vacatio</param>
        /// <returns></returns>
        List<HostingUnit> FreeUnits(DateTime startdate, int numOfDaysForVacatrion);
        /// <summary>
        /// function recieves either two dates and calculates the time betweeen them, or one and calculates from the present 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        int calcNumOfDaysBetween(params DateTime[] num);
        /// <summary>
        /// returns all the orders that are equall or older than the number of days received
        /// </summary>
        /// <param name="numOfDays">integer for the number of days</param>
        /// <returns></returns>
        List<Order> OlderOrders(int numOfDays);
        /// <summary>
        /// geta a method of checking the orders and returns all the orders that fit that method
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        List<GuestRequest> AllOrdersByCriteria(Predicate<GuestRequest> check);
        /// <summary>
        /// the function recieves a guest request and returns the number of orders sent to it.
        /// </summary>
        /// <param name="guest"></param>
        /// <returns>returns the number of orders sent</returns>
        int GuestOrderSuggestions(GuestRequest guest);
        /// <summary>
        /// returns the number of orders sent to guests or orders filled out
        /// </summary>
        /// <param name="hosting"></param>
        /// <returns></returns>
        int HostingUnitOrdersFilled(HostingUnit hosting);
        #region grouping
        List<IGrouping<BEEnum.Area, HostingUnit>> GroupByAreaOfHostingUnit();
        List<IGrouping<int, GuestRequest>> GroupedByNumOfGuests();
        List<IGrouping<int, Host>> groupedByNumOfhostingUnits();
        List<IGrouping<BEEnum.Area, GuestRequest>> GroupedByAreaOfGuestRequest();
        #endregion
        #endregion

        #region functions for use of other functions
        /// <summary>
        /// calculates the end date of a stay
        /// </summary>
        /// <param name="start"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        DateTime CalcEndDate(DateTime start, int num);
        /// <summary>
        /// checks if dates are occupied or vacent
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        bool checkDates(DateTime start, DateTime end, HostingUnit host);
        #endregion
        List<HostingUnit> allUnitsWithPools();
        List<HostingUnit> allUnitsWithJaccuzzis();
        List<HostingUnit> allUnitsWithGardens();
        List<HostingUnit> allUnitsWithchildrensattractions();
        HostingUnit findFirstBestUnitInArea(GuestRequest guest);
        Order findLongestOrderPending();
   }
}
