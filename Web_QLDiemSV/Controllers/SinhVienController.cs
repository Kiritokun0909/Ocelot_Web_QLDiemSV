using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_QLDiemSV.Models;
using Web_QLDiemSV.Repository;

namespace Web_QLDiemSV.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ISinhVienRepo _repo;
        private const string SessionMaSv = "maSv";

        public SinhVienController(ISinhVienRepo repo)
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

            SinhVien sv = _repo.GetSinhVien(Int32.Parse(maSv));
            return View(sv);
        }
    }
}
