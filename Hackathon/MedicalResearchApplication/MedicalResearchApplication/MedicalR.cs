using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalResearchApplication
{
    class Medical
    {
        public string DiseaseName { get; set; }
        public string Severity { get; set; }
        public string Symptom { get; set; }
        public string PatientName { get; set; }
    }
    class PaitentDetails
    {
        private Medical[] Pmd = null;
        private int Size = 0;

        //Constructor for class
        public PaitentDetails(int size)
        {
            Size = size;
            Pmd = new Medical[Size];
        }
        //Function to Add Patient Disease
        public void AddPatientDisease(Medical medical)
        {

            for (int i = 0; i < Size; i++)
            {
                if (Pmd[i] == null)
                {
                    Pmd[i] = new Medical
                    {
                        DiseaseName = medical.DiseaseName,
                        Severity = medical.Severity,
                    };
                    return;
                }
            }
        }
        //Function to Add Symptoms To Disease
        public void AddSymptonDisease(Medical medical)
        {

            for (int i = 0; i < Size; i++)
            {
                if (Pmd[i] == null)
                {
                    Pmd[i] = new Medical
                    {
                        DiseaseName = medical.DiseaseName,
                        Symptom = medical.Symptom,
                    };
                    return;
                }
            }

        }
        //function to Display the Records
        public Medical[] FindSymptom(string DiseaseSym)
        {
            Medical[] Medic = null;
            foreach (Medical i in Pmd)
            {
                if (i != null && i.Symptom.Contains(DiseaseSym))
                    return Medic;

            }
            throw new Exception("No Such Symptom Found");

        }
    }
    enum Options
    {
        AddDisease = 1, AddSymptom = 2, CkeckPatient = 3
    }
    class UIPatient
    {
        public static PaitentDetails msg = null;

        public static void DisplayMenu()
        {
            
            Console.WriteLine("Enter the Size of Array (Numbers ONLY): ");
            int size = Convert.ToInt32(Console.ReadLine());
            msg = new PaitentDetails(size);
            bool process = true;

            do
            {
                try
                {
                    Console.WriteLine("==================Medical Research Application===================");
                    Console.WriteLine("1...............Add Disease Details");
                    Console.WriteLine("2...............Add Symptom to Disease");
                    Console.WriteLine("3...............Check Patient");
                    Console.WriteLine("4...............Exit");
                    Console.Write("Select option (between 1 to 4) : ");

                    Options option = (Options)Convert.ToInt32(Console.ReadLine());
                    process = ProcessMenu(option);
                }
                catch (Exception )
                {         
                    Console.WriteLine("\nEnter the Input Properly Numbers Between 1 to 4 !!!");
                }
                

            } while (process);
            Console.WriteLine("\nThanks for using our application");
        }
        private static bool ProcessMenu(Options option)
        {
            switch (option)
            {
                case Options.AddDisease:
                    AddingDiseaseHelper();
                    break;
                case Options.AddSymptom:
                    AddingSymptomToDiseaseHelper();
                    break;
                case Options.CkeckPatient:
                    CheckPatientHelper();
                    break;
                default:
                    return false;
            }
            return true;
        }
        enum ServerityT { high = 1 , medium = 2, low = 3}
        private static void AddingDiseaseHelper()
        {
            Console.Write("\nEnter The Name of Disease : ");
            string DiseaseN = Console.ReadLine();
            Console.Write("Enter The Severity of Disease : ");
            string ServerityType = Console.ReadLine();
            Medical medical = new Medical
            {
                DiseaseName = DiseaseN,
                Severity = ServerityType
            };
            msg.AddPatientDisease(medical);
            switch (ServerityType)
            {
                case "high":
                    Console.WriteLine($"Patient is Critical with Disease {DiseaseN} and ServerityType {ServerityType} Needs Immediate Help");
                    break;
                case "medium":
                    Console.WriteLine($"Patient with Disease {DiseaseN} and ServerityType {ServerityType} will Manage with Proper Medication Prescribed");
                    break;
                case "low":
                    Console.WriteLine($"Patient with Disease {DiseaseN} and ServerityType {ServerityType} will Get Well Soon Within 2-3 Days ");
                    break;
            }
            Console.WriteLine("\nDisease Added Succesfully\n");
        }
        private static void AddingSymptomToDiseaseHelper()
        {
            Console.Write("\nEnter The Name of Disease : ");
            string DiseaseN = Console.ReadLine();
            Console.Write("Enter The Symptom : ");
            string DiseaseSymptom = Console.ReadLine();           
            Medical medical = new Medical
            {
                DiseaseName = DiseaseN,
                Symptom = DiseaseSymptom
            };
            msg.AddSymptonDisease(medical);
            switch (DiseaseSymptom)
            {
                case "Fever":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom} has Exceed Body Temperature more than 105 Degree Celsius");
                    break;
                case "Cold":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom}  has Congestion in Chest/Lungs and Sneezy ");
                    break;
                case "Fever,Cold":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom}  has Flowing Nose ");
                    break;
                case "Diarrhea,Cold":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom}  has Bloading, Nausea and Vomiting ");
                    break;
                case "Fever,Diarrhea":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom}  has Bloading, Nausea, Vomiting and high Fever i.e., More Than 102F");
                    break;
                case "Diarrhea":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom} has A dry mouth, Bloody or black stools and Unusually sleepy. ");
                    break;
            }
            Console.WriteLine("\nDisease Symptom's Added Succesfully\n");
        }
        private static void CheckPatientHelper()
        {
            Console.Write("\nEnter The Patient Name : ");
            string PName = Console.ReadLine();
            Console.Write("\nEnter The Symptom of Disease From The Below List Either(Single/ Multiple Max 2): ");
            Console.WriteLine("\nSymptoms: Fever,Cold,Diarrhea,Cold");
            string DiseaseSymptom = Console.ReadLine();

            try
            {
                Medical[] medicals = msg.FindSymptom(DiseaseSymptom);
                Console.WriteLine("\nThe Patient Disease are as follows:");
                foreach (Medical item in medicals)
                {
                    string content = $"\nThe Patient Name : {item.PatientName}\nThe Symptom : {item.Symptom}\nThe Disease : {item.DiseaseName}\n The Severity : {item.Severity}\n";
                    Console.WriteLine(content);
                }
                           
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            switch (DiseaseSymptom)
            {
                case "Fever":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom} \nDisease : Can Have Cold,Flu,Earaches,Strep Throat\n");
                    break;
                case "Cold":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom} \nDisease : Can Have Hypothermia, Frostbite, Trench Foot, Chilblains\n ");
                    break;
                case "Fever,Cold":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom} \nDisease : Can Have Flu Respiratory illness, but caused by different Viruses \n");
                    break;
                case "Diarrhea,Cold":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom} \nDisease : Can Have Norwalk virus, adenoviruses, astrovirus, cytomegalovirus and viral hepatitis\n");
                    break;
                case "Fever,Diarrhea":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom} \nDisease : Can Have Viral gastroenteritis\n");
                    break;
                case "Diarrhea":
                    Console.WriteLine($"\nPatient with Symptom {DiseaseSymptom} \nDisease : Can Have Cytomegalovirus (CMV) infectio, Coronavirus.\n");
                    break;
            }
        }
        class MedicalR
        {
            //Start of program
            static void Main(string[] args)
            {
                UIPatient.DisplayMenu();
            }
        }
    }
}
