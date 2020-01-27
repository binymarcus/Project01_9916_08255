using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace DAL
{
    class Dal_XML_imp
    {
        #region paths and roots
        string GRPath = "@GR_XML.xml";
        XElement GRroot = new XElement("GRinfo");
        string HUPath = "@HU_XML.xml";
        XElement HUroot = new XElement("HUinfo");
        string OrderPath = "@Order_XML.xml";
        XElement OrderRoot = new XElement("Orderinfo");
        string ConfigPath = "@Config_XML.xml";
        XElement ConfigRoot = new XElement("Configinfo");
        #endregion
        public Dal_XML_imp()
        {
            if (!File.Exists(GRPath))
                CreateGRFiles();
            if (!File.Exists(HUPath))
                CreateHUFiles();
            if (!File.Exists(OrderPath))
                CreateOrderFiles();
            if (!File.Exists(ConfigPath))
                CreateConfigFiles();
        }
        #region create files
        private void  CreateGRFiles()
        {
            GRroot = new XElement("GRinfo");
            GRroot.Save(GRPath);
        }
        private void CreateHUFiles()
        {
            HUroot = new XElement("HUinfo");
            HUroot.Save(HUPath);
        }
        private void CreateOrderFiles()
        {
            OrderRoot = new XElement("Orderinfo");
            OrderRoot.Save(OrderPath);
        }
        private void CreateConfigFiles()
        {
            ConfigRoot = new XElement("Configinfo");
            ConfigRoot.Save(ConfigPath);
        }
        #endregion
    }
}
