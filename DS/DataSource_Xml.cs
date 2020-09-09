using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
namespace DS
{
    public class DataSource_Xml
    {
        public static XElement childRoot = new XElement("CHILDREN");
        private static List<Nanny> listNanny_t = new List<Nanny>();
        public static List<Nanny> listNanny { get { return listNanny_t; } set { listNanny_t = value; } }
        private static List<Mother> listMother_t = new List<Mother>();
        public static List<Mother> listMother { get { return listMother_t; } set { listMother_t = value; } }
        private static List<Contract> listContract_t = new List<Contract>();
        public static List<Contract> listContract { get { return listContract_t; } set { listContract_t = value; } }
    }
}
