using Newtonsoft.Json;
using System.Net;
using Web_QLDiemSV.Models;
using static System.Net.WebRequestMethods;

namespace Web_QLDiemSV.Repository
{
    public class SinhVienRepo : ISinhVienRepo
    {
        private static readonly string api = "http://localhost:5201/api/sinhvien";

        public string PostDangNhap(TaiKhoan taiKhoan)
        {
            using (var httpClient = new HttpClient())
            {
                string jsonGiangVien = JsonConvert.SerializeObject(taiKhoan);
                HttpResponseMessage response = httpClient.PostAsync(
                    $"{api}/login",
                    new StringContent(jsonGiangVien, System.Text.Encoding.UTF8, "application/json"))
                    .Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public HttpStatusCode PutMatKhau(TaiKhoan taiKhoan)
        {
            using (var httpClient = new HttpClient())
            {
                string jsonTaiKhoan = JsonConvert.SerializeObject(taiKhoan);
                HttpResponseMessage response = httpClient.PutAsync(
                    $"{api}/sinhvien/matkhau",
                    new StringContent(jsonTaiKhoan, System.Text.Encoding.UTF8, "application/json"))
                    .Result;
                return response.StatusCode;
            }
        }

        public List<BangDiem>? GetBangDiem(int masv)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponse = httpClient.GetAsync($"{api}/bangdiem/masinhvien={masv}").Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    string json = httpResponse.Content.ReadAsStringAsync().Result;
                    List<BangDiem> BangDiem = JsonConvert.DeserializeObject<List<BangDiem>>(json);

                    return BangDiem;
                }
            }
            return null;
        }

        public SinhVien? GetSinhVien(int masv)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponse = httpClient.GetAsync($"{api}/sinhvien/masinhvien={masv}").Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    string json = httpResponse.Content.ReadAsStringAsync().Result;
                    SinhVien sv = JsonConvert.DeserializeObject<SinhVien>(json);

                    return sv;
                }
            }
            return null;
        }
    }
}
