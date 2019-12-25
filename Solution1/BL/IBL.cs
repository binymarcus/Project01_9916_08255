using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace IBL
{
    public interface IDAL
        {
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
            int HostingunitOrdersFilled(HostingUnit hosting);
            delegate bool checkOrder(Order order);//dont know why this is errored
            /// <summary>
        /// geta a method of checking the orders and returns all the orders that fit that method
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
            List<Order> AllOrdersByCriteria(checkOrder check); 
            /// <summary>
            /// returns all the orders that are equall or older than the number of days received
            /// </summary>
            /// <param name="numOfDays">integer for the number of days</param>
            /// <returns></returns>
            List<Order> OlderOrders(int numOfDays);
        /// <summary>
        /// checks and returns all the hosting units that are emoty in the specifies days
        /// </summary>
        /// <param name="startDate"> a date time for the start of the thearetical vacation</param>
        /// <param name="vacationDays">the number of days for the vacatio</param>
        /// <returns></returns>

        //need to add the second function fro this class. dont know what it is/
        /************the next few functions are using grouping***********/
           List<GuestRequest> SortedByArea();
        List<GuestRequest> SortedByNumOfGuests();
        List<Host> SortedByNumOfHostingUnits();
        List<HostingUnit> UNitsSortedByArea();

        }
}
