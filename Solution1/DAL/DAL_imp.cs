using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
using DS;
using MyException;

namespace DAL
{
    public class DAL_imp : Idal
    {
        string GRPath = "@GR_XML.xml";
        XElement GRroot = new XElement("GRinfo");
        string HUPath = "@HU_XML.xml";
        string OrderPath = "@Order_XML.xml";
        XElement OrderRoot = new XElement("Orderinfo");
        string ConfigPath = "@Config_XML.xml";
        XElement ConfigRoot = new XElement("Configinfo");
        String hostPath = "@HostXml.xml";
        XElement hostRoot = new XElement("hostsInfo");
        Dal_XML_imp imp;
        static List<HostingUnit> huList = new List<HostingUnit>();
        public DAL_imp()
        {
            imp = new Dal_XML_imp();
            LoadData();
            huList=LoadFromXML<List<HostingUnit>>( HUPath,huList);
        }
        #region add
        /// <summary>
        /// adds a request for service from a client to the system
        /// </summary>
        /// <param name="guestRequest"></param>
        public void AddGuestRequest(GuestRequest guest)
        {//TODO: need to put try and catch
            guest.GuestRequestKey1 = long.Parse(ConfigRoot.Element("GRkey").Value)+1;
            ConfigRoot.Element("GRkey").Value = guest.GuestRequestKey1.ToString();
            ConfigRoot.Save(ConfigPath);
            guest.RegistrationDate1 = DateTime.Now;
            GuestRequest guestRequest = Cloning.Clone(guest);
            XElement guestkey = new XElement("guestkey", guestRequest.GuestRequestKey1);
            XElement pname  = new XElement("Pname",guestRequest.PrivateName1);
            XElement Fname = new XElement("Fname", guestRequest.FamilyName1);
            XElement entryDate = new XElement("entryDate",guestRequest.EntryDate1);
            XElement ReleaseDate = new XElement("releaseDate", guestRequest.ReleaseDate1);
            XElement registrationDate = new XElement("registrationDate", guestRequest.RegistrationDate1);
            XElement mail = new XElement("mail", guestRequest.MailAddress1);
            XElement status = new XElement("status",guestRequest.status1);
            XElement pool = new XElement("pool", guestRequest.pool1);
            XElement jaccuzi = new XElement("jaccuzi", guestRequest.Jacuzzi1);
            XElement garden = new XElement("garden", guestRequest.Garden1);
            XElement childrenAttractions = new XElement("childrensAttractions", guestRequest.ChildrensAttractions1);
            XElement Area = new XElement("Area", guestRequest.area1);
            XElement sub = new XElement("subArea", guestRequest.SubArea1);
            XElement adults = new XElement("adults", guestRequest.Adults1);
            XElement kids = new XElement("kids", guestRequest.Children1);
            XElement totalppl = new XElement("numppl", guestRequest.TotalGuests1);
            XElement GR = new XElement("GR", guestkey, pname, Fname, entryDate, ReleaseDate, registrationDate, mail, status, pool, jaccuzi, garden, childrenAttractions, Area, sub, adults, kids, totalppl);
            GRroot.Add(GR);
            GRroot.Save(GRPath);
        }
        /// <summary>
        /// adds a hosting unit to the system
        /// </summary>
        /// <param name="hostingUnit"> the hosting unit from BE</param>
        public void AddHostingUnit(HostingUnit hostingUnit)
        {            
            foreach (var item in GetAllHostingUnits())
               {
                    if (item.HostingUnitName1 == hostingUnit.HostingUnitName1)
                        throw new UnexceptableDetailsException("cannot enter two hosting units with the same name");
                }
            hostingUnit.HostingUnitKey1 = long.Parse(ConfigRoot.Element("HUkey").Value);
            ConfigRoot.Element("HUkey").Value =( hostingUnit.HostingUnitKey1 + 1).ToString();
            ConfigRoot.Save(ConfigPath);
            huList.Add(hostingUnit);
            SaveToXML(huList, HUPath);

        }
        /// <summary>
        /// adds an order from a client to the system
        /// </summary>
        /// <param name="order">Order defined in BE</param>
        public void AddOrder(Order order)
        {
            order.CreateDate1 = DateTime.Now;
            order.OrderKey1 = long.Parse(ConfigRoot.Element("orderkey").Value) + 1;
            ConfigRoot.Element("orderkey").Value = order.OrderKey1.ToString();
            ConfigRoot.Save(ConfigPath);
            Order or = Cloning.Clone(order);
            XElement Cdate = new XElement("Cdate", or.CreateDate1);
            XElement orderdate = new XElement("orderdate", or.OrderDate1);
            XElement orderKey = new XElement("orderKey", or.OrderKey1);
            XElement HUKey = new XElement("HUkey", or.HostingUnitKey1);
            XElement hostkey = new XElement("hostKey", or.hostKey1);
            XElement GRKey = new XElement("GRKey", or.OrderKey1);
            XElement status = new XElement("status", or.Status1);
            XElement operate = new XElement("order", Cdate, orderdate,orderKey, orderdate, HUKey, hostkey, GRKey, status);
            OrderRoot.Add(operate);
            OrderRoot.Save(OrderPath);
        }
        /// <summary>
        /// adds a host to the system
        /// </summary>
        /// <param name="host">Host defined in BE</param>
        public void AddHost(Host host,string user,string pass)
        {
            host.HostKey1 = long.Parse(ConfigRoot.Element("hostkey").Value)+1;
            ConfigRoot.Element("hostkey").Value = host.HostKey1.ToString();
            ConfigRoot.Save(ConfigPath);
            Host hoe = Cloning.Clone(host);
            XElement username = new XElement("username",user);
            XElement password = new XElement("password",pass);
            XElement key = new XElement("key", host.HostKey1);
            XElement Pname = new XElement("firstName", hoe.PrivateName1);
            XElement Fname = new XElement("lastName", hoe.FamilyName1);
            XElement email = new XElement("Email", hoe.MailAddress1);
            XElement phone = new XElement("PhoneNumber", hoe.PhoneNumber1);
            XElement bank = new XElement("BankAccountNumber", hoe.BankAccountNumber1);
            XElement clearance = new XElement("Clearance",hoe.CollectionClearance1.ToString());
            XElement num = new XElement("num", host.NumOfHostinUnits1);
            XElement Host = new XElement("Host", username, password,key, Pname, Fname, email, phone,num, bank, clearance);
            hostRoot.Add(Host);
            hostRoot.Save(hostPath);
        }
        #endregion

