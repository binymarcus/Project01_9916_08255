using System;
using BE;

/// <summary>
/// clones all the info sent from BE to DAL
/// </summary>
public static class Cloning
{
    public static GuestRequest Clone(this GuestRequest original)
    {
        GuestRequest target = new GuestRequest();
        target.PrivateName1 = original.PrivateName1;
        target.FamilyName1 = original.FamilyName1;
        target.MailAddress1 = original.MailAddress1;
        target.RegistrationDate1 = original.RegistrationDate1;
        target.EntryDate1 = original.EntryDate1;
        target.ReleaseDate1 = original.ReleaseDate1;
        target.SubArea1 = original.SubArea1;
        target.Adults1 = original.Children1;

        return target;
    }

    public static Host Clone(this Host original)
    {
        Host target = new Host();
        target.HostKey1 = original.HostKey1;
        target.PrivateName1 = original.PrivateName1;
        target.FamilyName1 = original.FamilyName1;
        target.PhoneNumber1 = original.PhoneNumber1;
        target.MailAddress1 = original.MailAddress1;
        target.CollectionClearance1 = original.CollectionClearance1;

        return target;
    }

    public static HostingUnit Clone(this HostingUnit original)
    {
        HostingUnit target = new HostingUnit();
        target.HostingUnitKey1 = original.HostingUnitKey1;
        target.Owner1 = original.Owner1;
        target.HostingUnitName1 = original.HostingUnitName1;
        target.Diary1 = original.Diary1;

        return target;
    }

    public static Order Clone(this Order original)
     {
        Order target = new Order();
        target.HostingUnitKey1 = original.HostingUnitKey1;
        target.GuestRequestKey1 = original.GuestRequestKey1;
        target.OrderKey1 = original.OrderKey1;
        target.CreateDate1 = original.CreateDate1;
        target.OrderDate1 = original.OrderDate1;
       
        return target;
     }
}