using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;


namespace DAL
{
    //class of Dal Xml
    class Dal_imp_Xml:Idal
    {
        const string childPath = @"ChildXml.xml";
        const string motherPath = @"MotherXml.xml";
        const string nannyPath = @"NannyXml.xml";
        const string contractPath = @"ContractXml.xml";

        //constractor-load the data
        public Dal_imp_Xml()
        {
            DataSource_Xml.listMother = LoadFromXML<List<Mother>>(motherPath);
            if (DataSource_Xml.listMother == null)
            {
                DataSource_Xml.listMother = new List<Mother>();
            }
            DataSource_Xml.listNanny = LoadFromXML<List<Nanny>>(nannyPath);
            if (DataSource_Xml.listNanny == null)
            {
                DataSource_Xml.listNanny = new List<Nanny>();
            }
            DataSource_Xml.listContract = LoadFromXML<List<Contract>>(contractPath);
            if (DataSource_Xml.listContract == null)
            {
                DataSource_Xml.listContract = new List<Contract>();
            }

            try
            {
                if (!File.Exists(childPath))
                {
                    DataSource_Xml.childRoot = new XElement("CHILDREN");
                    DataSource_Xml.childRoot.Save(childPath);
                }
                else DataSource_Xml.childRoot = XElement.Load(childPath);
            }
            catch (Exception)
            {

                throw new Exception("Child File Upload Problem");
            }

        }
        #region generic functions
        //function save to Xml
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }
        //function load to Xml
        public static T LoadFromXML<T>(string path)
        {
            if (File.Exists(path))
            {
                FileStream file = new FileStream(path, FileMode.Open);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                if (file.Length != 0)
                {
                    T result = (T)xmlSerializer.Deserialize(file);
                    file.Close();
                    return result;
                }
                file.Close();
                return default(T);
            }
            else
            {
                FileStream file = new FileStream(path, FileMode.Create);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                file.Close();
                return default(T);
            }
        }
        #endregion generic functions

