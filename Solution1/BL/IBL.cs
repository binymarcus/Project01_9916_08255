using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace IBL
{
    public interface IBL
    {
        /// <summary>
        /// geta a method of checking the orders and returns all the orders that fit that method
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        List<Order> AllOrdersByCriteria(Delegate check);
        /// <summary>
        /// function recieves either two dates and calculates the time betweeen them, or one and calculates from the present 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        int calcNumOfDaysBetween(params DateTime[] num);
        /// <summary>
        /// calculates the end date of a stay
        /// </summary>
        /// <param name="start"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        DateTime calcEndDate(DateTime start, int num);
        /// <summary>
        /// checks and returns all the hosting units that are emoty in the specifies days
        /// </summary>
        /// <param name="startDate"> a date time for the start of the thearetical vacation</param>
        /// <param name="numOfDaysForVacatrion">the number of days for the vacatio</param>
        /// <returns></returns>
        List<HostingUnit> FreeUnits(DateTime startdate, int numOfDaysForVacatrion);
        /// <summary>
        /// checks if dates are occupied or vacent
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        bool checkDates(DateTime start, DateTime end, HostingUnit host);
        /// <summary>
        /// returns all the orders that are equall or older than the number of days received
        /// </summary>
        /// <param name="numOfDays">integer for the number of days</param>
        /// <returns></returns>
        List<Order> OlderOrders(int numOfDays);
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
      
      

        //need to add the second function fro this class. dont know what it is/

        /************the next few functions are using grouping***********/
        List<HostingUnit> GroupByAreaOfHostingUnit();
        List<GuestRequest> GroupedByNumOfGuests();
        List<Host> groupedByNumOfhostingUnits();
        List<GuestRequest> GroupedByAreaOfGuestRequest();

    }
}
