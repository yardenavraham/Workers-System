using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        void addNanny(Nanny nanny);
        void deleteNanny(Nanny nanny);
        void reNanny(Nanny nanny);

        void addMother(Mother mother);
        void deleteMother(Mother mother);
        void reMother(Mother mother);

        void addChild(Child child);
        void deleteChild(Child child);
        void reChild(Child child);

        void addContract(Contract contract);
        void deleteContract(Contract contract);
        void reContract(Contract contract);
        Contract updateDataContract(Contract contract);

        IEnumerable<Nanny> getNannies(Func<Nanny, bool> predicate = null);
        IEnumerable<Mother> getMothers(Func<Mother, bool> predicate = null);
        IEnumerable<IGrouping<int, Child>> getChildrenByMom();
        IEnumerable<Child> getChildren(Func<Child, bool> predicate = null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> predicate = null);

        bool checkId(int newId);
        int ageByMonth(DateTime bDay);

        #region function
        IEnumerable<Child> getChildrenWithoutNanny();
        IEnumerable<Nanny> nanniesByTMT();
        double avgAge();
        IEnumerable<int> phonesBookOfNanny(int idNanny);
        IEnumerable<IGrouping<int, Nanny>> nanniesByExperience();
        bool hasASpecialChild(int idNanny);
        int numChildrenNoContractInArea(string nannyAddress);
        double avgPriceOfNannies(bool hourOrMonth);
        double CalculateDistance(string source, string dest);
        IEnumerable<Nanny> nanniesByDistance(string momAddress, int distance = 5);
        IEnumerable<Nanny> nanniesByTime(bool[] momDays, double[,] momHours,int j, bool isCompromise = false);
        IEnumerable<Nanny> nanniesByConstraints(Mother mom);
        IEnumerable<Nanny> nanniesByConstraintsWithCompromise(Mother mom);
        double salaryCalculate(Contract contract, int numSibling, bool whichFunc);
        int numContractsByCondition(Func<Contract, bool> predicate);
        IEnumerable<IGrouping<int, Nanny>> nanniesByAgeChildren(bool minOrMax, bool sort = false);
        IEnumerable<IGrouping<int, Contract>> contractsByDistance(bool sort=false);
        double ageAsYears(int ageByMonth);
#endregion function
    }
}
