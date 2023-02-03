using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using Utility;

namespace SampleDataAccessApp
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int salary { get; set; }
        public int DeptId { get; set; }
        public int EmpSalary { get; internal set; }
    }
interface IDatacomponent
    {
        void AddEmployees(Employee Emp);
        void UpdateEmployee(Employee Emp);
        void DeleteEmployee(int id);
    }
    
    class DisconnectedProgram : IDatacomponent
    {
        static string strcon = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        const string query = "Select * from tblEmployee"; //Select * from Dept;
        //const string deptquery = "Select * from Dept";
        static DataSet dataSet = new DataSet("AllRecords");
        static SqlDataAdapter ada = null; 
        static void fillRecord()
        {
            ada = new SqlDataAdapter(query,strcon);
            SqlCommandBuilder builder = new SqlCommandBuilder(ada);
            //give name to the table           
            ada.Fill(dataSet);
            dataSet.Tables[0].TableName = "Employee";
            //dataSet.Tables[1].TableName = "Department";

            if(dataSet.Tables[0].PrimaryKey.Length == 0)
            {
                dataSet.Tables[0].PrimaryKey = new DataColumn[]
                {
                    dataSet.Tables[0].Columns[0]
                };
            }
        }
        static void Main(string[] args)
        {
            fillRecord();
            //DisplayEmployee();
            //Console.WriteLine();
            //DisplayDepartments();
            //DisplayEmployeeOfDepartsments("Human Resource");

            IDatacomponent datacomponent = new DisconnectedProgram();

          string name = Utilities.Prompt("Enter Name : ");
            string place = Utilities.Prompt("Enter Place : ");
            int salary = Utilities.GetNumber("Enter Salary : ");
            int deptid = Utilities.GetNumber("Enter DeptId : ");
            datacomponent.AddEmployees(new Employee
            {
                EmpName = name,
                EmpAddress = place,
                salary = salary,
                DeptId = deptid
            });
            //int id = Utilities.GetNumber("Enter ID : ");
            //datacomponent.UpdateEmployee(new Employee
            //{
            //    EmpName = name,
            //    EmpAddress =place,
            //    salary = salary,
            //    DeptId = deptid
            //});
            //datacomponent.DeleteEmployee(id);

            //int Deptid = Utilities.GetNumber("Enter DeptId : ");
            //InsertEmployes(name, place, salary, Deptid);
            //Console.WriteLine("Eployee Details successfully inserted");
            //DeleteEmployee(1219);
            //Console.WriteLine("Eployee Detail successfully deleted");
            //UpdateEployee(id , name, place, salary);

