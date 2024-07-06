using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAPM_Project.App_Code.DAO;
using DAPM_Project.App_Start;
using DAPM_Project.DTO;

namespace DAPM_Project.Controllers
{
    public class ManagerController : Controller
    {
        private ChuNhaXeDAO chuNhaXeDAO= new ChuNhaXeDAO();
        private TaiKhoanDAO taiKhoanDAO= new TaiKhoanDAO();
        private LichTrinhDAO lichTrinhDAO = new LichTrinhDAO();
        private TaiXeDAO taiXeDAO = new TaiXeDAO();
        private XeCoDinhDAO xeCoDinhDAO = new XeCoDinhDAO();
        private NhanVienDAO nhanVienDAO = new NhanVienDAO();
        public ActionResult QLChuNhaXe()
        {
            var user = SessionConfig.GetUser();
            int idUser = taiKhoanDAO.checkCredential(user);
            ChuNhaXe chunx = chuNhaXeDAO.getById(idUser);
            ViewBag.name = chunx.tenNhaXe;
            List<LichTrinhDTO> list = lichTrinhDAO.getAllById(idUser);
            return View(list);
        }
        public ActionResult EditLichTrinh(int id)
        {
            LichTrinh lt = lichTrinhDAO.getById(id);
            List<TaiXe> list = taiXeDAO.getAll();
            var data = new Tuple<LichTrinh, List<TaiXe>>(lt, list);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditLichTrinhHandler(int idlichtrinh,string gioxuatphat,string diemden, int giave,int soluongconlai,int taixe)
        {
            LichTrinh lichTrinh = new LichTrinh(idlichtrinh, gioxuatphat, diemden, giave, soluongconlai, taixe);
            lichTrinhDAO.Edit(lichTrinh);
            return Redirect("/Manager/QLChuNhaXe");
        }

        public ActionResult AddLichTrinh()
        {
            List<XeCoDinh> xeCoDinhs = xeCoDinhDAO.getAll();
            List<TaiXe> taiXes = taiXeDAO.getAll();
            var data = new Tuple<List<XeCoDinh>, List<TaiXe>>(xeCoDinhs, taiXes);
            return View(data);
        }
        [HttpPost]
        public ActionResult AddLichTrinhHandler(int idlichtrinh, string gioxuatphat, string diemden, int giave, int soluongconlai, int taixe, int xe)
        {
            LichTrinh lichTrinh = new LichTrinh(idlichtrinh, gioxuatphat, diemden, giave, soluongconlai, taixe);
            lichTrinh.idXe = xe;
            lichTrinhDAO.Add(lichTrinh);
            return Redirect("/Manager/QLChuNhaXe");
        }
        public ActionResult DeleteLichTrinh(int id)
        {
            lichTrinhDAO.Delete(id);
            return Redirect("/Manager/QLChuNhaXe");
        }
        public ActionResult QLNhanVien()
        {
            var user = SessionConfig.GetUser();
            TaiKhoan tk = taiKhoanDAO.getByUsername(user.username);
            ViewBag.name = tk.hoTen;
            return View(tk);
        }
    }
}