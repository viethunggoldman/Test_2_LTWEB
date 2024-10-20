using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_2.Models;
using Test_2.Models.ProductModels;

namespace Test_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlthuVienContext db = new QlthuVienContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts() /*TDanhMucSp: lay ra full cac phuong thuc ; Product: lay ra phuong thuc co trong Product.cs */
        {
         
            var sanPham = (from p in db.TSaches
                           

                           select new Product
                           {
                               MaSach = p.MaSach,
                               TenSach = p.TenSach,
                               MaLoai = p.MaLoai,
                               FileAnh = p.FileAnh,
                               GiaTriSach = p.GiaTriSach

                           }).ToList();
            return sanPham;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(string maloai)
        {
            
            var sanPham = (from p in db.TSaches
                           where p.MaLoai == maloai

                           select new Product
                           {
                               MaSach = p.MaSach,
                               TenSach = p.TenSach,
                               MaLoai = p.MaLoai,
                               FileAnh = p.FileAnh,
                               GiaTriSach = p.GiaTriSach

                           }).ToList();
            return sanPham;
        }
    }
}
