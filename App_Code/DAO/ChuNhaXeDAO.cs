using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAPM_Project;

namespace DAPM_Project.App_Code.DAO
{
    public class ChuNhaXeDAO
    {
        private MyDbContext mydb;
        public ChuNhaXeDAO()
        {
            mydb = new MyDbContext();
        }
        public List<ChuNhaXe> getAll()
        {
            return mydb.ChuNhaXes.ToList(); ;
        }
        public object get3()
        {
            var data = (from nhaxe in mydb.ChuNhaXes
                        select nhaxe).Take(3).ToList();
            return data;
        }
        public int count()
        {
            return mydb.ChuNhaXes.Count();
        }
        public ChuNhaXe getById(int id)
        {
            return mydb.ChuNhaXes.Where(n => n.idChuNhaXe == id).FirstOrDefault();
        }
        public List<string> getChuyenXe(int id)
        {
            var data = (from nhaxe in mydb.ChuNhaXes
                        join lichtrinh in mydb.LichTrinhs
                        on nhaxe.idChuNhaXe equals lichtrinh.idXe
                        where nhaxe.idChuNhaXe == id
                        select lichtrinh.diemDen).Distinct().ToList();
            List<string> list = new List<string>();
            foreach(var i in data)
            {
                list.Add(i);
            }
            return list;
        }
        public List<ChuNhaXe> search(string s)
        {
            return mydb.ChuNhaXes.Where(t => t.tenNhaXe.Contains(s)).ToList();
        }
    }
}