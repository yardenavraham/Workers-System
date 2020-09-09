using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class Nanny
    {
        public Nanny getCopyNanny()
        {
            Nanny nanny = this.GetCopy();
            for (int i = 0; i < 6; i++)
            {
                nanny.daysOfWork[i] = this.daysOfWork[i];
                nanny.hoursOfWork[0, i] = this.hoursOfWork[0, i];
                nanny.hoursOfWork[1, i] = this.hoursOfWork[1, i];
            }
            return nanny;
        }
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string idAndName
        {
            get { return string.Format("{0} {1} {2}", id, firstName, lastName); }
            set { }
        }
        public DateTime bDay { get; set; }
        public int phone { get; set; }
        public string address { get; set; }
        public bool elevator { get; set; }
        public int floor { get; set; }
        public int yearsOfExperience { get; set; }
        public int maxKids { get; set; }
        public int minAge { get; set; }
        public int maxAge { get; set; }
        public bool allowsHourlyRate { get; set; }
        public double hourlyRate { get; set; }
        public double monthlyRate { get; set; }
        private bool[] mdaysOfWork = new bool[6];
        public bool[] daysOfWork
        {
            get
            {
                return mdaysOfWork;
            }
            set
            {
                for (int i = 0; i < 6; i++)
                {
                    mdaysOfWork[i] = value[i];
                }
            }
        }
        private double[,] mhoursOfWork = new double[2, 6];
        [XmlIgnore]
        public double[,] hoursOfWork
        {
            get
            {
                return mhoursOfWork;
            }
            set
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        mhoursOfWork[i, j] = value[i, j];
                    }

                }
            }
        }
        public string tempNeededHours
        {
            get
            {
                if (hoursOfWork == null)
                    return null;
                string result = "";
                int sizeA = hoursOfWork.GetLength(0);
                int sizeB = hoursOfWork.GetLength(1);
                result += "" + sizeA + "," + sizeB;
                for (int i = 0; i < sizeA; i++)
                    for (int j = 0; j < sizeB; j++)
                        result += "," + hoursOfWork[i, j];
                return result;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] values = value.Split(',');
                    int sizeA = int.Parse(values[0]);
                    int sizeB = int.Parse(values[1]);
                    hoursOfWork = new double[sizeA, sizeB];
                    int index = 2;
                    for (int i = 0; i < sizeA; i++)
                        for (int j = 0; j < sizeB; j++)
                            hoursOfWork[i, j] = double.Parse(values[index++]);
                }
            }
        }
        public bool daysOff { get; set; }

        public DaysOff daysOffProp
        {
            get
            {
                if (daysOff)
                {
                    return DaysOff.MinistryOfEducation;
                }
                else
                {
                    return DaysOff.TMT;
                }
            }
            set
            {
                if (value==DaysOff.MinistryOfEducation)
                {
                    daysOff = true; ;
                }
                else
                {
                    daysOff=false;
                }
            }
        }

        public string recommendations { get; set; }

        public Nanny()
        {
           

        }
        public override string ToString()
        {
            string tdaysOfWork="", thoursOfWork="", televator, tallowsHourlyRate, tdaysOff;
            for (int i = 0; i < 6; i++)
            {
                if (daysOfWork[i])
                {
                    switch(i)
                    {
                        case 0:
                            tdaysOfWork += "sunday";
                            thoursOfWork+="sunday: "+hoursOfWork[0,i]+"-"+hoursOfWork[1,i];
                            break;
                        case 1:
                            tdaysOfWork += ", monday";
                            thoursOfWork += "\nmonday: " + hoursOfWork[0, i] + "-" + hoursOfWork[1, i] ;
                            break;
                        case 2:
                            tdaysOfWork += ", tuesday";
                            thoursOfWork += "\ntuesday: " + hoursOfWork[0, i] + "-" + hoursOfWork[1, i];
                            break;
                        case 3:
                            tdaysOfWork += ", wednsday";
                            thoursOfWork += "\nwednsday: " + hoursOfWork[0, i] + "-" + hoursOfWork[1, i];
                            break;
                        case 4:
                            tdaysOfWork += ", thursday";
                            thoursOfWork += "\nthursday: " + hoursOfWork[0, i] + "-" + hoursOfWork[1, i];
                            break;
                        case 5:
                            tdaysOfWork += ", friday";
                            thoursOfWork += "\nfriday: " + hoursOfWork[0, i] + "-" + hoursOfWork[1, i] ;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (elevator) {televator = "yes";} else {televator = "no";}
            if (allowsHourlyRate) tallowsHourlyRate = "yes"; else tallowsHourlyRate = "no";
            if (daysOff)
            {
                tdaysOff = "Ministry of Education";
            }
            else
            {
                tdaysOff = "Ministry of Industry, Trade and Employment";
            }
            return "id: " + id + "\nlast name: " + lastName + "\nfirst name: " + firstName + "\nb-day: " + bDay.ToString("dd/MM/yyyy") + "\nphone: 0" + phone + "\naddress: " + address + "\nelevator? " + televator + "\nfloor: " + floor + "\nyears of experience: " + yearsOfExperience + "\nmax kids: " + maxKids + "\nmin age: " + minAge + "\nmax age: " + maxAge + "\nallows hourly rate? " + tallowsHourlyRate + "\nhourly rate: " + hourlyRate + "\nmonthly rate: " + monthlyRate + "\ndays of work: " + tdaysOfWork + "\nhours of work: " + thoursOfWork + "\ndays off according to: " + tdaysOff + "\nrecommendations: " + recommendations + "\n";

        }
    }
}
