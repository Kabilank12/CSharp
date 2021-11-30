using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineDrive
{
    public enum opt
    {
        YES,
        NO
    }
    public enum Gender
    {
        MALE,
        FEMALE,
        TRANSGENDER
    }
    class VaccineProject
    {
        static VaccineProject VaccineMain = new VaccineProject();
        static List<Benificiery> BeficicieryObj = new List<Benificiery>();
        Vaccine VaccineObj = new Vaccine();
        static void Main(string[] args)
        {
            
            var Detail = new Benificiery("Kabilan",22,"Cuddalore",Gender.MALE,8894561235);
            var Detail1 = new Benificiery("Ashok", 22, "Panruti", Gender.MALE, 8895648521);
            BeficicieryObj.Add(Detail);
            BeficicieryObj.Add(Detail1);
            bool FirstDo = false;
            int MainChoice;
            string choice;
            do
            {
                Console.WriteLine("----------Welcome for the Vaccination Drive---------");
                Console.WriteLine("Enter your choice :\nBeneficiery Registration -> 1\nVaccination -> 2\n Exit ->3");
                MainChoice = int.Parse(Console.ReadLine());
                switch (MainChoice)
                {
                    case 1:
                        VaccineMain.BenificieryRegistration();
                        break;
                    case 2:
                        VaccineMain.Vaccination();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("------You have entered a invalid input------");
                        break;

                }
                Console.WriteLine("Do you want go to main menu- Yes / No?");
                choice = Console.ReadLine().ToUpper();

                FirstDo = false;
                if (choice == opt.YES.ToString())
                {
                    FirstDo= true;
                }

            } while (FirstDo == true);



        }
        public void BenificieryRegistration()
        {
            string RegName, RegCity;
            Gender RegGender;
            int RegAge,GenderOption,temp;
            long RegPhno;
            Console.WriteLine("Enter your Name : ");
            RegName = Console.ReadLine();
            Console.WriteLine("Enter your Age");
            RegAge = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your City : ");
            RegCity = Console.ReadLine();
            Console.WriteLine("Enter Your PhoneNumber : ");
            RegPhno = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Gender\n Male ->1\nFemale ->2\nTransgender ->3 : ");
            GenderOption = int.Parse(Console.ReadLine());
            if (GenderOption == 1)
            {
                RegGender =Gender.MALE;
                var Detail3 = new Benificiery(RegName, RegAge, RegCity, RegGender, RegPhno);

                BeficicieryObj.Add(Detail3);

            }
            else if (GenderOption == 2)
            {
                RegGender = Gender.FEMALE;
                var Detail3 = new Benificiery(RegName, RegAge, RegCity, RegGender, RegPhno);

                BeficicieryObj.Add(Detail3);
            }
             else if (GenderOption == 3)
            {
                RegGender = Gender.TRANSGENDER;
                var Detail3 = new Benificiery(RegName, RegAge, RegCity, RegGender, RegPhno);

                BeficicieryObj.Add(Detail3);
            }
            
            foreach(Benificiery dt in BeficicieryObj)
            {
                if (dt.Name == RegName)
                {
                    temp=dt.RegNo;
                    Console.WriteLine($"Hi {RegName}, you are successfully Registered.Your Registration Number is : {temp}  ");
                }
            }
        }
        public void Vaccination()
        {
            VaccineType typ;
        int RegId,UserChoice;
            Console.WriteLine("Enter the Registration ID:");
            RegId = int.Parse(Console.ReadLine());
            foreach (Benificiery det in BeficicieryObj)
            {
                if (det.RegNo== RegId)
                {
                    Console.WriteLine("Enter Your Choice: \nTake Vaccination -> 1\nVaccination History -> 2\nNext due Date ->3\n EXit->4");
                    UserChoice = int.Parse(Console.ReadLine());
                    switch (UserChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter your Choice of Vaccine\n Covishield -> 1\nCovaxin ->2");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                Console.WriteLine("First dose or Second Dose- 1 / 2?");
                                int dosel = int.Parse(Console.ReadLine());
                                if (dosel == 1)
                                {
                                    typ = VaccineType.Covishield;
                                    VaccineObj.Dosage = "Dose1";

                                    det.VaccinationDetail(det.RegNo, det.Name, det.Age, det.City, det.gender, det.PhNo,typ, VaccineObj.Dosage);
                                }
                                else if (dosel == 2)
                                {
                                    typ = VaccineType.Covaccine;
                                    VaccineObj.Dosage = "Dose2";
                                    det.VaccinationDetail(det.RegNo, det.Name, det.Age, det.City, det.gender, det.PhNo, typ, VaccineObj.Dosage);
                                }
                                else
                                {

                                    Console.WriteLine("You have Entered wrong one");
                                }
                            }
                            else
                            {
                                Console.WriteLine("First dose or Second Dose- 1 / 2?");
                                int dosel = int.Parse(Console.ReadLine());
                                if (dosel == 1)
                                {
                                    typ = VaccineType.Covaccine;
                                    VaccineObj.Dosage = "Dose1";

                                    det.VaccinationDetail(det.RegNo, det.Name, det.Age, det.City, det.gender, det.PhNo, typ, VaccineObj.Dosage);
                                }
                                else if (dosel == 2)
                                {
                                    typ = VaccineType.Covaccine;
                                    VaccineObj.Dosage = "Dose2";
                                }
                                else
                                {
                                    Console.WriteLine("You have Entered wrong one");
                                }

                            }
                                                     
                            break;
                        case 2:
                            det.VaccinationHistory(det.RegNo, det.Name, det.Age, det.City, det.gender, det.PhNo);

                            break;
                        case 3:
                            det.NextDueDate(det.RegNo, det.Name);

                            break;
                        case 4:
                            
                            break;
                        default:
                            Console.WriteLine("You have entered wrong Choice");
                            break;

                    }
                   
                    
                }
            }

        }
    }

    

}
