using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAPM_Project.DTO
{
    public class Credential
    {
        public string username { get; set; }
        public string password { get; set; }
        public Credential(string uname, string pass)
        {
            this.username = uname;
            this.password = pass;
        }
    }
}