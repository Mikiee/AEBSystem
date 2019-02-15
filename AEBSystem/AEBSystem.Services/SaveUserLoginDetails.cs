using System;
using System.Collections.Generic;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace AEBSystem.Services
{
    public class SaveUserLoginDetails 
    {      
        public static void SaveUserDetails(string Name, string Role, string Position)
        {
            //update xml login file
            string filepath = @"C:\REPORTS\xml\LoginDetails.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(filepath);
            XmlElement root = xmldoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("UserDetails");

            foreach (XmlNode node in nodes)
            {
                if (node["recid"].InnerText == "1")
                {
                    node["Name"].InnerText = Name;
                    node["Role"].InnerText = Role;
                    node["Position"].InnerText = Position;
                    xmldoc.Save(filepath);
                }
            }
        }
    
    
    }
}
