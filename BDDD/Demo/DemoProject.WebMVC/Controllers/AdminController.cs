using BDDD.ObjectContainer;
using DemoProject.DTO.Admin;
using DemoProject.IApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.WebMVC.Controllers
{
    public class AdminController : Controller
    {
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
            if (userService.ValidateUser(loginDTO))
            {
                return RedirectToAction("Index");
            }
            else 
            {
                return View();
            }
        }
    }
}
