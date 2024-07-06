using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAPM_Project.App_Code.DAO
{
    public class NhanVienDAO
    {
        private MyDbContext mydb;
        public NhanVienDAO()
        {
            mydb = new MyDbContext();
        }

        public NhanVien getById(int id)
        {
            return mydb.NhanViens.Find(id);
        }
    }
}