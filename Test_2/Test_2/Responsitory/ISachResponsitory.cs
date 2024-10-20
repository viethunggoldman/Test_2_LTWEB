using Test_2.Models;
namespace Test_2.Responsitory
{
    public interface ISachResponsitory
    {
        TLoaiSach Add(TLoaiSach item);
        TLoaiSach Update(TLoaiSach item);
        TLoaiSach Delete(String item);
        TLoaiSach GetLoaiSach(String ma_item);
        IEnumerable<TLoaiSach> GetAllLoaiSach();
    }
}
