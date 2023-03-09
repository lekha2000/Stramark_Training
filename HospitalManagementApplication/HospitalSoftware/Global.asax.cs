using HostitalSoftware.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace HostitalSoftware
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["Doctors"] = new DoctorRepo().AllDoctors;
            Application["Patients"] = new PatientRepo();
        }
    }
}