using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAPM_Project.App_Code.DAO
{
    public class TaiXeDAO
    {
        private MyDbContext mydb;
        public TaiXeDAO()
        {
            mydb = new MyDbContext();
        }
        public List<TaiXe> getAll()
        {
            return mydb.TaiXes.ToList();
        }
        public int count()
        {
            return mydb.TaiXes.Count();
        }
        public TaiXe getById(int id)
        {
            return mydb.TaiXes.Find(id);
        }
    }
}