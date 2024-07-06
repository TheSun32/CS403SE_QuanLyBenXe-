using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAPM_Project.App_Start;
using DAPM_Project.App_Code.DAO;

namespace DAPM_Project.App_Start
{
    public class RoleUser:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
            DTO.Credential user = SessionConfig.GetUser();
            int idUser = taiKhoanDAO.checkCredential(user);
            if (user == null || idUser == 0)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(new
                        {
                            controller = "Home",
                            action = "LoginPage"
                        }));
                return;
            }
            else { 
                if (taiKhoanDAO.getRole(idUser).Equals("nx"))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(new
                        {
                            controller = "Manager",
                            action = "QLChuNhaXe"
                        }));
                }else if (taiKhoanDAO.getRole(idUser).Equals("tx"))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(new
                        {
                            controller = "Home",
                            action = "TaiXe"
                        }));
                }
                else if (taiKhoanDAO.getRole(idUser).Equals("nv"))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(new
                        {
                            controller = "Manager",
                            action = "QLNhanVien"
                        }));
                }
                else if (taiKhoanDAO.getRole(idUser).Equals("admin"))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(new
                        {
                            controller = "Admin",
                            action = "Index"
                        }));
                }
                return;
            }
        }
    }
}