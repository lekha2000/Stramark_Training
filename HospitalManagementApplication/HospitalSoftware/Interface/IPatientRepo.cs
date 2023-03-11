using HostitalSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostitalSoftware.Interface
{
    interface IPatientRepo
    {
        void RegisterNewPatient(Patient patient);
        void UpdatePatient(Patient patient);
        List<Patient> GetPatients(int DocId);
        Patient FindPatient(int PatientId);
    }
}
