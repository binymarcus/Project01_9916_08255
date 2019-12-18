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
        target.PrivateName = original.PrivateName;
        target.FamilyName = original.FamilyName;
        target.MailAddress = original.MailAddress;
        target.RegistrationDate = original.RegistrationDate;
        target.EntryDate = original.EntryDate;
        target.ReleaseDate = original.ReleaseDate;
        target.SubArea = original.SubArea;
        target.Adults = original.Children;

        return target;
    }

    public static Host Clone(this Host original)
    {
        Host target = new Host();
        target.HostKey = original.HostKey;
        target.PrivateName = original.PrivateName;
        target.FamilyName = original.FamilyName;
        target.phoneNumber = original.phoneNumber;
        target.MailAddress = original.MailAddress;
        target.CollectionClearance = original.CollectionClearance;

        return target;
    }

    public static HostingUnit Clone(this HostingUnit original)
    {
        target.HostingUnitKey = original.HostingUnitKey;
        target.Owner = original.Owner;
        target.HostingUnitName = original.HostingUnitName;
        target.Diary = original.Diary;

        return target;
    }

    public static Order Clone(this Order original)
     {
        target.HostingUnitKey = original.HostingUnitKey;
        target.GuestRequestKey = original.GuestRequestKey;
        target.OrderKey = original.OrderKey;
        target.CreateDate = original.CreateDate;
        target.OrderDate = original.OrderDate;
       
        return target;
     }
}