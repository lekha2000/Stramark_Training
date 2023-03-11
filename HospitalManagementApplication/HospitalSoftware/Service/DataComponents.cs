using HostitalSoftware.Interface;
using HostitalSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HostitalSoftware.Service
{
    public class DoctorRepo
    {
        public List<Doctor> AllDoctors => new List<Doctor>
        {
            new Doctor
            {
                DoctorId = 1,
                DoctorName = "Suresh",
                Fees = 4500,
                Specialization = "Heart Surgeon"
            },
