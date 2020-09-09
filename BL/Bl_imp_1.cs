using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
//using DAL;

namespace BL
{
    public class Bl_imp: IBL
    {
        DAL.Idal dal;
        public Bl_imp()
        {
            DAL.FactoryDal factory = new DAL.FactoryDal();
            dal = factory.getDal();
        }

 #region Child
 

        public void addChild(Child child)
        {
            dal.addChild(child);
        }
        public void deleteChild(Child child)
        {
            dal.deleteChild(child);
        }
        public void reChild(Child child)
        {
            dal.reChild(child);
        }

        //functions

        public IEnumerable<Child> getChildrenWithoutNanny()
        {
            return from child in dal.getChildren()
                   where !(dal.getContracts().Any(item2 => item2.IdChild == child.id))//Any return true if the child has a contract; if not, false.
                   select child;
        }
        //מחזירה את ממוצע גילאי הילדים במערכת
        public double avgAge()
        {
            var v = getChildren();
            double ageSum = 0;
            foreach (var child in v)
            {
                ageSum += ageAsYears(child.dateBirth);
            }
            return ageSum / v.Count();
        }
        #endregion Child

 #region Mother
        public void addMother(Mother mother)
        {
            dal.addMother(mother);
        }
        public void deleteMother(Mother mother)
        {
            dal.deleteMother(mother);
        }

        public void reMother(Mother mother)
        {
            dal.reMother(mother);
        }
        //מחזיר ספר טלפונים של אמהות של ילדים שנמצאים אצל מטפלת מסוימת
        public IEnumerable<int> phonesBookOfNanny(int idNanny)
        {
            return from contract in getContracts(x => x.IdNanny == idNanny)
                   select getMothers(t => t.id == contract.IdMom).First().phone;
        }
#endregion Mother

 #region Nanny
        public void addNanny(Nanny nanny)
        {
            if (nanny.bDay.AddYears(18).CompareTo(DateTime.Now)>0)
            {
                throw new Exception("The nanny is too young");
            }
            dal.addNanny(nanny);
        }
        public void deleteNanny(Nanny nanny)
        {
            dal.deleteNanny(nanny);
        }
        public void reNanny(Nanny nanny)
        {
            dal.reNanny(nanny);
        }

        //function
        public IEnumerable<Nanny> nanniesByTMT()
        {
            return getNannies(t => t.daysOff);
        }
        //מחזירה את רשימת המטפלות לפי נסיון
        public IEnumerable<IGrouping<int, Nanny>> nanniesByExperience()
        {
            return from nanny in getNannies()
                   group nanny by nanny.yearsOfExperience;
        }
        //מחזירה האם למטפלת יש ילד עם צרכים מיוחדים
        public bool hasASpecialChild(int idNanny)
        {
            var v = from contract in getContracts(t => t.IdNanny == idNanny)
                    where getChildren(x => x.id == contract.IdChild).First().isSpecial
                    select contract;
            return v.Count() != 0;
        }
        //מחזירה כמה ילדים ללא חוזה יש באזור המטפלת
        public int numChildrenNoContractInArea(string nannyAddress)
        {
            int count=0;
            var children = getChildrenWithoutNanny();
            foreach (var mom in getMothers())
            {
                if (children.Count(x=>x.idMom==mom.id)>0&&CalculateDistance(nannyAddress,mom.nannyAddress)<=10)
                {
                    count += children.Count(x => x.idMom == mom.id);
                }
            }
            return count;
        }
        //מחזירה ממוצעי המחירים של המטפלות לשעה או לחודש
        public double avgPriceOfNannies(bool hourOrMonth)
        {
            double sumPrice = 0;

            if (hourOrMonth)//by hour
            {
                foreach (var nanny in getNannies())
                {
                    sumPrice += nanny.hourlyRate;
                }
                return sumPrice / getNannies().Count();
            }
            else//by month
            {
                foreach (var nanny in getNannies())
                {
                    sumPrice += nanny.monthlyRate;
                }
                return sumPrice / getNannies().Count();
            }
        }
        #endregion Nanny

