using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAPM_Project.DTO;

namespace DAPM_Project.App_Start
{
    public class SessionConfig
    {
        public static void SetUser(Credential credential)
        {
            HttpContext.Current.Session["user"] = credential;
        }
        public static Credential GetUser()
        {
            return (Credential)HttpContext.Current.Session["user"];
        }
    }
}