        #region update
        /// <summary>
        /// updates a request of a client thats already int the system
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="guestRequest"></param>
        public void UpdateGuestRequest(GuestRequest guestRequest)
        {
            XElement GRelement;
            try
            {
                GRelement = (from gr in GRroot.Elements()
                             where int.Parse(gr.Element("guestkey").Value) == guestRequest.GuestRequestKey1
                             select gr).FirstOrDefault();
                GRelement.Element("Pname").Value = guestRequest.PrivateName1;
                GRelement.Element("Fname").Value = guestRequest.FamilyName1;
                GRelement.Element("entryDate").Value = guestRequest.EntryDate1.ToString();
                GRelement.Element("releaseDate").Value = guestRequest.ReleaseDate1.ToString();
                GRelement.Element("registrationDate").Value = guestRequest.RegistrationDate1.ToString();
                GRelement.Element("mail").Value = guestRequest.MailAddress1;
                GRelement.Element("status").Value = guestRequest.status1.ToString();
                GRelement.Element("pool").Value = guestRequest.pool1.ToString();
                GRelement.Element("jaccuzi").Value = guestRequest.Jacuzzi1.ToString();
                GRelement.Element("garden").Value = guestRequest.Garden1.ToString();
                GRelement.Element("childrensAttractions").Value = guestRequest.ChildrensAttractions1.ToString();
                GRelement.Element("Area").Value = guestRequest.area1.ToString();
                GRelement.Element("subArea").Value = guestRequest.SubArea1;
                GRelement.Element("adults").Value = guestRequest.Adults1.ToString();
                GRelement.Element("kids").Value = guestRequest.Children1.ToString();
                GRelement.Element("numppl").Value = guestRequest.TotalGuests1.ToString();
                GRroot.Save(GRPath);
            }
            catch (Exception)
            {

                throw new NoItemsFound("no reuquest with this key");
            }

        }
        /// <summary>
        /// updates the information on an existing hosting unit|throws error if unit doesnt exist
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            huList.RemoveAll(x => x.HostingUnitKey1 == hostingUnit.HostingUnitKey1);
            huList.Add(hostingUnit);
            SaveToXML(huList, HUPath);
        }
        /// <summary>
        /// updates the terms of an order from a client|throws error if order already exists
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <param name="order">Order defined in BE</param>
        public void UpdateOrder(Order order)
        {
            XElement orderElement;
            try
            {
                orderElement = (from or in OrderRoot.Elements()
                             where int.Parse(or.Element("orderKey").Value) == order.OrderKey1
                             select or).FirstOrDefault();
                orderElement.Element("Cdate").Value = order.CreateDate1.ToString();
                orderElement.Element("orderdate").Value = order.OrderDate1.ToString();
                orderElement.Element("HUkey").Value = order.HostingUnitKey1.ToString();
                orderElement.Element("hostKey").Value = order.hostKey1.ToString();
                orderElement.Element("GRKey").Value = order.GuestRequestKey1.ToString();
                orderElement.Element("status").Value = order.Status1.ToString();
                OrderRoot.Save(OrderPath);
            }
            catch (Exception)
            {

                throw new NoItemsFound("no order with this key");
            }
        }
        #endregion

