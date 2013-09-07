using BDDD.ObjectContainer;
using DemoProject.DTO.Admin;
using DemoProject.IApplication;
using DemoProject.WebMVC.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.WebMVC.Controllers
{
    public class AdminController : Controller
    {
        [RequiresAdminAuth]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLoginDTO loginDTO)
        {
            IUserService userService = ServiceLocator.Instance.GetService<IUserService>();
            bool loginPass = userService.ValidateUser(loginDTO);
            if (loginPass)
            {
                Session["LoginUser"] = loginDTO.UserName;
            }
            return Json(new { loginPass = loginPass });
        }

        public ActionResult Logout()
        {
            Session["LoginUser"] = null;
            return Json(new { logoutPass = "true" },JsonRequestBehavior.AllowGet);
        }
    }
}
