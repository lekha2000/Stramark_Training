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
