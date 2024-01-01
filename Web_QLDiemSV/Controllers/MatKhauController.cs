using Microsoft.AspNetCore.Mvc;
using Web_QLDiemSV.Models;
using Web_QLDiemSV.Repository;

namespace Web_QLDiemSV.Controllers
{
    public class MatKhauController : Controller
    {
        private readonly ISinhVienRepo _repo;
        private const string SessionMaSv = "maSv";
        private const string login = "isLogin";

        public MatKhauController(ISinhVienRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var maSv = HttpContext.Session.GetString(SessionMaSv);
            if (maSv == null || maSv == "")
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult DoiMatKhau(TaiKhoan objUser)
        {
            objUser.MaSinhVien = Int32.Parse(HttpContext.Session.GetString(SessionMaSv));
            bool success = (int)_repo.PutMatKhau(objUser) == 200;
            if (success)
            {
                return RedirectToAction(actionName: "Index", controllerName: "SinhVien");
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }
    }
}
