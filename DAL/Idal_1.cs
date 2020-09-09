using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
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

        IEnumerable<Nanny> getNannies(Func<Nanny,bool> predicate=null);
        IEnumerable<Mother> getMothers(Func<Mother, bool> predicate=null);
        IEnumerable<IGrouping<int, Child>> getChildrenByMom();
        IEnumerable<Child> getChildren(Func<Child, bool> predicate=null);
        IEnumerable<Contract> getContracts(Func<Contract, bool> predicate=null);
        bool checkId(int newId);
    }
}
