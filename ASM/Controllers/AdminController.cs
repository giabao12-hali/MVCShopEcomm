using ASM.Constant;
using ASM.Models;
using ASM.Models.Services;
using ASM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASM.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private INguoiDungSvc _nguoidungSvc;

        public AdminController(IWebHostEnvironment webHostEnvironment, INguoiDungSvc nguoidungSvc)
        {
            _webHostEnvironment = webHostEnvironment;
            _nguoidungSvc = nguoidungSvc;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string? returnUrl)
        {
            string userName = HttpContext.Session.GetString(SessionKey.Nguoidung.UserName) ?? "";
            if (userName != null && userName != "")
            {
                return RedirectToAction("Home", "Index");
            }

            #region Hiển thị Login
            ViewLogin login = new ViewLogin();
            login.ReturnUrl = returnUrl;
            return View(login);
            #endregion
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(ViewLogin viewLogin)
        {
            if (ModelState.IsValid)
            {
                Nguoidung nguoidung = _nguoidungSvc.Login(viewLogin);
                if (nguoidung != null)
                {
                    HttpContext.Session.SetString(SessionKey.Nguoidung.UserName, nguoidung.UserName);
                    HttpContext.Session.SetString(SessionKey.Nguoidung.FullName, nguoidung.FullName);
                    HttpContext.Session.SetString(SessionKey.Nguoidung.NguoidungContext,
                        JsonConvert.SerializeObject(nguoidung));

                    return RedirectToAction(nameof(Index), "Admin");
                    //return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            return View(viewLogin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKey.Nguoidung.UserName);
            HttpContext.Session.Remove(SessionKey.Nguoidung.FullName);
            HttpContext.Session.Remove(SessionKey.Nguoidung.NguoidungContext);

            return RedirectToAction(nameof(Index), "Admin");
            //HttpContext.Session.Clear();
            //return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
