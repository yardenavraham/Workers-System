using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {        
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
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
                mdaysOfWork = value;
            }
        }
        private double[,] mhoursOfWork = new double[2, 6];
        public double[,] hoursOfWork
        {
            get
            {
                return mhoursOfWork;
            }
            set
            {
                mhoursOfWork = value;
            }
        }
        public bool daysOff { get; set; }
        public string recommendations { get; set; }

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
                            thoursOfWork+="sunday: "+hoursOfWork[1,i]+"-"+hoursOfWork[2,i]+"\n";
                            break;
                        case 1:
                            tdaysOfWork += ", monday";
                            thoursOfWork += "\nmonday: " + hoursOfWork[1, i] + "-" + hoursOfWork[2, i] ;
                            break;
                        case 2:
                            tdaysOfWork += ", tuesday";
                            thoursOfWork += "\ntuesday: " + hoursOfWork[1, i] + "-" + hoursOfWork[2, i];
                            break;
                        case 3:
                            tdaysOfWork += ", wednsday";
                            thoursOfWork += "\nwednsday: " + hoursOfWork[1, i] + "-" + hoursOfWork[2, i];
                            break;
                        case 4:
                            tdaysOfWork += ", thursday";
                            thoursOfWork += "\nthursday: " + hoursOfWork[1, i] + "-" + hoursOfWork[2, i];
                            break;
                        case 5:
                            tdaysOfWork += ", friday";
                            thoursOfWork += "\nfriday: " + hoursOfWork[1, i] + "-" + hoursOfWork[2, i] ;
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
            return "id: " + id + "\nlast name: " + lastName + "\nfirst name: " + firstName + "\nb-day: " + bDay + "\nphone: " + phone + "\naddress: " + address + "\nelevator? " + televator + "\nfloor: " + floor + "\nyears of experience: " + yearsOfExperience + "\nmax kids: " + maxKids + "\nmin age: " + minAge + "\nmax age: " + maxAge + "\nallows hourly rate? " + tallowsHourlyRate + "\nhourly rate: " + hourlyRate + "\nmonthly rate: " + monthlyRate + "\ndays of work: " + tdaysOff + "\nhours of work: " + tdaysOfWork + "\ndays off according to: " + tdaysOff + "\nrecommendations: " + recommendations + "\n";

        }
    }
}