 #region Contract
        public void addContract(Contract contract)
        {
            if (getContracts(item => item.IdChild == contract.IdChild).Count() != 0)//checks if there is other contract to the child
            {
                throw new Exception("This child has another contract");
            }
            IEnumerable<Child> listchild = getChildren(x=>x.id==contract.IdChild);//child
            IEnumerable<Nanny> listnanny = getNannies(x => x.id == contract.IdNanny);//nanny
            if (listchild.Count() == 0 || listnanny.Count() == 0)
            {
                throw new Exception("The nanny or the child are not exist in the system");
            }
            Child child = listchild.First();
            Nanny nanny = listnanny.First();
            Mother mom = getMothers(x => x.id == child.idMom).First();
            contract.IdMom =mom.id;
            int ageChild = ageByMonth(child.dateBirth);//checks the age of the child in months
            if (ageChild < nanny.minAge && ageChild > nanny.maxAge)//checks the range
            {
                throw new Exception("The child is not within the age range of the nanny");
            }
            if (child.dateBirth.AddMonths(3).CompareTo(DateTime.Now) > 0)//checks if today the child is less than 3 months
            {
                throw new Exception("You can not create a contract for a child less than 3 months old");
            }
            
            int numSibling = getContracts().Where(x => x.IdNanny == contract.IdNanny && x.IdMom == contract.IdMom).Count();
            if (contract.HourOrMonth) contract.HourPayment = salaryCalculate(contract, numSibling); else contract.MonthPayment = salaryCalculate(contract, numSibling);
            if (getContracts(x=>x.IdNanny==contract.IdNanny).Count()==nanny.maxKids)
            {
                throw new Exception("The nanny can not get any more children");
            }
            contract.ageChild = ageAsYears(child.dateBirth);            
            string momAddress = mom.nannyAddress;
            if (momAddress==null)
            {
                momAddress = mom.address;
            }
            string nannyAddress = nanny.address;
            contract.distance = CalculateDistance(momAddress, nannyAddress);
            dal.addContract(contract);
        }
        public void deleteContract(Contract contract)
        {
            dal.deleteContract(contract);
        }
        public void reContract(Contract contract)
        {
            dal.reContract(contract);
        }
        //function
        public int CalculateDistance(string source, string dest)
        {
            return 4;
        }
        public IEnumerable<Nanny> nanniesByDistance(string momAddress, int distance=5)
        {
            return from nanny in getNannies()
                   where CalculateDistance(momAddress, nanny.address) <= distance
                   select nanny;
        }
        public IEnumerable<Nanny> nanniesByTime(bool[] momDays, double[,] momHours,int j=0, bool isCompromise=false)
        {
            if(isCompromise)
            {
                List<Nanny> nannies = new List<Nanny>();
                foreach (var nanny in getNannies())
                {
                    int countDays=0;
                    int[] countHours = { 0,0,0,0,0,0 };
                    for (int i = 0; i < 6; i++)
                    {                
                        if (momDays[i] && !nanny.daysOfWork[i])
                        {
                            countDays++;
                        }
                        if (momDays[i] && (nanny.hoursOfWork[1,i]-(j+1)>=momHours[1,i]&& momHours[2, i] <= nanny.hoursOfWork[2, i]))//begin time
                        {
                            countHours[i]++;
                        }
                        if(momDays[i]&& momHours[1, i] >= nanny.hoursOfWork[1, i] && nanny.hoursOfWork[2, i] + j+1 <= momHours[2, i])//end time
                        {
                            countHours[i]++;
                        }
                    }
                    if (countDays<=j&&countHours.All(x=>x==0))
                    {
                        nannies.Add(nanny);
                    }
                }
                return nannies.AsEnumerable();

            }
            else
            {
                List<Nanny> nannies = new List<Nanny>();
                foreach (var nanny in getNannies())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (momDays[i] && nanny.daysOfWork[i])//check days
                        {
                            if (momHours[1, i] >= nanny.hoursOfWork[1, i] && momHours[2, i] <= nanny.hoursOfWork[2, i])//check hours
                            {
                                nannies.Add(nanny);
                            }
                        }
                    }
                }
                return nannies.AsEnumerable();
            }
        }
        public IEnumerable<Nanny> nanniesByConstraints(Mother mom)
        {
            string momAddress;
            if (mom.nannyAddress!=null)
            {
                momAddress = mom.nannyAddress;
            }
            else
            {
                momAddress = mom.address;
            }
            var v = from nanny1 in nanniesByDistance(momAddress)
                    from nanny2 in nanniesByTime(mom.neededDays, mom.neededHours)
                    where nanny1.id == nanny2.id
                    select nanny1;
            return v;
        }
        public IEnumerable<Nanny> nanniesByConstraintsWithCompromise(Mother mom)
        {
            if (getNannies().Count()<=5)
            {
                return getNannies();
            }
            string momAddress=mom.nannyAddress;
            int j = 1,d=10;
            var v = from nanny1 in nanniesByDistance(momAddress, d)
                    from nanny2 in nanniesByTime(mom.neededDays, mom.neededHours, j, true)
                    where nanny1.id == nanny2.id
                    select nanny1;
            while (v.Count()<=5)
            {
                j++;
                d += 5;
                v = from nanny1 in nanniesByDistance(momAddress, d)
                    from nanny2 in nanniesByTime(mom.neededDays, mom.neededHours,j, true)
                    where nanny1.id == nanny2.id
                    select nanny1;             
            }            
            return v;
        }
        public double salaryCalculate(Contract contract,int numSibling)
        {
            double salary;
            int numDiscount = numSibling * 2;
            if (contract.HourOrMonth)
            {
                salary= getNannies(x => x.id == contract.IdNanny).First().hourlyRate * contract.numHoursPerWeek * 4 ;

            }
            else
            {
                salary= getNannies(x => x.id == contract.IdNanny).First().monthlyRate;
            }
            salary *= (double)(100 - numDiscount) / 100;
            return salary;
        }
        public int numContractsByCondition(Func<Contract, bool> predicate)
        {
            return getContracts(predicate).Count();
        }
        public IEnumerable< IGrouping<int,Nanny>> nanniesByAgeChildren(bool minOrMax, bool sort=false)
        {
            
            if (sort)
            {
                if (minOrMax)
                {
                    return from nanny in getNannies()
                           orderby nanny.lastName[0]
                           group nanny by nanny.minAge;
                }
                else
                {
                    return from nanny in getNannies()
                           orderby nanny.lastName[0]
                           group nanny by nanny.maxAge;
                }
            }
            else
            {
                if (minOrMax)
                {
                    return from nanny in getNannies()
                           group nanny by nanny.minAge;
                }
                else
                {
                    return from nanny in getNannies()
                           group nanny by nanny.maxAge;
                }
            }
        }
        public IEnumerable<IGrouping<int,Contract>> contractsByDistance(bool sort)
        {
            if (sort)
            {
                return from contract in getContracts()
                       orderby contract.NumContract
                       group contract by (int)Math.Ceiling(contract.distance / 5);
            }
            else
            {
                return from contract in getContracts()
                       group contract by (int)Math.Ceiling(contract.distance / 5);
            }
        }
        #endregion Contract

 #region getList
        public IEnumerable<IGrouping<int, Child>> getChildrenByMom()
        {
            return dal.getChildrenByMom();
        }
        public IEnumerable<Child> getChildren(Func<Child, bool> predicate = null)
        {
            return dal.getChildren(predicate);
        }
        public IEnumerable<Contract> getContracts(Func<Contract, bool> predicate = null)
        {
            return dal.getContracts(predicate);
        }

        public IEnumerable<Mother> getMothers(Func<Mother, bool> predicate = null)
        {
            return dal.getMothers(predicate);
        }

        public IEnumerable<Nanny> getNannies(Func<Nanny, bool> predicate = null)
        {
            return dal.getNannies(predicate);
        }
    
        #endregion getList

 #region general functions
        public bool checkId(int newId)
        {
            return dal.checkId(newId);
        }
        public double ageAsYears(DateTime bDay)
        {
            double age;
            TimeSpan ageDays = DateTime.Now.Subtract(bDay);
            int days = (int)ageDays.TotalDays;
            int years = days/365;
            int thisMonth = DateTime.Now.Month;
            if (thisMonth>=1&&thisMonth<=6)
            {
                if (bDay.Month>=1&&bDay.Month<=6)
                {
                    age = years;
                }
                else
                {
                    age = years - 0.5;
                }
            }
            else
            {
                if (bDay.Month >= 1 && bDay.Month <= 6)
                {
                    age = years+0.5;
                }
                else
                {
                    age = years;
                }
            }
            return age;
        }
        public int ageByMonth(DateTime bDay)
        {
            TimeSpan ageDays = DateTime.Now.Subtract(bDay);
            double days = ageDays.TotalDays;
            int months = (int)Math.Floor(days / 30);
            return months;
        }
        #endregion general functions
    }
}
