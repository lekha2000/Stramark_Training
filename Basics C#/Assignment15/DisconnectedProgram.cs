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

            }
          void IDatacomponent.AddEmployees(Employee Emp)
        {
            var newRow = dataSet.Tables[0].NewRow();
            newRow[1] = Emp.EmpName;
            newRow[2] = Emp.EmpAddress;
            newRow[3] = Emp.salary;
            newRow[4] = Emp.DeptId;
            dataSet.Tables["Employee"].Rows.Add(newRow);
            ada.Update(dataSet, "Employee");
        }
        void IDatacomponent.UpdateEmployee(Employee Emp)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if(row[0].ToString() == Emp.EmpId.ToString())
                {
                    row[1] = Emp.EmpName;
                    row[2] = Emp.EmpAddress;
                    row[3] = Emp.salary;
                    row[4] = Emp.DeptId;
                    break;
                }
            }
            ada.Update(dataSet, "Employee");
        }
        void IDatacomponent.DeleteEmployee(int id)
        {
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if(row[0].ToString() == id.ToString())
                {
                    row.Delete();
                    break;
                }
                
            }
            ada.Update(dataSet, "Employee");
        }
        //private static void UpdateEployee(int id, string name, string place, int salary)
        //{
        //    var fetch = dataSet.Tables[0].Rows.Find(id);
        //    fetch[1] = name;
        //    fetch[2] = place;
        //    fetch[3] = salary;
        //    ada.Update(dataSet, "Employee");
        //    //foreach (DataRow row in dataSet.Tables[0].Rows)
        //    //{
        //    //    if(row[0].ToString() == id.ToString())
        //    //    {
        //    //        row[1] = name;
        //    //        row[2] = place;
        //    //        row[3] = salary;
        //    //    }
        //    //    ada.Update(dataSet, "Employee");
        //    //}
        //}

        //private static void DeleteEmployee(int EmpId)
        //{
        //    foreach (DataRow row in dataSet.Tables[0].Rows)
        //    {
        //        if(row[0].ToString() == EmpId.ToString())
        //        {
        //            //Delete is an inbuilt function which automatically deletes in table
        //            row.Delete();
        //            break;
        //        }
        //    }
        //    //after deleting in table on doinf update it will delete in sqlTable also
        //    ada.Update(dataSet, "Employee");
        //}

        //private static void InsertEmployes(string name, string place, int salary, int deptid)
        //{
        //    var newR = dataSet.Tables[0].NewRow();
        //    newR[1] = name;
        //    newR[2] = place;
        //    newR[3] = salary;
        //    newR[4] = deptid;
        //    dataSet.Tables[0].Rows.Add(newR);
        //    ada.Update(dataSet, "Employee");
        //}
        private static void DisplayEmployeeOfDepartsments(string deptName)
        {
            int Deptid = 0;
            foreach (DataRow row in dataSet.Tables["Department"].Rows)
            {