        #region delete
        /// <summary> 
        /// deletes an existing guest request
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="guestRequest"></param>
        public void DeleteGuestRequest(GuestRequest guestRequest)
        {
            XElement GRelement;
            try
            {
                GRelement = (from gr in GRroot.Elements()
                             where long.Parse(gr.Element("guestkey").Value) == guestRequest.GuestRequestKey1
                             select gr).FirstOrDefault();
                GRelement.Remove();
                GRroot.Save(GRPath);
            }
            catch (Exception)
            {

                throw new NoItemsFound("no reuquest with this key");
            }
        }

        /// <summary>
        /// removes an existing hosting unit from the system|throws error uf unit doesnt exist
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="hostingUnit">hosting unit defined in BE</param>
        public void DeleteHostingUnit(HostingUnit hostingUnit)
        {
            huList.RemoveAll(x => x.HostingUnitKey1 == hostingUnit.HostingUnitKey1);
            SaveToXML(huList, HUPath);
        }
        #endregion

        #region Get
        /// <summary>
        /// finds and returns a list of all the hosting units in the sytem
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <returns>all the hosting units in the system</returns>
        public List<HostingUnit> GetAllHostingUnits()
        {

            return huList;          
        }
        /// <summary>
        /// shows all clients currently in the system
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <returns>List of the Clients in the system-by request</returns>
        public List<GuestRequest> GetAllGuestRequest()//this may need to change from guest request
        {

            List<GuestRequest> L = new List<GuestRequest>();
            try
            {
                L = (from gr in GRroot.Elements()
                     select new GuestRequest()
                     {
                         GuestRequestKey1 = long.Parse(gr.Element("guestkey").Value),
                         PrivateName1 = gr.Element("Pname").Value,
                         FamilyName1 = gr.Element("Fname").Value,
                         EntryDate1 = DateTime.Parse(gr.Element("entryDate").Value),
                         ReleaseDate1 = DateTime.Parse(gr.Element("releaseDate").Value),
                         RegistrationDate1 = DateTime.Parse(gr.Element("registrationDate").Value),
                         MailAddress1 = gr.Element("mail").Value,
                         status1 = (BEEnum.Status)Enum.Parse(typeof(BEEnum.Status), gr.Element("status").Value),
                         pool1 = (BEEnum.Option)Enum.Parse(typeof(BEEnum.Option), gr.Element("pool").Value),
                         Garden1 = (BEEnum.Option)Enum.Parse(typeof(BEEnum.Option), gr.Element("garden").Value),
                         ChildrensAttractions1 = (BEEnum.Option)Enum.Parse(typeof(BEEnum.Option), gr.Element("childrensAttractions").Value),
                         Jacuzzi1 = (BEEnum.Option)Enum.Parse(typeof(BEEnum.Option), gr.Element("jaccuzi").Value),
                         area1 = (BEEnum.Area)Enum.Parse(typeof(BEEnum.Area), gr.Element("Area").Value),
                         SubArea1 = gr.Element("subArea").Value,
                         Adults1 = int.Parse(gr.Element("adults").Value),
                         Children1 = int.Parse(gr.Element("kids").Value),
                         TotalGuests1 = int.Parse(gr.Element("numppl").Value)

                     }).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
            
            return L;
        }
        /// <summary>
        /// gets all the orders in the system
        /// </summary>
        /// <exception cref="NoItemsFound"></exception>
        /// <returns><list of the Orders/returns>
        public List<Order> GetAllOrders()
        {
            List<Order> L = new List<Order>();
            try
            {
                L = (from order in OrderRoot.Elements()
                     select new Order()
                     {
                         CreateDate1 = DateTime.Parse(order.Element("Cdate").Value),
                         OrderDate1 = DateTime.Parse(order.Element("orderdate").Value),
                         OrderKey1 = long.Parse(order.Element("orderKey").Value),
                         HostingUnitKey1 = long.Parse(order.Element("HUkey").Value),
                         GuestRequestKey1 = long.Parse(order.Element("GRKey").Value),
                         hostKey1 = long.Parse(order.Element("hostKey").Value),
                         Status1 = (BEEnum.Status)Enum.Parse(typeof(BEEnum.Status), order.Element("status").Value)
                     }).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
            return L;
        }
        public List<Order> GetAllOrdersByHostKey(long hostkey)
        {
            List<Order> L = new List<Order>();
            try
            {
                L = (from order in OrderRoot.Elements()
                     where long.Parse(order.Element("hostKey").Value)==hostkey
                     select new Order()
                     {
                         CreateDate1 = DateTime.Parse(order.Element("Cdate").Value),
                         OrderDate1 = DateTime.Parse(order.Element("orderdate").Value),
                         OrderKey1 = long.Parse(order.Element("orderKey").Value),
                         HostingUnitKey1 = long.Parse(order.Element("HUkey").Value),
                         GuestRequestKey1 = long.Parse(order.Element("GRKey").Value),
                         Status1 = (BEEnum.Status)Enum.Parse(typeof(BEEnum.Status), order.Element("status").Value)
                     }).ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
            return L;
        }
        /// <summary>
        /// reutrns all the banks
        /// </summary>
        /// <returns></returns>
        public List<BankBranch> GetAllBanks()
        {
            List<BankBranch> L = new List<BankBranch>
            {
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 1,
              BranchAddress1 = "begin 1",
              BranchCity1 = "jerusalem"
             },
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 2,
              BranchAddress1 = "begin 2",
              BranchCity1 = "jerusalem"
             },
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 3,
              BranchAddress1 = "begin 3",
              BranchCity1 = "jerusalem"
             },
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 4,
              BranchAddress1 = "begin 4",
              BranchCity1 = "jerusalem"
             },
             new BankBranch()
             {
              BankName1 = "leumi",
              BankNumber1= 1,
              BranchNumbner1 = 5,
              BranchAddress1 = "begin 5",
              BranchCity1 = "jerusalem"
             }
            };

