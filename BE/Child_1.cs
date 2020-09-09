using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {       

        public int id { get; set; }
        public int idMom { get; set; }
        public string firstName { get; set; }
        public DateTime dateBirth { get; set; }
        public bool isSpecial { get; set; }
        public string specialNeeds { get; set; }
        


        public override string ToString()
        {
           string tspecial;
           if (isSpecial) { tspecial = "yes"; } else { tspecial = "no"; }
            return "id: " + id + "\nid mother: " + idMom + "\nfirst name: " + firstName + "\nbirthday: " + dateBirth + "\nis special? " + tspecial + "\nspecial needs: " + specialNeeds;
        }
    }
}
