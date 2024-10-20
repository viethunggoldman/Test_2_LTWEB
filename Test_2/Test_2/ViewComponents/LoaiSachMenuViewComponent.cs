using Test_2.Models;
using Test_2.Responsitory;
using Microsoft.AspNetCore.Mvc;
namespace Test_2.ViewComponents
{
    public class LoaiSachMenuViewComponent:ViewComponent
    {
        private readonly ISachResponsitory _responsitory;
        public LoaiSachMenuViewComponent(ISachResponsitory responsitory)
        {
            _responsitory = responsitory;
        }
        public IViewComponentResult Invoke()
        {
            var loaisach = _responsitory.GetAllLoaiSach().OrderBy(x=> x.TenLoai);
            return View(loaisach);
        }
    }
}
