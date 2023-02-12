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

