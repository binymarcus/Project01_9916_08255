using System;

namespace DAL
{
    interface Idle
    {
     private void AddGuestRequest(GuestRequest guestRequest);
     private void UpdateGuestRequest(GuestRequest guestRequest);

     private void AddHostingUnit(HostingUnit hostingUnit);
     private void DeleteHostingUnit(HostingUnit hostingUnit);
     private void UpdateHostingUnit(HostingUnit hostingUnit);

     private void AddOrder(Order order);
     private void UpdateOrder(Order order);

     private list<HostingUnit> GetAllHostingUnits();
     private list<> GetAllClaints();
     private list<> GetAllOrders();
            
     list<string> GetAllBanks();
    }
}