        #region child
        //function convert child to XElement
        XElement ConvertChild(BE.Child child)
        {
            XElement childElement = new XElement("child");
            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
                childElement.Add(new XElement(item.Name, item.GetValue(child, null)));
            return childElement;
        }
        //convert XElement to child
        BE.Child ConvertChild(XElement element)
        {
            Child child = new Child();
            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);
                if (item.CanWrite)
                    item.SetValue(child, convertValue);
            }
            return child;
        }
        #endregion child
        #region child functions
        //add child
        public void addChild(Child child)
        {
            if (checkId(child.id))
            {
                throw new Exception("This id already exist");
            }
            if (DataSource_Xml.listMother.Where(temp => temp.id == child.idMom).Count() != 1)//checks if the mom is in the system
            {
                throw new Exception("The mother not in the system");
            }
            DataSource_Xml.childRoot.Add(new XElement("child", 
                new XElement("id", child.id), 
                new XElement("idMom", child.idMom), 
                new XElement("firstName", child.firstName), 
                new XElement("bDay", child.bDay), 
                new XElement("ageChild", child.ageChild), 
                new XElement("isSpecial", child.isSpecial), 
                new XElement("specialNeeds", child.specialNeeds), 
                new XElement("idAndName", child.idAndName)));
            DataSource_Xml.childRoot.Save(childPath);
        }
        //delete child
        public void deleteChild(Child child)
        {    
             XElement childXml = (from item in DataSource_Xml.childRoot.Elements()
                             where int.Parse(item.Element("id").Value) == child.id
                             select item).FirstOrDefault();
             if (childXml == null)
                        throw new Exception("child not exist");
            DataSource_Xml.listContract.RemoveAll(x => x.IdChild == child.id);
             childXml.Remove();
             DataSource_Xml.childRoot.Save(childPath);
            SaveToXML<List<Contract>>(DataSource_Xml.listContract, contractPath);

        }
        //update child
        public void reChild(Child child)
        {        
             XElement childXml = (from item in DataSource_Xml.childRoot.Elements()
                             where int.Parse(item.Element("id").Value) == child.id
                             select item).FirstOrDefault();
             if (childXml == null)
                 throw new Exception("child not exist");
             foreach (PropertyInfo item in typeof(Child).GetProperties())
                      childXml.Element(item.Name).SetValue(item.GetValue(child));
             DataSource_Xml.childRoot.Save(childPath); 
        }
        #endregion
        #region mother functions  
        //add mother
        public void addMother(Mother mother)
        {
            if (checkId(mother.id))
            {
                throw new Exception("This id already exist");
            }
            DataSource_Xml.listMother.Add(mother);
            SaveToXML<List<Mother>>(DataSource_Xml.listMother, motherPath);
        }
        //delete mother
        public void deleteMother(Mother mother)
        {
            int index = DataSource_Xml.listMother.FindIndex(x => x.id == mother.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The mother is not exist");
            }            
            foreach (XElement item in DataSource_Xml.childRoot.Elements())
            {
                if (int.Parse(item.Element("idMom").Value) == mother.id)
                {
                    deleteChild(ConvertChild(item));
                }
            }
            DataSource_Xml.listMother.RemoveAt(index);
            SaveToXML<List<Mother>>(DataSource_Xml.listMother, motherPath);
            DataSource_Xml.childRoot.Save(childPath);
        }

        //update mother
        public void reMother(Mother mother)
        {
            int index = DataSource_Xml.listMother.FindIndex(x => x.id == mother.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The mother is not exist");
            }
            DataSource_Xml.listMother[index] = mother;
            SaveToXML<List<Mother>>(DataSource_Xml.listMother, motherPath);
        }
        #endregion
        #region nanny functions
        //add nanny
        public void addNanny(Nanny nanny)
        {
            if (checkId(nanny.id))
            {
                throw new Exception("This id already exist");
            }
            DataSource_Xml.listNanny.Add(nanny);
            SaveToXML<List<Nanny>>(DataSource_Xml.listNanny, nannyPath);
        }
        //delete nanny
        public void deleteNanny(Nanny nanny)
        {
            int index = DataSource_Xml.listNanny.FindIndex(x => x.id == nanny.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The nanny is not exist");
            }
            DataSource_Xml.listContract.RemoveAll(x => x.IdNanny == nanny.id);//delete all the contracts with this nanny.
            DataSource_Xml.listNanny.RemoveAt(index);
            SaveToXML<List<Nanny>>(DataSource_Xml.listNanny, nannyPath);
            SaveToXML<List<Contract>>(DataSource_Xml.listContract, contractPath);


        }
        //update nanny
        public void reNanny(Nanny nanny)
        {
            int index = DataSource_Xml.listNanny.FindIndex(x => x.id == nanny.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The nanny is not exist");
            }
            DataSource_Xml.listNanny[index] = nanny;
            SaveToXML<List<Nanny>>(DataSource_Xml.listNanny, nannyPath);
        }
        #endregion
        #region contract functions
        //add contract
        public void addContract(Contract contract)
        {
            contract.NumContract = 10000000 + DataSource_Xml.listContract.Count() + 1;//update num contract
            DataSource_Xml.listContract.Add(contract);
            SaveToXML<List<Contract>>(DataSource_Xml.listContract, contractPath);
        }
        //delete contract
        public void deleteContract(Contract contract)
        {
            int contractIndex = DataSource_Xml.listContract.FindIndex(x => x.NumContract == contract.NumContract);
            if (contractIndex == -1)
            {
                throw new Exception("The contract not exist");
            }
            DataSource_Xml.listContract.RemoveAt(contractIndex);
            SaveToXML<List<Contract>>(DataSource_Xml.listContract, contractPath);
        }
        //update contract
        public void reContract(Contract contract)
        {
            int contractIndex = DataSource_Xml.listContract.FindIndex(x => x.NumContract == contract.NumContract);
            if (contractIndex == -1)
            {
                throw new Exception("The contract not exist");
            }
            DataSource_Xml.listContract[contractIndex] = contract;
            SaveToXML<List<Contract>>(DataSource_Xml.listContract, contractPath);
        }
        #endregion
        #region check id
        //checks if the id does not exsits in the system
        public bool checkId(int newId)
        {
            int counter = 0;
            IEnumerable<XElement> childTemp = from XElement temp in DataSource_Xml.childRoot.Elements()
                                           where (int.Parse(temp.Element("id").Value) == newId)
                                           select temp;
            counter += childTemp.Count();
            IEnumerable<Mother> momTemp = from Mother temp in DataSource_Xml.listMother
                                          where (temp.id == newId)
                                          select temp;
            counter += momTemp.Count();
            IEnumerable<Nanny> nannyTemp = from Nanny temp in DataSource_Xml.listNanny
                                           where (temp.id == newId)
                                           select temp;
            counter += nannyTemp.Count();
            return counter != 0;
        }

        #endregion
        #region getlist
        public IEnumerable<IGrouping<int, Child>> getChildrenByMom()
        {
            return from item in DataSource_Xml.childRoot.Elements()
                   group ConvertChild(item) by (int.Parse(item.Element("idMom").Value));

        }
        public IEnumerable<Child> getChildren(Func<Child, bool> predicate = null)
        {
            if (predicate == null)
            {
                return from item in DataSource_Xml.childRoot.Elements()
                       select ConvertChild(item);
            }
            return from item in DataSource_Xml.childRoot.Elements()
                   let e = ConvertChild(item)
                   where predicate(e)
                   select e;
        }
        //get all contarcts
        public IEnumerable<Contract> getContracts(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)
            {
                return DataSource_Xml.listContract.AsEnumerable();
            }
            return DataSource_Xml.listContract.Where(predicate);
        }
        //get all mothers
        public IEnumerable<Mother> getMothers(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)
            {
                return DataSource_Xml.listMother.AsEnumerable();
            }
            return DataSource_Xml.listMother.Where(predicate);
        }
        //get all nannies
        public IEnumerable<Nanny> getNannies(Func<Nanny, bool> predicate = null)
        {
            if (predicate == null)
            {
                return DataSource_Xml.listNanny.AsEnumerable();
            }
            return DataSource_Xml.listNanny.Where(predicate);
        }
        #endregion

    }
}
