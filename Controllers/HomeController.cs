using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAPM_Project.App_Code.DAO;
using DAPM_Project.DTO;
using DAPM_Project.App_Start;

namespace DAPM_Project.Controllers
{
    public class HomeController : Controller
    {
        private ChuNhaXeDAO ChuNhaXeDAO= new ChuNhaXeDAO();
        private TaiXeDAO taiXeDAO = new TaiXeDAO();
        private LichTrinhDAO lichTrinhDAO = new LichTrinhDAO();
        public ActionResult Index()
        {
            List<ChuNhaXe> nhaxes = ChuNhaXeDAO.getAll();
            List<LichTrinhDTO> lichtrinhs = lichTrinhDAO.getAll();
            ViewBag.slnhaxe = ChuNhaXeDAO.count();
            ViewBag.sltx = taiXeDAO.count();
            var data = new Tuple<List<ChuNhaXe>, List<LichTrinhDTO>>(nhaxes, lichtrinhs);
            return View(data);
        }
        public ActionResult ChuNhaXe()
        {
            List<ChuNhaXe> nhaxes = ChuNhaXeDAO.getAll();
            return View(nhaxes);
        }
        public ActionResult ChuNhaXeSearch(string s)
        {
            var list = ChuNhaXeDAO.search(s);
            return View(list);
        }
        public ActionResult ChuNhaXeDetail(int id)
        {
            List<string> diemden = ChuNhaXeDAO.getChuyenXe(id);
            ChuNhaXe nhaxe = ChuNhaXeDAO.getById(id);
            var data = new Tuple<List<string>, ChuNhaXe>(diemden, nhaxe);
            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginHandler(string username, string password)
        {
            Credential credential = new Credential(username, password);
            SessionConfig.SetUser(credential);
            return new RedirectResult("/Home/Authorize");
        }
        [RoleUser]
        public ActionResult Authorize()
        {
            return new RedirectResult("/Home/Index");
        }
    }
}