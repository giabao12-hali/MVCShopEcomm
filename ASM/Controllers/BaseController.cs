using ASM.Constant;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() { }
        protected string GetUserName()
        {
            return HttpContext.Session.GetString(SessionKey.Nguoidung.UserName) ?? "";
        }
        public string GetFullName()
        {
            return HttpContext.Session.GetString(SessionKey.Nguoidung.FullName) ?? "";
        }
        protected string GetKHEmail()
        {
            return HttpContext.Session.GetString(SessionKey.Khachhang.KH_Email) ?? "";
        }
    }
}
