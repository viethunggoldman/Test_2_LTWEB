using Test_2.Models;
namespace Test_2.Responsitory
{
    public class SachResponsitory : ISachResponsitory
    {
        private readonly QlthuVienContext _context;
        public SachResponsitory(QlthuVienContext context)
        {
            _context = context;
        }
        TLoaiSach ISachResponsitory.Add(TLoaiSach item)
        {
           _context.TLoaiSaches.Add(item);
            _context.SaveChanges();
            return item;
        }

        TLoaiSach ISachResponsitory.Delete(string item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TLoaiSach> ISachResponsitory.GetAllLoaiSach()
        {
            return _context.TLoaiSaches;
        }

        TLoaiSach ISachResponsitory.GetLoaiSach(string ma_item)
        {
            return _context.TLoaiSaches.Find(ma_item);
        }

        TLoaiSach ISachResponsitory.Update(TLoaiSach item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
    }
}
