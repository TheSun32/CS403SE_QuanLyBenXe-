using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAPM_Project.DTO;

namespace DAPM_Project.App_Code.DAO
{
    public class LichTrinhDAO
    {
        private MyDbContext mydb;
        public LichTrinhDAO()
        {
            mydb = new MyDbContext();
        }
        public List<LichTrinhDTO> getAll()
        {
            var data = (from lichtrinh in mydb.LichTrinhs
                        join taixe in mydb.TaiXes
                        on lichtrinh.idTaiXe equals taixe.idTaiXe
                        join xe in mydb.XeCoDinhs
                        on lichtrinh.idXe equals xe.idXe
                        join nhaxe in mydb.ChuNhaXes
                        on xe.idChuNhaXe equals nhaxe.idChuNhaXe
                        select new
                        {
                            lichtrinh.idLichTrinh,
                            lichtrinh.giaVe,
                            lichtrinh.gioXuatPhat,
                            lichtrinh.diemDen,
                            lichtrinh.soLuongConLai,
                            nhaxe.tenNhaXe,
                            taixe.hoTen
                        }).ToList();
            List<LichTrinhDTO> list = new List<LichTrinhDTO>();
            foreach (var i in data)
            {
                LichTrinhDTO lichTrinh = new LichTrinhDTO();
                lichTrinh.idLichTrinh = i.idLichTrinh;
                lichTrinh.giaVe = i.giaVe;
                lichTrinh.diemDen = i.diemDen;
                lichTrinh.gioXuatPhat = i.gioXuatPhat;
                lichTrinh.soLuongConLai = int.Parse(i.soLuongConLai.ToString());
                lichTrinh.tenNhaXe = i.tenNhaXe;
                lichTrinh.tenTaiXe = i.hoTen;
                list.Add(lichTrinh);
            }
            return list;
        }
        public List<LichTrinhDTO> getAllById(int idnhaxe)
        {
            var data = (from lichtrinh in mydb.LichTrinhs
                        join taixe in mydb.TaiXes
                        on lichtrinh.idTaiXe equals taixe.idTaiXe
                        join xe in mydb.XeCoDinhs
                        on lichtrinh.idXe equals xe.idXe
                        join nhaxe in mydb.ChuNhaXes
                        on xe.idChuNhaXe equals nhaxe.idChuNhaXe
                        where lichtrinh.idXe == idnhaxe
                        select new
                        {
                            lichtrinh.idLichTrinh,
                            lichtrinh.giaVe,
                            lichtrinh.gioXuatPhat,
                            lichtrinh.diemDen,
                            lichtrinh.soLuongConLai,
                            taixe.hoTen
                        }).ToList();
            List<LichTrinhDTO> list = new List<LichTrinhDTO>();
            foreach (var i in data)
            {
                LichTrinhDTO lichTrinh = new LichTrinhDTO();
                lichTrinh.idLichTrinh = i.idLichTrinh;
                lichTrinh.giaVe = i.giaVe;
                lichTrinh.diemDen = i.diemDen;
                lichTrinh.gioXuatPhat = i.gioXuatPhat;
                lichTrinh.soLuongConLai = int.Parse(i.soLuongConLai.ToString());
                lichTrinh.tenTaiXe = i.hoTen;
                list.Add(lichTrinh);
            }
            return list;
        }
        public LichTrinh getById(int id)
        {
            return mydb.LichTrinhs.Find(id);
        }
        public void Edit(LichTrinh lichtrinh)
        {
            LichTrinh lt = mydb.LichTrinhs.Find(lichtrinh.idLichTrinh);
            lt.diemDen = lichtrinh.diemDen;
            lt.giaVe = lichtrinh.giaVe;
            lt.gioXuatPhat = lichtrinh.gioXuatPhat;
            lt.idTaiXe = lichtrinh.idTaiXe;
            lt.soLuongConLai = lichtrinh.soLuongConLai;
            mydb.SaveChanges();
        }
        public void Add(LichTrinh lich)
        {
            mydb.LichTrinhs.Add(lich);
            mydb.SaveChanges();
        }
        public void Delete(int id)
        {
            LichTrinh l = mydb.LichTrinhs.Find(id);
            mydb.LichTrinhs.Remove(l);
            mydb.SaveChanges();
        }
    }
}