            return L;
        }
        public List<Host> GetAllHosts()
        {
            List<Host> L = new List<Host>();
            try
            {
                L = (from host in hostRoot.Elements()
                     select new Host()
                     {
                         HostKey1=long.Parse(host.Element("key").Value),
                         PrivateName1=host.Element("firstName").Value,
                         FamilyName1 = host.Element("lastName").Value,
                         MailAddress1=host.Element("Email").Value,
                         PhoneNumber1=host.Element("PhoneNumber").Value,
                         NumOfHostinUnits1=int.Parse(host.Element("num").Value),
                         BankAccountNumber1=int.Parse(host.Element("BankAccountNumber").Value),
                         CollectionClearance1=bool.Parse(host.Element("Clearance").Value)
                     }).ToList();
                return L;
            }
            catch (Exception e)
            {

                throw e;
            }
        }       
     
        /// <summary>
       /// sets num of hosting units each host has
      /// </summary>
     /// <returns></returns>
            public void CalcNumOfHostingUnits()
        {
            foreach (var item1 in hostRoot.Elements())
            {
                int num = 0;
                foreach (var item2 in huList)
                {
                    if (long.Parse(item1.Element("key").Value) == item2.HostingUnitKey1)
                        num++;

                }
                item1.Element("num").Value = num.ToString();
                            }
            hostRoot.Save(hostPath);
        }
        public HostingUnit GetHostingUnitByName(string name)
        {
            foreach (var item in GetAllHostingUnits())
            {
                if (name == item.HostingUnitName1)
                    return item;
            }
            throw new Exception("the hosting unit does not exist");

        }
        #endregion

        #region get by key
        public Order GetOrderByKey(long key)
        {
            foreach (var item in GetAllOrders())
            {
                if (key == item.OrderKey1)
                    return item;
            }
            throw new Exception("The order does not exist!");
        }

        public GuestRequest GetGuestRequestByKey(long key)
        {
            foreach (var item in GetAllGuestRequest())
            {
                if (key == item.GuestRequestKey1)
                    return item;
            }
            throw new Exception("the guest request does not exist");
        }
        public HostingUnit GetHostingUnitByKey(long key)
        {
            foreach (var item in GetAllHostingUnits())
            {
                if (key == item.HostingUnitKey1)
                    return item;
            }
            throw new Exception("the hosting unit does not exist");

        }
        public Host getHostByKey(long key1)
        {
            foreach (var item in GetAllHosts())
            {
                if (key1 == item.HostKey1)
                    return item;
            }
            throw new Exception("the Host does not exist");
        }
        public List<GuestRequest> GetallGuestRequestByName(string pname, string fname)
        {
            /*foreach (var item in GetAllGuestRequest())
            {
                if (pname == item.PrivateName1 && fname == item.FamilyName1)                 
                        return item;                                 
            }
            throw new Exception("the guest request does not exist");*/
            List<GuestRequest> L = new List<GuestRequest>();
            foreach (var item in GetAllGuestRequest())
            {
                if (item.PrivateName1 == pname && item.FamilyName1 == fname)
                {
                    L.Add(Cloning.Clone(item));
                }
            }
            if (L.Count() == 0)
                throw new NoItemsFound("there are no guest requests in the system.");
            return L;
        }

        public List<HostingUnit> GetAllHostingUnitsByHostKey(long key1)
        {
            List<HostingUnit> L = new List<HostingUnit>();
            foreach (var item in GetAllHostingUnits())
            {
                if (key1 == item.Owner1.HostKey1)
                {
                    L.Add(Cloning.Clone(item));
                }
            }
            return L;
        }
        #endregion

        #region updateDiary
        public HostingUnit updateDiary(HostingUnit host, GuestRequest guest)
        {

            for (int i = guest.EntryDate1.Month; i <= guest.ReleaseDate1.Month; i++)
            {
                int j = 0;
                if (i == guest.EntryDate1.Month)
                    j = guest.EntryDate1.Day;
                int stop = 31;
                if (i == guest.ReleaseDate1.Month)
                    stop = guest.ReleaseDate1.Day;
                for (; j < stop; j++)
                {
                    host.Diary1[i, j] = true;
                }
            }
            return host;
        }




        #endregion

        private void LoadData()
        {
            try
            {
                GRroot = XElement.Load(GRPath);
                OrderRoot = XElement.Load(OrderPath);
                ConfigRoot = XElement.Load(ConfigPath);
                hostRoot = XElement.Load("@HostXml.xml");
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public Host getHostByUser(string user)
        {

            Host host = new Host();

            host = (from use in hostRoot.Elements()
                    where use.Element("username").Value == user
                    select new BE.Host()
                    {   HostKey1 = long.Parse(use.Element("key").Value),
                        PrivateName1 = use.Element("firstName").Value,
                        FamilyName1 = use.Element("lastName").Value,
                        MailAddress1 = use.Element("Email").Value,
                        PhoneNumber1 = use.Element("PhoneNumber").Value,
                        BankAccountNumber1 = int.Parse(use.Element("BankAccountNumber").Value),
                        CollectionClearance1 = bool.Parse(use.Element("Clearance").Value)
                    }).Single();
            return host;
}
        public static void SaveToXML<T>(T source, string path)
{
    FileStream file = new FileStream(path, FileMode.Create);
    XmlSerializer xmlSer = new XmlSerializer(source.GetType());
    xmlSer.Serialize(file, source);
    file.Close();
}
        public static T LoadFromXML<T>(string path,T temp)
{
    FileStream file = new FileStream(path, FileMode.Open);
    XmlSerializer xmlSer = new XmlSerializer(typeof(T));
           
            try
            {
                 temp = (T)xmlSer.Deserialize(file);
            }
            catch
            {
               
            }
            finally
            {
                file.Close();
            }
            return temp;
        }
    }
}


