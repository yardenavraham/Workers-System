using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
namespace PL
{
    public class Program
    {
            
        
        /*static void Main(string[] args)
        {
            BL.IBL bl;
            BL.FactoryBl factory = new BL.FactoryBl();
            bl = factory.getBl();
            double[,] momHours1 = new double[2, 6];
            double[,] nannyHours1 = new double[2, 6];
            double[,] momHours2 = new double[2, 6];
            double[,] nannyHours2 = new double[2, 6];
            for (int i = 1; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    momHours1[i-1,j]=8*i;
                    momHours2[i - 1, j] = 9 * i;
                    nannyHours1[i - 1, j] = 8 * i;
                    nannyHours2[i - 1, j] = 7 * i;
                }
            }
            int choice;
            Console.WriteLine("enter 1 to continue, 0 to exit");
            choice=int.Parse( Console.ReadLine());
            while (choice != 0)
            {
                try
                {
                    bl.addMother(new Mother
                    {
                        id = 234,
                        address = "herzel,rehovot",
                        firstName = "Miriam",
                        lastName = "Barilan",
                        nannyAddress = "hor,adfg",
                        phone = 65605,
                        remarks = "no",
                        neededDays = new bool[6] { true, false, true, true, true, false },
                        neededHours = momHours1
                    });
                    bl.addMother(new Mother
                    {
                        id = 3,
                        address = "fl,rehovot",
                        firstName = "Talia",
                        lastName = "Tzameret",
                        nannyAddress = "jhk,hjk",
                        phone = 234879,
                        remarks = "no",
                        neededDays = new bool[6] { false, true, true, true, true, false },
                        neededHours = momHours2
                    });
                    bl.addChild(new Child
                    {
                        id = 316261882,
                        idMom = 234,
                        firstName = "yarden",
                        dateBirth = new DateTime(2014, 4, 3),
                        isSpecial = true,
                        specialNeeds = "alergy to milk"
                    });
                    bl.addChild(new Child
                    {
                        id = 23445,
                        idMom = 234,
                        firstName = "Tamar",
                        dateBirth = new DateTime(2016, 5, 2),
                        isSpecial = false,
                        specialNeeds = "nothing"
                    });
                    bl.addChild(new Child
                    {
                        id = 3442,
                        idMom = 3,
                        firstName = "Rotem",
                        dateBirth = new DateTime(2015, 5, 2),
                        isSpecial = false,
                        specialNeeds = "nothing"
                    });

                    bl.addNanny(new Nanny
                    {
                        id = 109,
                        address = "asdk,sdf",
                        bDay = new DateTime(1996, 12, 1),
                        elevator = true,
                        phone = 405,
                        floor = 2,
                        yearsOfExperience = 10,
                        maxAge = 36,
                        minAge = 3,
                        monthlyRate = 1000,
                        firstName = "Gila",
                        lastName = "bal",
                        maxKids = 5,
                        hoursOfWork = nannyHours1,
                        daysOfWork = new bool[6] { true, true, true, true, true, true },
                        daysOff = true,
                        allowsHourlyRate = true,
                        hourlyRate = 10,
                        recommendations = "bla bla bla"
                    });
                    bl.addNanny(new Nanny
                    {
                        id = 39,
                        address = "ark,ddf",
                        bDay = new DateTime(1980, 12, 1),
                        elevator = true,
                        phone = 4067,
                        floor = 2,
                        yearsOfExperience = 20,
                        maxAge = 60,
                        minAge = 24,
                        monthlyRate = 2000,
                        firstName = "Sara",
                        lastName = "bald",
                        maxKids = 4,
                        hoursOfWork = nannyHours2,
                        daysOfWork = new bool[6] { true, false, true, true, true, true },
                        daysOff = false,
                        allowsHourlyRate = true,
                        hourlyRate = 20,
                        recommendations = "bla bla bla"
                    });
                    bl.addContract(new Contract
                    {
                        IdChild = 23445,
                        IdMom = 234,
                        IsContract = true,
                        IdNanny = 109,
                        isCompromise = false,
                        IsMeeting = true,
                        BeginWork = new DateTime(2017, 12, 15),
                        EndWork = new DateTime(2018, 12, 15),
                        HourOrMonth = false,
                        numHoursPerWeek = 32,
                    });
                    bl.addContract(new Contract
                    {
                        IdChild = 3442,
                        IdMom = 3,
                        IsContract = true,
                        IdNanny = 39,
                        isCompromise = true,
                        IsMeeting = true,
                        BeginWork = new DateTime(2017, 12, 15),
                        EndWork = new DateTime(2018, 12, 15),
                        HourOrMonth = true,
                        numHoursPerWeek = 20,
                    });
                    bl.addContract(new Contract
                    {
                        IdChild = 316261882,
                        IdMom = 234,
                        IsContract = true,
                        IdNanny = 109,
                        isCompromise = false,
                        IsMeeting = true,
                        BeginWork = new DateTime(2017, 12, 15),
                        EndWork = new DateTime(2018, 12, 15),
                        HourOrMonth = false,
                        numHoursPerWeek = 32,
                    });
                    Console.WriteLine("avgAge: "+bl.avgAge());
                    Console.WriteLine(bl.avgPriceOfNannies(true)+ " :avgPriceOfNannies");
                    Console.WriteLine(bl.contractsByDistance()+ " :contractsByDistance");
                    Console.WriteLine(bl.hasASpecialChild(109)+ " :hasASpecialChild");
                    bl.deleteMother(bl.getMothers(mom=>mom.id==234).First());

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("enter 1 to continue, 0 to exit");
                choice = int.Parse(Console.ReadLine());
            }
        }*/
    }
}
