using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostitalSoftware.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int Fees { get; set; }
        public string Specialization { get; set; }
    }
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public long PatientMobile { get; set; }
        public DateTime DateofBirth { get; set; }
        public int Age => DateTime.Now.Year - DateofBirth.Year;
        public int DoctorId { get; set; }
    }
