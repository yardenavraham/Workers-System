using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BE
{
    public class Contract:INotifyPropertyChanged
    {
        public int NumContract { get; set; }
        public int IdChild { get; set; }
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
        public int IdNanny { get; set; }
        public int IdMom { get; set; }
        public string momAddress { get; set; }
        public string nannyAddress { get; set; }
        public bool IsMeeting { get; set; }
        public bool IsContract { get; set; }
        private double _HourPayment;
        public double HourPayment
        {
            get
            {
                return _HourPayment;
            }
            set
            {
                _HourPayment = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("HourPayment"));
                }
            }
        }
        private double _MonthPayment;
        public double MonthPayment
        {
            get
            {
                return _MonthPayment;
            }
            set
            {
                _MonthPayment = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MonthPayment"));
                }
            }
        }
        public bool HourOrMonth { get; set; }
        public EHourOrMonth HourOrMonthProp
        {
            get
            {
                if (HourOrMonth)
                {
                    return EHourOrMonth.Hour;
                }
                else
                {
                    return EHourOrMonth.Month;
                }
            }
            set
            {
                if (value == EHourOrMonth.Hour)
                {
                    HourOrMonth = true; ;
                }
                else
                {
                    HourOrMonth = false;
                }
            }
        }
        public DateTime BeginWork { get; set; }
        public DateTime EndWork { get; set; }
        public int numHoursPerWeek { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            string tmeeting, tcontract, thourormonth;
            
            if(IsMeeting) { tmeeting = "yes"; } else { tmeeting = "no"; }
            if (IsContract) { tcontract = "yes"; } else { tcontract = "no"; }
            if(HourOrMonth) { thourormonth = "hour"; } else { thourormonth = "month"; }
            return "num contract: " + NumContract + "\nid child: " + IdChild +"\nage child: "+ageChild+"\nId mother: "+IdMom+"\nid nanny: "+IdNanny+ "\nis meeting? "+  tmeeting + "\nis contract? " + tcontract + "\nhour payment: " + HourPayment + "\nmonth payment: " + MonthPayment + "\nhour or month? " + thourormonth + "\nbegin date: " + BeginWork.ToString("dd/MM/yyyy") + "\nend date: " + EndWork.ToString("dd/MM/yyyy") + "\num hours per week: "+numHoursPerWeek;

        }
    }
}
