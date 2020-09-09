using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{

    public class Mother
    {
        //copy of mother
        public Mother getCopyMother()
        {
            Mother mom= this.GetCopy();
            for (int i = 0; i < 6; i++)
            {
                mom.neededDays[i] = this.neededDays[i];
                mom.neededHours[0, i] = this.neededHours[0, i];
                mom.neededHours[1, i] = this.neededHours[1, i];
            }
            return mom;
        }
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string idAndName
        {
            get { return string.Format("{0} {1} {2}",id,firstName,lastName); }
            set { }
        }

        public int phone { get; set; }
        public string startPhone { get; set; }
        public int endPhone { get; set; }
        public string address { get; set; } = "";
        public string nannyAddress { get; set; } = "";
        private bool[] mneededDays = new bool[6];
        public bool[] neededDays
        {
            get
            {
                return mneededDays;
            }
            set
            {
                for (int i = 0; i < 6; i++)
                {
                    mneededDays[i] = value[i];
                }
            }
        }
        private double[,] mneededHours = new double[2, 6];

        [XmlIgnore]
        public double[,] neededHours
        {
            get { return mneededHours; }
            set
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        mneededHours[i,j] = value[i,j];
                    }
                    
                }
            }
        }

        public string tempNeededHours
        {
            get
            {
                if (neededHours == null)
                    return null;
                string result = "";
                int sizeA = neededHours.GetLength(0);
                int sizeB = neededHours.GetLength(1);
                result += "" + sizeA + "," + sizeB;
                for (int i = 0; i < sizeA; i++)
                    for (int j = 0; j < sizeB; j++)
                        result += "," + neededHours[i, j];
                return result;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] values = value.Split(',');
                    int sizeA = int.Parse(values[0]);
                    int sizeB = int.Parse(values[1]);
                    neededHours = new double[sizeA, sizeB];
                    int index = 2;
                    for (int i = 0; i < sizeA; i++)
                        for (int j = 0; j < sizeB; j++)
                            neededHours[i, j] = double.Parse(values[index++]);
                }
            }
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
                            tneededHours += "sunday: " + neededHours[0, i] + "-" + neededHours[1, i];
                            break;
                        case 1:
                            tneededDays += ", monday";
                            tneededHours += "\nmonday: " + neededHours[0, i] + "-" + neededHours[1, i];
                            break;
                        case 2:
                            tneededDays += ", tuesday";
                            tneededHours += "\ntuesday: " + neededHours[0, i] + "-" + neededHours[1, i];
                            break;
                        case 3:
                            tneededDays += ", wednsday";
                            tneededHours += "\nwednsday: " + neededHours[0, i] + "-" + neededHours[1, i];
                            break;
                        case 4:
                            tneededDays += ", thursday";
                            tneededHours += "\nthursday: " + neededHours[0, i] + "-" + neededHours[1, i];
                            break;
                        case 5:
                            tneededDays += ", friday";
                            tneededHours += "\nfriday: " + neededHours[0, i] + "-" + neededHours[1, i];
                            break;
                        default:
                            break;
                    }
                }
            }
            return "Id: " + id + "\nlast name: " + lastName + "\nfirst name: " + firstName + "\nphone: 0" + phone + "\naddress: " + address + "\nnanny address: " + nannyAddress + "\nneeded days: " + tneededDays + "\nneeded hours: " + tneededHours + "\nremarks: " + remarks+"\n";
        }
    }
    
}
