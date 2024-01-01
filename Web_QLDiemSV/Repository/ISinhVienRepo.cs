using System.Net;
using Web_QLDiemSV.Models;

namespace Web_QLDiemSV.Repository
{
    public interface ISinhVienRepo
    {
        public string PostDangNhap(TaiKhoan taiKhoan);
        public HttpStatusCode PutMatKhau(TaiKhoan taiKhoan);
        public List<BangDiem> GetBangDiem(int masv);
        public SinhVien GetSinhVien(int masv);
    }
}
