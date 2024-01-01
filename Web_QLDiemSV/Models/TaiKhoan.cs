namespace Web_QLDiemSV.Models
{
    public class TaiKhoan
    {
        public TaiKhoan()
        {
 
        }
        public TaiKhoan(int maSinhVien, string matKhau)
        {
            MaSinhVien = maSinhVien;
            MatKhau = matKhau;
        }

        public int MaSinhVien { get; set; }
        public string MatKhau { get; set; }
    }
}
