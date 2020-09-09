using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public int phone { get; set; }
        public string address { get; set; }
        public string nannyAddress { get; set; }
        private bool[] mneededDays = new bool[6];
        public bool[] neededDays
        {
            get { return mneededDays; }
            set { mneededDays = value; }
        }
        private double[,] mneededHours = new double[2, 6];
        public double[,] neededHours
        {
            get { return mneededHours; }
            set { mneededHours = value; }
        }
        public string remarks { get; set; }

        public override string ToString()
        {
            string tneededDays = "", tneededHours = "";
            for (int i = 0; i < 6; i++)
            {
                if (neededDays[i])
                {
                    switch (i)
                    {
                        case 0:
                            tneededDays += "sunday";
                            tneededHours += "sunday: " + neededHours[1, i] + "-" + neededHours[2, i] + "\n";
                            break;
                        case 1:
                            tneededDays += ", monday";
                            tneededHours += "\nmonday: " + neededHours[1, i] + "-" + neededHours[2, i];
                            break;
                        case 2:
                            tneededDays += ", tuesday";
                            tneededHours += "\ntuesday: " + neededHours[1, i] + "-" + neededHours[2, i];
                            break;
                        case 3:
                            tneededDays += ", wednsday";
                            tneededHours += "\nwednsday: " + neededHours[1, i] + "-" + neededHours[2, i];
                            break;
                        case 4:
                            tneededDays += ", thursday";
                            tneededHours += "\nthursday: " + neededHours[1, i] + "-" + neededHours[2, i];
                            break;
                        case 5:
                            tneededDays += ", friday";
                            tneededHours += "\nfriday: " + neededHours[1, i] + "-" + neededHours[2, i];
                            break;
                        default:
                            break;
                    }
                }
            }
            return "id: " + id + "\nlast name: " + lastName + "\nfirst name: " + firstName + "\nphone: " + phone + "\naddress: " + address + "\nnanny address: " + nannyAddress + "\nneeded days: " + tneededDays + "\nneeded hours: " + tneededHours + "\nremarks: " + remarks+"\n";
        }
    }
}
