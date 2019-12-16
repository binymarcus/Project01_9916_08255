using System;
using System.Collections.Generic;
using BE;
namespace DS
{
    public class DataSource
    {
        static List<Object> firstList= new List<Object>
            (new Order(), new HostingUnit(),new Host(),new GuestRequest()) ;
        static List<Object> secondList= new List<Object>
            (new Order(), new HostingUnit(),new Host(),new GuestRequest()) ;
        static List<Object> ThirdList= new List<Object>
            (new Order(), new HostingUnit(),new Host(),new GuestRequest()) ;
    }
}

