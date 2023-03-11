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
            new Doctor
            {
                DoctorId = 2,
                DoctorName = "Kiran Kair",
                Fees = 3500,
                Specialization = "Gynecologist"
            },
            new Doctor
            {
                DoctorId = 3,
                DoctorName = "Anitha",
                Fees = 1500,
                Specialization = "Dermatology."
            }
        };
    }
    public class PatientRepo : IPatientRepo
    {
        private List<Patient> patients = new List<Patient>();

        public PatientRepo()
        {

        }

        public PatientRepo(List<Patient> oldRecords)
        {
            patients = oldRecords;
        }
        public Patient FindPatient(int PatientId) => patients.Find((p) => p.PatientId == PatientId);
        
        public List<Patient> GetPatients(int DocId) => patients.FindAll((p) => p.DoctorId == DocId);

