using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Test_2.Models;
using X.PagedList;

namespace Test_2.Controllers
{
    public class HomeController : Controller
    {
        QlthuVienContext db = new QlthuVienContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstsach = db.TSaches.ToList();
            return View(lstsach);
        }
        public IActionResult DanhMucSanPham(int? page)

        {
            /*var lstsanpham = db.TDanhMucSps.ToList();
            return View(lstsanpham);*/
            //// phan trang
            int psize = 12;
            int pagenum = page == null || page < 0 ? 1 : page.Value;
            var listsanpham = db.TSaches.AsNoTracking().OrderBy(x => x.TenSach);
            PagedList<TSach> lst = new PagedList<TSach>(listsanpham, pagenum, psize);
            return View(lst);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /* sua san pham */
        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
           
            ViewBag.MaLoai = new SelectList(db.TLoaiSaches.ToList(), "MaLoai", "TenLoai");
            ViewBag.MaNgonNgu = new SelectList(db.TNhaXbs.ToList(), "MaNgonNgu", "TenNgonNgu");
            ViewBag.MaNxb = new SelectList(db.TNhaXbs.ToList(), "MaNxb", "TenNxb");
            
            var sanPham = db.TSaches.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TSach sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham","Home");

            }
            return View(sanpham);
        }





    }
}
