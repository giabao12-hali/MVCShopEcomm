using ASM.Models;
using ASM.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{
    public class NguoidungController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private INguoiDungSvc _nguoiDungSvc;

        public NguoidungController(IWebHostEnvironment webHostEnvironment, INguoiDungSvc nguoiDungSvc)
        {
            _webHostEnvironment = webHostEnvironment;
            _nguoiDungSvc = nguoiDungSvc;
        }
        // GET: NguoidungController
        public ActionResult Index()
        {
            return View(_nguoiDungSvc.GetNguoiDungAll());
        }

        // GET: NguoidungController/Details/5
        public ActionResult Details(int id)
        {
            var nguoidung = _nguoiDungSvc.GetNguoidung(id);
            return View(nguoidung);
        }

        // GET: NguoidungController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NguoidungController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nguoidung nguoidung)
        {
            try
            {
                _nguoiDungSvc.AddNguoiDung(nguoidung);
                return RedirectToAction(nameof(Details), new { id = nguoidung.NguoiDungId });
            }
            catch
            {
                return View();
            }
        }

        // GET: NguoidungController/Edit/5
        public ActionResult Edit(int id)
        {
            var nguoidung = _nguoiDungSvc.GetNguoidung(id);
            return View(nguoidung);
        }

        // POST: NguoidungController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Nguoidung nguoidung)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nguoiDungSvc.EditNguoiDung(id, nguoidung);
                }
                return RedirectToAction(nameof(Details), new { id = nguoidung.NguoiDungId });
            }
            catch
            {
                return RedirectToAction(nameof(Index));

            }
        }

        // GET: NguoidungController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NguoidungController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
