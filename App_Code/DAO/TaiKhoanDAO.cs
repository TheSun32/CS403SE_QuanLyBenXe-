using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAPM_Project.DTO;

namespace DAPM_Project.App_Code.DAO
{
    public class TaiKhoanDAO
    {
        private MyDbContext mydb;
        public TaiKhoanDAO()
        {
            mydb = new MyDbContext();
        }
        public int checkCredential(Credential user)
        {
            var data = (from tk in mydb.TaiKhoans
                        where tk.tenTaiKhoan == user.username
                        where tk.matKhau == user.password
                        select tk.idTaiKhoan).FirstOrDefault();
            return data;
        }
        public string getRole(int idUser)
        {
            if (mydb.ChuNhaXes.Find(idUser) != null)
            {
                return "nx";
            }
            else if(mydb.NhanViens.Find(idUser) != null)
            {
                return "nv";
            }
            else if (mydb.NhanViens.Find(idUser) != null)
            {
                return "tx";
            }
            else
            {
                return "admin";
            }
        }
        public TaiKhoan getByUsername(string username)
        {
            return mydb.TaiKhoans.Where(t => t.tenTaiKhoan.Equals(username)).FirstOrDefault();
        }
    }
}