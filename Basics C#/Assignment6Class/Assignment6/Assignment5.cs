using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentDOB { get; set; }
        public string StudentGrade { get; set; }
        public string FavSubject { get; set; }

        //A shallow copy of an object is a copy whose properties share the same references 
        //(point to the same underlying values) as those of the source object from which the copy was made.
        public void ShallowCopy(Student student)
        {
            this.StudentId = StudentId;
            this.StudentName = StudentName;
            this.StudentDOB = StudentDOB;
            this.StudentGrade = StudentGrade;
            this.FavSubject = FavSubject;
        }
    }

    class StudentManage
    {
        //Student is the type of array , std is the name of array
        // int[] arr = null i.e, student is the type of array 
        private Student[] std = null;
        private int Size = 0;

        //Constructor for class
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
                        StudentId = Std.StudentId,
                        StudentName = Std.StudentName,
                        StudentDOB = Std.StudentDOB,
                        StudentGrade = Std.StudentGrade,
                        FavSubject = Std.FavSubject
                    };
                    return;
                }
            }
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
                if (std[i] != null && std[i].StudentId == Std.StudentId)
                {
                    std[i].StudentId = Std.StudentId;
                    std[i].StudentName = Std.StudentName;
                    std[i].StudentGrade = Std.StudentGrade;
                    std[i].FavSubject = Std.FavSubject;
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
                if (i != null && i.StudentId == id)
                    return i;
            }
            throw new Exception("No Student found");

        }

        //Function To Delete Student Details based on id
        //std[i].StdID array id passed to std
        //Std.StdID user entered id passed to Std
        public Student DeleteStudent(int id)
        {
            for (int i = 0; i < Size; i++)
            {
                //Checks if array not null and array i should match with user input i
                if (std[i] != null && std[i].StudentId == id)
                {
                    std[i] = null;
                    Console.WriteLine($"The Details of the Student with id {id} has been deleted\n ");
                }
            }
            throw new Exception("No Student found to delete");
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
                    AddingStudentHelper();
                    break;
                case 2:
                    UpdatingStudentHelper();
                    break;
                case 3:
                    FindingStudentHelper();
                    break;
                case 4:
                    DeleteStudentHelper();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void AddingStudentHelper()
        {
            Console.Write("\nEnter the Id of Student : ");
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
                StudentId = id,
                StudentName = name,
                StudentDOB = dob,
                StudentGrade = grade,
                FavSubject = favsub
            };
            msg.AddStdDetails(std);
            Console.WriteLine("Student Details Added Succesfully\n");

            //Console.WriteLine("Press Enter to Clear the Screen");
            //Console.Clear();
        }

        private static void UpdatingStudentHelper()
        {
            Console.Write("\nEnter the Id of Student : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the New Name of Student : ");
            string name = Console.ReadLine();
            Console.Write("Enter the Date Of Birth of Studnet : ");
            string dob = Console.ReadLine();
            Console.Write("Enter the Grade of Student : ");
            string grade = Console.ReadLine();
            Console.Write("Enter the Fav Subject of Student : ");
            string favsub = Console.ReadLine();

            Student std = new Student
            {
                StudentId = id,
                StudentName = name,
                StudentDOB = dob,
                StudentGrade = grade,
                FavSubject = favsub
            };

            msg.UpdateStdDetails(std);
            Console.WriteLine("Student Details Updated Succesfully\n");
            //Console.WriteLine("Press Enter to Clear the Screen");
            // Console.Clear();
        }

        private static void FindingStudentHelper()
        {
            Console.Write("\nEnter the Id of Student : ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                Student std = msg.FindStudent(id);
                Console.WriteLine("The Details of the Student are as follows:");
                string content = $"\nThe Student No: {std.StudentId}\nThe Name: {std.StudentName}\nThe Grade : {std.StudentGrade}\nThe Date Of Birth : {std.StudentDOB}\nThe Fav Subject : {std.FavSubject}\n";
                Console.WriteLine(content);
                //Console.WriteLine("Press Enter to Clear the Screen");
                //Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void DeleteStudentHelper()
        {
            Console.Write("\nEnter the Id of Student : ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                Student std = msg.DeleteStudent(id);
                Console.WriteLine($"The Details of the Student with id {std.StudentId} has been deleted\n "); 
                //Console.WriteLine("Press Enter to Clear the Screen");
                //Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Assignment5
    {
        static void Main(string[] args)
        {
            UIStudent.DisplayMenu();
        }
    }
}
