using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace IBL
{
    public class IBL_imp : IBL
    {
        public List<Order> AllOrdersByCriteria(IBL.checkOrder check)
        {
            throw new NotImplementedException();
        }

        public int calcNumOfDaysBetween(params DateTime[] num)
        {
            int sum = 0;
            if (num.Length==2)
            {//this may have to change according to lenth of the actual months
                
                    sum += Math.Abs(num[0].Day - num[1].Day);
                sum += Math.Abs(30 * (num[0].Month - num[1].Month));
                
            }
            //still need to do version that calculates compared to present day
            return sum;
        }

        public DateTime calEndDate(DateTime start, int num)
        {
            DateTime enedDate = start.AddDays(num);
            return enedDate;
        }

        public List<HostingUnit> FreeUnits(DateTime startdate, int numOfDaysForVacatrion)
        {
            DateTime end = calEndDate(startdate, numOfDaysForVacatrion);
            var v = from item in DAL_imp.GetAllHostingUnits()
                    where  item.checkDates(startdate,end)==true
                             select item;

            if (v.Count() == 0)
                throw new Exception("There are no Free units in these dates");

            return v;

        }

        public int GuestOrderSuggestions(GuestRequest guest)
        {
            throw new NotImplementedException();
        }

        public int HostingunitOrdersFilled(HostingUnit hosting)
        {
            throw new NotImplementedException();
        }

        public List<Order> OlderOrders(int numOfDays)
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> SortedByArea()
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> SortedByNumOfGuests()
        {
            throw new NotImplementedException();
        }

        public List<Host> SortedByNumOfHostingUnits()
        {
            throw new NotImplementedException();
        }

        public List<Host> SortedByNumOfhostingUnits()
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> UNitsSortedByArea()
        {
            throw new NotImplementedException();
        }
    }
}
