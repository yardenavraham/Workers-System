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
            dal = DAL.FactoryDal.getDal();
            //enterData();
        }
        //public void enterData()
        //{
        //    double[,] momHours1 = new double[2, 6];
        //    double[,] nannyHours1 = new double[2, 6];
        //    double[,] momHours2 = new double[2, 6];
        //    double[,] nannyHours2 = new double[2, 6];
        //    for (int i = 1; i < 3; i++)
        //    {
        //        for (int j = 0; j < 6; j++)
        //        {
        //            momHours1[i - 1, j] = 8 * i;
        //            momHours2[i - 1, j] = 9 * i;
        //            nannyHours1[i - 1, j] = 8 * i;
        //            nannyHours2[i - 1, j] = 7 * i;
        //        }
        //    }
        //    addMother(new Mother
        //    {
        //        id = 318208527,
        //        address = "מנוחה ונחלה,רחובות,ישראל",
        //        firstName = "Miriam",
        //        lastName = "Barilan",
        //        startPhone = "054",
        //        endPhone = 8311420,
        //        remarks = "no",
        //        neededDays = new bool[6] { true, false, true, true, true, false },
        //        neededHours = momHours1
        //    });
        //    addMother(new Mother
        //    {
        //        id = 123456789,
        //        address = "fl,rehovot",
        //        firstName = "Talia",
        //        lastName = "Tzameret",
        //        nannyAddress = "כנפי נשרים,ירושלים,ישראל",
        //        startPhone = "052",
        //        endPhone = 4130990,
        //        remarks = "no",
        //        neededDays = new bool[6] { false, true, true, true, true, false },
        //        neededHours = momHours2
        //    });
        //    addChild(new Child
        //    {
        //        id = 316261882,
        //        idMom = 318208527,
        //        firstName = "yarden",
        //        bDay = new DateTime(2014, 4, 3),
        //        isSpecial = true,
        //        specialNeeds = "alergy to milk",

        //    });
        //    addChild(new Child
        //    {
        //        id = 23445,
        //        idMom = 318208527,
        //        firstName = "Tamar",
        //        bDay = new DateTime(2017, 5, 30),
        //        isSpecial = false,
        //        specialNeeds = "nothing"
        //    });
        //    addChild(new Child
        //    {
        //        id = 3442,
        //        idMom = 123456789,
        //        firstName = "Rotem",
        //        bDay = new DateTime(2015, 5, 2),
        //        isSpecial = false,
        //        specialNeeds = "nothing"
        //    });
        //    addChild(new Child
        //    {
        //        id = 876579,
        //        idMom = 123456789,
        //        firstName = "Tom",
        //        bDay = new DateTime(2017, 5, 2),
        //        isSpecial = false,
        //        specialNeeds = "",

        //    });
        //    addNanny(new Nanny
        //    {
        //        id = 109,
        //        address = "יעקב,רחובות,ישראל",
        //        bDay = new DateTime(1996, 12, 1),
        //        elevator = true,
        //        phone = 405,
        //        floor = 2,
        //        yearsOfExperience = 10,
        //        maxAge = 60,
        //        minAge = 5,
        //        monthlyRate = 1000,
        //        firstName = "Gila",
        //        lastName = "bald",
        //        maxKids = 5,
        //        hoursOfWork = nannyHours1,
        //        daysOfWork = new bool[6] { true, true, true, true, true, true },
        //        daysOff = true,
        //        allowsHourlyRate = true,
        //        hourlyRate = 10,
        //        recommendations = "שומרת כשרות"
        //    });
        //    addNanny(new Nanny
        //    {
        //        id = 39,
        //        address = "בית הדפוס,ירושלים,ישראל",
        //        bDay = new DateTime(1980, 12, 1),
        //        elevator = true,
        //        phone = 4067,
        //        floor = 2,
        //        yearsOfExperience = 20,
        //        maxAge = 50,
        //        minAge = 5,
        //        monthlyRate = 2000,
        //        firstName = "Sara",
        //        lastName = "bal",
        //        maxKids = 4,
        //        hoursOfWork = nannyHours2,
        //        daysOfWork = new bool[6] { true, false, true, true, true, true },
        //        daysOff = false,
        //        allowsHourlyRate = true,
        //        hourlyRate = 20,
        //        recommendations = "ניתן לקבל המלצות"
        //    });
        //    addNanny(new Nanny
        //    {
        //        id = 543439,
        //        address = "בני משה,רחובות,ישראל",
        //        bDay = new DateTime(1980, 12, 1),
        //        elevator = true,
        //        phone = 4067,
        //        floor = 2,
        //        yearsOfExperience = 20,
        //        maxAge = 60,
        //        minAge = 5,
        //        monthlyRate = 2000,
        //        firstName = "ana",
        //        lastName = "a",
        //        maxKids = 4,
        //        hoursOfWork = nannyHours2,
        //        daysOfWork = new bool[6] { true, false, true, true, true, true },
        //        daysOff = false,
        //        allowsHourlyRate = true,
        //        hourlyRate = 20,
        //        recommendations = "ניתן לקבל המלצות"
        //    });
        //    addContract(new Contract
        //    {
        //        IdChild = 23445,
        //        IdMom = 234,
        //        IsContract = true,
        //        IdNanny = 39,
        //        IsMeeting = true,
        //        BeginWork = new DateTime(2017, 12, 15),
        //        EndWork = new DateTime(2018, 12, 15),
        //        HourOrMonth = false,
        //        numHoursPerWeek = 32,

        //    });
        //    addContract(new Contract
        //    {
        //        IdChild = 3442,
        //        IdMom = 3,
        //        IsContract = true,
        //        IdNanny = 39,
        //        IsMeeting = true,
        //        BeginWork = new DateTime(2017, 12, 15),
        //        EndWork = new DateTime(2018, 12, 15),
        //        HourOrMonth = true,
        //        numHoursPerWeek = 20,

        //    });
        //    addContract(new Contract
        //    {
        //        IdChild = 316261882,
        //        IdMom = 234,
        //        IsContract = true,
        //        IdNanny = 109,
        //        IsMeeting = true,
        //        BeginWork = new DateTime(2017, 12, 15),
        //        EndWork = new DateTime(2018, 12, 15),
        //        HourOrMonth = false,
        //        numHoursPerWeek = 32,

        //    });
        //}

        #region Child


        public void addChild(Child child)
        {
            //הייתה אמורה להיות בדיקה של האמא, מחקנו בגלל הקומבו בוקס
            dal.addChild(child);
        }//הוספת ילד
        public void deleteChild(Child child)
        {
            dal.deleteChild(child);
        }//מחיקת ילד
        public void reChild(Child child)
        {
            
            dal.reChild(child);
            IEnumerable<Contract> contracts = getContracts(x => x.IdChild == child.id);
            if (contracts.Count() != 0)
            {
                reContract(contracts.First());
            }
        }//עדכון ילד

        //functions
        //ילדים ללא מטפלת
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
                ageSum += ageAsYears(ageByMonth( child.bDay));
            }
            return ageSum / v.Count();
        }
        #endregion Child

 #region Mother
        public void addMother(Mother mother)
        {
            if (mother.nannyAddress == null||mother.nannyAddress=="")
            {
                mother.nannyAddress = mother.address;
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (mother.neededHours[i,j]<0|| mother.neededHours[i, j]>23.59|| (mother.neededHours[i, j]*100)%100>59)
                    {
                        throw new Exception("You can enter hours only between 00.00-23.59");
                    }
                }
            }
            dal.addMother(mother);
        }//הוספת אמא
        public void deleteMother(Mother mother)
        {
            dal.deleteMother(mother);
        }//מחיקת אמא
        public void reMother(Mother mother)
        {
            if (mother.nannyAddress == null || mother.nannyAddress == "")
            {
                mother.nannyAddress = mother.address;
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (mother.neededHours[i, j] < 0 || mother.neededHours[i, j] > 23.59 || (mother.neededHours[i, j] * 100) % 100 > 59)
                    {
                        throw new Exception("You can enter hours only between 00.00-23.59");
                    }
                }
            }
            
            dal.reMother(mother);
            List<Contract> contracts = getContracts(x => x.IdMom == mother.id).ToList();
            if (contracts.Count() != 0)
            {
                foreach (Contract item in contracts)
                {
                    reContract(item);
                }
            }
        }//עדכון אמא

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
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (nanny.hoursOfWork[i, j] < 0 || nanny.hoursOfWork[i, j] > 23.59 || (nanny.hoursOfWork[i, j] * 100) % 100 > 59)
                    {
                        throw new Exception("You can enter hours only between 00.00-23.59");
                    }
                }
            }
            if (nanny.bDay.AddYears(18).CompareTo(DateTime.Now)>0)
            {
                throw new Exception("The nanny is too young");
            }
            dal.addNanny(nanny);
        }//הוספת מטפלת
        public void deleteNanny(Nanny nanny)
        {
            dal.deleteNanny(nanny);
        }//מחיקת מטפלת
        public void reNanny(Nanny nanny)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (nanny.hoursOfWork[i, j] < 0 || nanny.hoursOfWork[i, j] > 23.59 || (nanny.hoursOfWork[i, j] * 100) % 100 > 59)
                    {
                        throw new Exception("You can enter hours only between 00.00-23.59");
                    }
                }
            }
            dal.reNanny(nanny);
            List<Contract> contracts = getContracts(x => x.IdNanny == nanny.id).ToList();
            if (contracts.Count() != 0)
            {
                foreach (Contract item in contracts)
                {
                    reContract(item);
                }
            }
          
        }//עדכון מטפלת

        //function

        //רשימת מטפלות שעובדות לפי ימי החופש של התמת
        public IEnumerable<Nanny> nanniesByTMT()
        {
            return getNannies(t => t.daysOff);
        }
        //רשימת המטפלות לפי נסיון
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
            Contract newContract = updateDataContract(contract);

            dal.addContract(contract);
        }//הוספת חוזה
        public Contract updateDataContract(Contract contract)
        {

            Child child = getChildren(x => x.id == contract.IdChild).First();//הילד
            Nanny nanny = getNannies(x => x.id == contract.IdNanny).First();//המטפלת
            Mother mom = getMothers(x => x.id == child.idMom).First();//האמא

            //נתוני עזר
            int ageChildByMonth = ageByMonth(child.bDay);//גיל לפי חודשים
            int numSibling = getContracts().Where(x => x.IdNanny == contract.IdNanny && x.IdMom == contract.IdMom && x.IdChild != contract.IdChild).Count();

            //עדכון נתוני החוזה
            contract.IdMom = mom.id;//ת.ז
            if (nanny.allowsHourlyRate) contract.HourPayment = salaryCalculate(contract, numSibling, true);//שכר לפי שעה
            contract.MonthPayment = salaryCalculate(contract, numSibling, false);//שכר לפי חודש
            contract.ageChild = ageAsYears(ageChildByMonth);//גיל לפי שנים
            contract.momAddress = mom.nannyAddress;//כתובת האמא          
            contract.nannyAddress = nanny.address;//כתובת המטפלת

            if (ageChildByMonth<3)//checks if today the child is less than 3 months
            {
                throw new Exception("You can not create a contract for a child less than 3 months old");
            }

            if (ageChildByMonth < nanny.minAge || ageChildByMonth > nanny.maxAge)//checks the range
            {
                throw new Exception("The child is not within the age range of the nanny");
            }


            //בודק את כמות הילדים שנמצאים אצל המטפלת
            if (getContracts(x => x.IdNanny == contract.IdNanny).Count() >= nanny.maxKids)
            {
                throw new Exception("The nanny can not get any more children");
            }
            
            return contract;
        }//בדיקת ועדכון נתוני החוזה
        public void deleteContract(Contract contract)
        {
            dal.deleteContract(contract);
        }//מחיקת חוזה
        public void reContract(Contract contract)
        {
            updateDataContract(contract);
            dal.reContract(contract);
        }//עדכון חוזה
        //function
        public double CalculateDistance(string source, string dest)
        {
            
            return GoogleApiFunc.CalculateDistance(source, dest)/1000.0;
        }//חישוב מרחק
        public IEnumerable<Nanny> nanniesByDistance(string momAddress, int distance=5)
        {
            return from nanny in getNannies()
                   where (CalculateDistance(momAddress, nanny.address) <= distance)
                   select nanny;
        }//מטפלות קרובות לפי המרחק
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
                        if (momDays[i] && (nanny.hoursOfWork[0,i]-(j+1)>=momHours[0,i]&& momHours[1, i] <= nanny.hoursOfWork[1, i]))//begin time
                        {
                            countHours[i]++;
                        }
                        if(momDays[i]&& momHours[0, i] >= nanny.hoursOfWork[0, i] && nanny.hoursOfWork[1, i] + j+1 <= momHours[1, i])//end time
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
                bool flag = true;
                foreach (var nanny in getNannies())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (momDays[i])//check days
                        {
                            if (nanny.daysOfWork[i]&&momHours[0, i] >= nanny.hoursOfWork[0, i] && momHours[1, i] <= nanny.hoursOfWork[1, i])//check hours
                            { }
                            else
                            {
                                flag = false;
                            }                                                          
                        }
                    }
                    if(flag) nannies.Add(nanny);
                    flag = true;
                }
                return nannies.AsEnumerable();
            }
        }//מטפלות טובות לפי השעות
        public IEnumerable<Nanny> nanniesByConstraints(Mother mom)
        {
           
            var v = from nanny1 in nanniesByDistance(mom.nannyAddress)
                    from nanny2 in nanniesByTime(mom.neededDays, mom.neededHours)
                    where nanny1.id == nanny2.id
                    select nanny1;
            
            return v;
        }//המטפלות המתאימות בדיוק
        public IEnumerable<Nanny> nanniesByConstraintsWithCompromise(Mother mom)
        {
            if (getNannies().Count()<=5)
            {
                return getNannies();
            }
            int j = 1,d=10;
            var v = from nanny1 in nanniesByDistance(mom.nannyAddress, d)
                    from nanny2 in nanniesByTime(mom.neededDays, mom.neededHours, j, true)
                    where nanny1.id == nanny2.id
                    select nanny1;
            while (v.Count()<=5)
            {
                j++;
                d += 5;
                v = from nanny1 in nanniesByDistance(mom.nannyAddress, d)
                    from nanny2 in nanniesByTime(mom.neededDays, mom.neededHours,j, true)
                    where nanny1.id == nanny2.id
                    select nanny1;             
            }
            if (v.Count() > 5)
            {
                List<Nanny> t = new List<Nanny>();
                for (int i = 0; i < 5; i++)
                {
                    t.Add(v.ElementAt(i));
                }
                return t;
            }
            return v;
        }//חמשת המטפלות הקרובות ביותר
        public double salaryCalculate(Contract contract,int numSibling,bool whichFunc)
        {
            double salary;
            int numDiscount = numSibling * 2;
            if (whichFunc)
            {
                salary= getNannies(x => x.id == contract.IdNanny).First().hourlyRate * contract.numHoursPerWeek * 4 ;

            }
            else
            {
                salary= getNannies(x => x.id == contract.IdNanny).First().monthlyRate;
            }
            salary *= (double)(100 - numDiscount) / 100;
            return salary;
        }//חישוב השכר החודשי
        public int numContractsByCondition(Func<Contract, bool> predicate)
        {
            return getContracts(predicate).Count();
        }//מספר החוזים המקיימים תנאי כלשהו
        public IEnumerable< IGrouping<int,Nanny>> nanniesByAgeChildren(bool minOrMax, bool sort=false)
        {
            
            if (sort)
            {
                if (minOrMax)
                {
                    return from nanny in getNannies()
                           orderby nanny.lastName
                           group nanny by nanny.minAge;
                }
                else
                {
                    return from nanny in getNannies()
                           orderby nanny.lastName
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
        }//חלוקה לקבוצות של המטפלות לפי גיל מינימלי/מקסימלי של הילדים
        public IEnumerable<IGrouping<int, Contract>> contractsByDistance(bool sort)
        {
            if (sort)
            {
                return from contract in getContracts()
                        orderby contract.NumContract
                        group contract by (int)CalculateDistance(contract.momAddress, contract.nannyAddress);
               

            }
            else
            {
                return from contract in getContracts()
                        group contract by (int)CalculateDistance(contract.momAddress, contract.nannyAddress);
            }

        }//חלוקה לקבוצות של החוזים לפי מרחק
        #endregion Contract

 #region getList 
        //get all the lists
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

        }//בדיקה של הת.ז
        public double ageAsYears(int ageByMonth)
        {
            int years = ageByMonth / 12;
            int months = ageByMonth % 12;
            if (months<=6)
            {
                return years;
            }
            return years + 0.5;
        }//גיל לפי שנים
        public int ageByMonth(DateTime bDay)
        {
            TimeSpan ageDays = DateTime.Now.Subtract(bDay);
            double days = ageDays.TotalDays;
            int months = (int)Math.Floor(days / 30);
            return months;
        }//גיל לפי חודשים
        #endregion general functions
    }
}
