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
        public void RegisterNewPatient(Patient patient)
        {
            var id = 1;
            if(patients.Count != 0)
            {
                var lastid = patients[patients.Count - 1].PatientId;
                id = ++lastid;
            }
            patient.PatientId = id;
            patients.Add(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            var select = FindPatient(patient.PatientId);
            if(select == null)
            {
                throw new Exception("Patient id not found");
            }
            select.PatientMobile = patient.PatientMobile;
            select.PatientName = patient.PatientName;
            select.DateofBirth = patient.DateofBirth;
            select.DoctorId = patient.DoctorId;
        }
    }
    public class BillingRepo
    {
        private List<Billing> bills;
        public BillingRepo(List<Billing> oldrecords)
        {
            bills = oldrecords;
        }
        
        public void AddBill(Patient patientInfo)
        {
            int billNo = bills.LastOrDefault().BillNo;
            Billing billing = new Billing();
            billing.BillNo = ++billNo;
            billing.PatientId = patientInfo.PatientId;
            billing.BillAmount = getFees(patientInfo.DoctorId);
            bills.Add(billing);
        }

