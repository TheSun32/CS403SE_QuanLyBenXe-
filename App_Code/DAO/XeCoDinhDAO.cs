using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAPM_Project.App_Code.DAO
{
    public class XeCoDinhDAO
    {
        private MyDbContext mydb;
        public XeCoDinhDAO()
        {
            mydb = new MyDbContext();
        }
        public List<XeCoDinh> getAll()
        {
            return mydb.XeCoDinhs.ToList();
        }
    }
}