using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL;
using DS;

namespace IBL
{
    public class IBL_imp : IBL
    {
        public List<Order> AllOrdersByCriteria(Delegate check)
        {
            List<Order> L = new List<Order>();
            var v = from item in dall.GetAllOrders()
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

        public int calcNumOfDaysBetween(params DateTime[] num)
        {
            int sum = 0;
            if (num.Length==2)
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

        private DateTime calEndDate(DateTime start, int num)
        {
            DateTime enedDate = start.AddDays(num);
            return enedDate;
        }
        public List<HostingUnit> FreeUnits(DateTime startdate, int numOfDaysForVacatrion)
        {
            List<HostingUnit> L=new List<HostingUnit>();
            DateTime end = calEndDate(startdate, numOfDaysForVacatrion);
             var v = from item in dall.GetAllHostingUnits()
                    where checkDates(startdate,end,item)==true
                             select item;

            if (v.Count() == 0)
                throw new Exception("There are no Free units in these dates");
            foreach (var item in v)
            {
                L.Add(item);
            }
            return L;

        }
        private bool checkDates(DateTime start, DateTime end, HostingUnit host)
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
        public int GuestOrderSuggestions(GuestRequest guest)//dont know how to do this
        {
            throw new NotImplementedException();
        }
        public int HostingunitOrdersFilled(HostingUnit hosting)
        {
            throw new NotImplementedException();
        }
        public List<Order> OlderOrders(int numOfDays)
        {
            List<Order> L = new List<Order>();
            var v = from item in dall.GetAllOrders()
                    where DateTime.Today.DayOfYear-item.OrderDate1.DayOfYear>=numOfDays
                    select item;
            foreach (var item in v)
            {
                L.Add(item);
            }
            return L;

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
        List<Order> IBL.AllOrdersByCriteria(IBL.checkOrder check)
        {
            throw new NotImplementedException();
        }
        int IBL.calcNumOfDaysBetween(params DateTime[] num)
        {
            throw new NotImplementedException();
        }
         List<HostingUnit> IBL.FreeUnits(DateTime startdate, int numOfDaysForVacatrion)
        {
            throw new NotImplementedException();
        }
        int IBL.GuestOrderSuggestions(GuestRequest guest)
        {
            throw new NotImplementedException();
        }
        int IBL.HostingunitOrdersFilled(HostingUnit hosting)
        {
            throw new NotImplementedException();
        }

        List<Order> IBL.OlderOrders(int numOfDays)
        {
            throw new NotImplementedException();
        }

        List<GuestRequest> IBL.SortedByArea()//grouping
        {
            throw new NotImplementedException();
        }

        List<GuestRequest> IBL.SortedByNumOfGuests()//grouping
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns hosts by number of hosting units they have
        /// </summary>
        /// <returns></returns>
        List<Host> IBL.groupedByNumOfhostingUnits()//grouping
        {
            IDAL.calcNumOfHostinUnits(); //call function
            var v = from item in DataSource.HostList
                    group item by item.NumOfHostinUnits;
            return v;
        }

        /// <summary>
        /// returns guestrequests groups by area
        /// </summary>
        /// <returns></returns>
        List<HostingUnit> IBL.gsgroupedByArea()//grouping
        {
            var v = from item in DataSource.GuestRequestList
                    group item by item.Area;

            return v;
        }
    }
}
