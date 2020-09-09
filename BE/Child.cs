using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BE
{
    public class Child:INotifyPropertyChanged
    {
        public Child()
        {
           
        }
 
        private double _ageChild { get; set; }
        public double ageChild
        {
            get
            {
                return _ageChild;
            }
            set
            {
                _ageChild = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ageChild"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int id { get; set; }
        public int idMom { get; set; }
        public string firstName { get; set; }
        public DateTime bDay { get; set; }
        public bool isSpecial { get; set; }
        public string specialNeeds { get; set; }
        public string idAndName
        {
            get { return string.Format("{0} {1}", id, firstName); }
            set { }
        }
        
        public override string ToString()
        {
           string tspecial;
           if (isSpecial) { tspecial = "yes"; } else { tspecial = "no"; }
            return "id: " + id + "\nid mother: " + idMom + "\nfirst name: " + firstName + "\nbirthday: " + bDay.ToString("dd/MM/yyyy") + "\nis special? " + tspecial + "\nspecial needs: " + specialNeeds;
        }
    }
}
