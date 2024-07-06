using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAPM_Project.DTO
{
    public class LichTrinhDTO
    {
        public int idLichTrinh { get; set; }
        public string gioXuatPhat { get; set; }
        public string diemDen { get; set; }
        public int giaVe { get; set; }
        public int soLuongConLai { get; set; }
        public string tenNhaXe { get; set; }
        public string tenTaiXe { get; set; }
    }
}