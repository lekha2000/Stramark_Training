using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sampleframeworkapp
{
    [Serializable]
    public class Employee
    {
        public int EmpId;
        public string EmpName;
        public string EmpAddress;
        public override string ToString()
        {
            return $"{EmpId} \t {EmpName} \t {EmpAddress}";
        }
    }
    class SerializationEmp
    {
        static void Main(string[] args)
        {
            //Serialize();
            // DeSerialize();
            //XmlSerializer();
            XmlDeSerializer();

            //SOAP will store in xml file only
            //SoapSerializer();
            //SoapDeSerializer();
        }
        public static void Serialize()
        {
            Employee emp = new Employee
            {
                EmpId = 125,
                EmpName = "HarryPotter",
                EmpAddress = "USA"
            };
            //filestream will take three fields file name,File mode( o,c,oc) , FileAccess(r,w,rw).
            FileStream fs = new FileStream("Emp.Bin", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(fs, emp);
            fs.Close();

        }
        public static void DeSerialize()
        {
            Employee emp = null;
            FileStream fs = new FileStream("Emp.Bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            emp = formatter.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp.ToString());
        }
        public static void XmlSerializer()
        {
            Employee emp = new Employee
            {
                EmpId = 127,
                EmpName = "Alisha",
                EmpAddress = "Punjab"
            };
            FileStream fs = new FileStream("Emp.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            serializer.Serialize(fs, emp);
            fs.Close();
        }
        public static void XmlDeSerializer()
        {
            Employee emp = null;
            FileStream fs = new FileStream("Emp.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer des = new XmlSerializer(typeof(Employee));
            emp = des.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp);
        }
        public static void SoapSerializer()
        {
            Employee emp = new Employee
            {
                EmpId = 127,
                EmpName = "Alisha",
                EmpAddress = "Punjab"
            };
            FileStream fs = new FileStream("Emp.soap", FileMode.OpenOrCreate, FileAccess.Write);
            SoapFormatter soap = new SoapFormatter();
            soap.Serialize(fs, emp);
            fs.Close();
        }
        public static void SoapDeSerializer()
        {
            Employee emp = null;
            FileStream fs = new FileStream("Emp.soap", FileMode.Open, FileAccess.Read);
            SoapFormatter soap = new SoapFormatter();
            emp = soap.Deserialize(fs) as Employee;
            fs.Close();
            Console.WriteLine(emp);

        }
    }
}

