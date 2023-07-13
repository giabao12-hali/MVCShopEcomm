using ASM.Helpers;
using asm.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASM.Models;

namespace ASM.Controllers
{
    public class MonAnController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IMonAnSvc _monAnSvc;
        private IUploadHelpers _uploadHelpers;

        public MonAnController(IWebHostEnvironment webHostEnvironment, IMonAnSvc monAnSvc, IUploadHelpers uploadHelpers)
        {
            _webHostEnvironment = webHostEnvironment;
            _monAnSvc = monAnSvc;
            _uploadHelpers = uploadHelpers;
        }
        // GET: MonAnController
        public ActionResult Index()
        {
            return View(_monAnSvc.GetMonAnAll());
        }

        // GET: MonAnController/Details/5
        public ActionResult Details(int id)
        {
            var monAn = _monAnSvc.GetMonAn(id);
            return View(monAn);
        }

        // GET: MonAnController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonAnController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MonAn monAn)
        {
            string thumuccon = "images";
            try
            {
                if (monAn.ImageFile != null)
                {
                    string wwwRootPatch = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(monAn.ImageFile.FileName);
                    string extension = Path.GetExtension(monAn.ImageFile.FileName);
                    monAn.Hinh = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPatch + "/images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await monAn.ImageFile.CopyToAsync(fileStream);
                    }
                    string rootPath = Path.Combine(_webHostEnvironment.WebRootPath);
                    _uploadHelpers.UploadImage(monAn.ImageFile, rootPath, thumuccon);
                    monAn.Hinh = monAn.ImageFile.FileName;
                }
                _monAnSvc.AddMonAn(monAn);
                return RedirectToAction(nameof(Details), new { id = monAn.MonAnId });
            }
            catch
            {
                return View();
            }
        }

        // GET: MonAnController/Edit/5
        public ActionResult Edit(int id)
        {
            var monAn = _monAnSvc.GetMonAn(id);
            return View(monAn);
        }

        // POST: MonAnController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MonAn monAn)
        {
            string thumuccon = "images";
            try
            {
                if (ModelState.IsValid)
                {
                    if (monAn.ImageFile != null)
                    {
                        string rootPath = Path.Combine(_webHostEnvironment.WebRootPath);
                        _uploadHelpers.UploadImage(monAn.ImageFile, rootPath, thumuccon);
                        monAn.Hinh = monAn.ImageFile.FileName;
                    }
                }
                _monAnSvc.EditMonAn(id, monAn);
                return RedirectToAction(nameof(Details), new { id = monAn.MonAnId });
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MonAnController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonAnController/Delete/5
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
