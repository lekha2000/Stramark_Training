using System;
using System.IO;


namespace Assignment6
{
    class Student
    {
        int Student_Id;
        string Student_Name;
        string Student_DOB;
        string Student_Grade;
        string Student_Fav_Subject;

        public int StdID
        {
            get { return Student_Id; }
            set { Student_Id = value; }
        }

        public string StdName
        {
            get => Student_Name;
            set => Student_Name = value;
        }

        public string StdDOB
        {
            get => Student_DOB;
            set => Student_DOB = value;
        }
        public string StdGrade
        {
            get => Student_Grade;
            set => Student_Grade = value;
        }
        public string StdFavSub
        {
            get => Student_Fav_Subject;
            set => Student_Fav_Subject = value;
        }

    }
    class StudentManage
    {
        //Student is the type of array , std is the name of array
        // int[] arr = null i.e, student is the type of array 
        private Student[] std = null;
        private int Size = 0;

       /* public static void display()
        {
            foreach (Student s in std)
            {

            }
        }*/
        public StudentManage(int size)
        {
            Size = size;
            std = new Student[Size];
        }

        //Function to Add student details
        //Passing student array and object
        public void AddStdDetails(Student Std)
        {

            for (int i = 0; i < Size; i++)
            {
                if (std[i] == null)
                {
                    std[i] = new Student
                    {
                        StdID = Std.StdID,
                        StdName = Std.StdName,
                        StdDOB = Std.StdDOB,
                        StdGrade = Std.StdGrade,
                        StdFavSub = Std.StdFavSub
                    };
                    return;
                }
            }
            Console.WriteLine(Std.StdID);
        }

        //Function to Update Student Details
        //Passing student array and object
        //std[i].StdID array id passed to std
        //Std.StdID user entered id passed to Std
        public void UpdateStdDetails(Student Std)
        {
            for (int i = 0; i < Size; i++)
            {
                //Checks if array not null and array i should match with user input i
                if (std[i] != null && std[i].StdID == Std.StdID)
                {
                    std[i].StdName = Std.StdName;
                    std[i].StdGrade = Std.StdGrade;
                    std[i].StdFavSub = Std.StdFavSub;
                    return;
                }
            }
            throw new Exception("Student ID not found to Update");
        }

        //Function to Find Student Details based on id 
        public Student FindStudent(int id)
        {
            foreach (Student i in std)
            {
                if (i != null && i.StdID == id)
                    return i;
            }
            throw new Exception("No Account found");

        }

        //Function To Delete Student Details based on id
        //std[i].StdID array id passed to std
        //Std.StdID user entered id passed to Std
        public void DeleteStudent(int id)
        {
            for (int i = 0; i < Size; i++)
            {
                //Checks if array not null and array i should match with user input i
                if (std[i] != null && std[i].StdID == id)
                {
                    std[i] = null;
                    return;
                }
            }
            throw new Exception("No Account found to delete");
        }


    }

    class UIStudent
    {
        public static StudentManage msg = null;

        public static void DisplayMenu()
        {
            Console.WriteLine("Enter the Size : ");
            int size = Convert.ToInt32(Console.ReadLine());
            msg = new StudentManage(size);
            bool process = true;

            do
            {
                Console.WriteLine("==================Student Management System===================");
                Console.WriteLine("1...............Add Student Record");
                Console.WriteLine("2...............Modify Student Record");
                Console.WriteLine("3...............Find Student Record");
                Console.WriteLine("4...............Delete Student Record");
                Console.WriteLine("5...............Exit");
                Console.Write("Select option (between 1 to 5) : ");

                int option = Convert.ToInt32(Console.ReadLine());
                process = ProcessMenu(option);

            } while (process);
            Console.WriteLine("Thanks for using our application");
        }

        private static bool ProcessMenu(int option)
        {
            switch (option)
            {
                case 1:
                    addingStudentHelper();
                    break;
                case 2:
                    updatingStudentHelper();
                    break;
                case 3:
                    findingStudentHelper();
                    break;
                case 4:
                    throw new Exception("Do it URSELF!!");
                default:
                    return false;
            }
            return true;
        }

        private static void addingStudentHelper()
        {
            Console.Write("Enter the Id of Student : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Name of Student : ");
            string name = Console.ReadLine();
            Console.Write("Enter the Date Of Birth of Studnet : ");
            string dob = Console.ReadLine();
            Console.Write("Enter the Grade of Student : ");
            string grade = Console.ReadLine();
            Console.Write("Enter the Fav Subject of Student : ");
            string favsub = Console.ReadLine();
            Student std = new Student 
            {
                StdID = id,
                StdName = name,
                StdDOB = dob,
                StdGrade = grade,
                StdFavSub = favsub
            };
            msg.AddStdDetails(std);
            Console.WriteLine(std.StdID);
            Console.Write("Student Details Added Succesfully");

            //Console.WriteLine("Press Enter to Clear the Screen");
            //Console.Clear();
        }

        private static void updatingStudentHelper()
        {
            Console.Write("Enter the Id of Student : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the New Name of Student : ");
            string name = Console.ReadLine();
            Console.Write("Enter the Grade of Student : ");
            string grade = Console.ReadLine();
            Console.Write("Enter the Fav Subject of Student : ");
            string favsub = Console.ReadLine();

            Student std = new Student
            {
                StdName = name,
                StdGrade = grade,
                StdFavSub = favsub
            };

            msg.UpdateStdDetails(std);
            Console.WriteLine("Press Enter to Clear the Screen");
            Console.Clear();
        }

        private static void findingStudentHelper()
        {
            Console.Write("Enter the Id of Student : ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                Student std = msg.FindStudent(id);
                Console.WriteLine("The Details of the Student are as follows:");
                string content = $"\nThe Student No: {std.StdID}\nThe Name: {std.StdName}\nThe Grade : {std.StdGrade}\nThe Date Of Birth : {std.StdDOB}\nThe Fav Subject : {std.StdFavSub}\n";
                Console.WriteLine(content);
                Console.WriteLine("Press Enter to Clear the Screen");
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
    class AssignmentClassStudent
    {
        static void Main(string[] args)
        {
            UIStudent.DisplayMenu();
        }
    }
}

