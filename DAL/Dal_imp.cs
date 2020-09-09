using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    //class of Dal imp
    internal class Dal_imp : Idal
    {
        //c-tor
        public Dal_imp()
        {
            DataSource.listChild = new List<Child>();
            DataSource.listContract = new List<Contract>();
            DataSource.listMother = new List<Mother>();
            DataSource.listNanny = new List<Nanny>();
        }
        #region Child
        //add child
        public void addChild(Child child)
        {
            if(checkId(child.id))
            {
                throw new Exception("This id already exist");
            }

            if(DataSource.listMother.Where(temp=> temp.id == child.idMom).Count()!=1)//checks if the mom is in the system
            {
                throw new Exception("The mother not in the system");
            }
            DataSource.listChild.Add(child);
        }
        //delete child
        public void deleteChild(Child child)
        {   
            
            int index = DataSource.listChild.FindIndex(x => x.id == child.id);
            if (index==-1)//if id not exist
            {
                throw new Exception("The child is not exist");
            }
            DataSource.listContract.RemoveAll(x => x.IdChild == child.id);//delete the contract with this child

            DataSource.listChild.RemoveAt(index);
        }
        //update child
        public void reChild(Child child)
        {
            int index = DataSource.listChild.FindIndex(x => x.id == child.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The child is not exist");
            }
            DataSource.listChild[index] = child;     
        }
        #endregion Child

        #region Mother
        //add mother
        public void addMother(Mother mother)
        {
            if (checkId(mother.id))
            {
                throw new Exception("This id already exist");
            }
            DataSource.listMother.Add(mother);
        }
        //delete mother
        public void deleteMother(Mother mother)
        {
            int index = DataSource.listMother.FindIndex(x => x.id == mother.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The mother is not exist");
            }
            for (int i = 0; i < DataSource.listChild.Count(); i++)
            {
                if (DataSource.listChild[i].idMom == mother.id)
                {
                    deleteChild(DataSource.listChild[i]);
                    i--;
                }
            }

            DataSource.listMother.RemoveAt(index);
                //throw new Exception("not succeed");
        }
        //update mother
        public void reMother(Mother mother)
        {
            int index = DataSource.listMother.FindIndex(x => x.id == mother.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The mother is not exist");
            }
            DataSource.listMother[index] = mother;
        }
        
#endregion Mother

        #region Nanny
        //add nanny
        public void addNanny(Nanny nanny)
        {
            if (checkId(nanny.id))
            {
                throw new Exception("This id already exist");
            }
            DataSource.listNanny.Add(nanny);
        }
        //delete nanny
        public void deleteNanny(Nanny nanny)
        {
            int index = DataSource.listNanny.FindIndex(x => x.id == nanny.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The nanny is not exist");
            }
            DataSource.listContract.RemoveAll(x => x.IdNanny == nanny.id);//delete all the contracts with this nanny.
            DataSource.listNanny.RemoveAt(index);

        }
        //update nanny
        public void reNanny(Nanny nanny)
        {
            int index = DataSource.listNanny.FindIndex(x => x.id == nanny.id);
            if (index == -1)//if id not exist
            {
                throw new Exception("The nanny is not exist");
            }
            DataSource.listNanny[index] = nanny;
        }
       
#endregion Nanny

        #region Contract
        //add contract
        public void addContract(Contract contract)
        {
            contract.NumContract = 10000000 + DataSource.listContract.Count() + 1;//update num contract
            DataSource.listContract.Add(contract);
        }
        //delete contract
        public void deleteContract(Contract contract)
        {
            int contractIndex = DataSource.listContract.FindIndex(x => x.NumContract == contract.NumContract);
            if(contractIndex==-1)
            {
                throw new Exception("The contract not exist");
            }
            DataSource.listContract.RemoveAt(contractIndex);
        }
        //update contract
        public void reContract(Contract contract)
        {
            int contractIndex = DataSource.listContract.FindIndex(x => x.NumContract == contract.NumContract);
            if (contractIndex == -1)
            {
                throw new Exception("The contract not exist");
            }
            DataSource.listContract[contractIndex] = contract;
        }
        #endregion Contract
      
        #region getList
        //get all the children
        public IEnumerable<Child> getChildren(Func<Child, bool> predicate=null)
        {
            if (predicate == null)
            {
                return DataSource.listChild.AsEnumerable();
            }
            return DataSource.listChild.Where(predicate);
        }

        //get all the children by mom
        public IEnumerable<IGrouping<int,Child>> getChildrenByMom()
        {
            return from item in DataSource.listChild
                   group item by item.idMom;

        }

        //get all the contract
        public IEnumerable<Contract> getContracts(Func<Contract, bool> predicate = null)
        {
            if (predicate == null)
            {
                return DataSource.listContract.AsEnumerable();
            }
            return DataSource.listContract.Where(predicate);
        }

        //get all the mothers
        public IEnumerable<Mother> getMothers(Func<Mother, bool> predicate = null)
        {
            if (predicate == null)
            {
                return DataSource.listMother.AsEnumerable();
            }
            return DataSource.listMother.Where(predicate);
        }

        //get all the nannies
        public IEnumerable<Nanny> getNannies(Func<Nanny, bool> predicate = null)
        {
            if (predicate == null)
            {
                return DataSource.listNanny.AsEnumerable();
            }
            return DataSource.listNanny.Where(predicate);
        }
        #endregion getList


        #region check id
        //this function checks if the id does not exists in the system

        public bool checkId(int newId)
        {
            int counter = 0;
            IEnumerable<Child> childTemp = from Child temp in DataSource.listChild
                                           where (temp.id == newId)
                                           select temp;
            counter += childTemp.Count<Child>();
            IEnumerable<Mother> momTemp = from Mother temp in DataSource.listMother
                                          where (temp.id == newId)
                                          select temp;
            counter += momTemp.Count<Mother>();
            IEnumerable<Nanny> nannyTemp = from Nanny temp in DataSource.listNanny
                                           where (temp.id == newId)
                                           select temp;
            counter += nannyTemp.Count<Nanny>();
            return counter != 0;

        }

        #endregion

       
    }
}
