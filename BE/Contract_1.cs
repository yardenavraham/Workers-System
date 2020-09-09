using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public int NumContract { get; set; }
        public int IdChild { get; set; }
        public double ageChild { get; set; }
        public int IdNanny { get; set; }
        public int IdMom { get; set; }
        public bool IsMeeting { get; set; }
        public bool IsContract { get; set; }
        public double HourPayment { get; set; }
        public double MonthPayment { get; set; }
        public bool HourOrMonth { get; set; }
        public DateTime BeginWork { get; set; }
        public DateTime EndWork { get; set; }
        public int numHoursPerWeek { get; set; }
        public bool isCompromise { get; set; }
        public double distance { get; set; }
        public override string ToString()
        {
            string tmeeting, tcontract, thourormonth;
            
            if(IsMeeting) { tmeeting = "yes"; } else { tmeeting = "no"; }
            if (IsContract) { tcontract = "yes"; } else { tcontract = "no"; }
            if(HourOrMonth) { thourormonth = "hour"; } else { thourormonth = "month"; }
            return "num contract: " + NumContract + "\nid child: " + IdChild +"\nage child: "+ageChild+"\nId mother: "+IdMom+"\nid nanny: "+IdNanny+ "\nis meeting? "+  tmeeting + "\nis contract? " + tcontract + "\nhour payment: " + HourPayment + "\nmonth payment: " + MonthPayment + "\nhour or month? " + thourormonth + "\nbegin date: " + BeginWork + "\nend date: " + EndWork+"\num hours per week: "+numHoursPerWeek+ "\nIs compromise? "+isCompromise+"\ndistance from mom to nanny: "+distance;

        }
    }
}
