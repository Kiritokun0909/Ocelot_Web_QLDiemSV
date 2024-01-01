using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_QLDiemSV.Models;
using Web_QLDiemSV.Repository;

namespace Web_QLDiemSV.Controllers
{
    public class BangDiemController : Controller
    {
        private readonly ISinhVienRepo _repo;
        private const string SessionMaSv = "maSv";

        public BangDiemController(ISinhVienRepo repo)
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

            List<BangDiem> bd = _repo.GetBangDiem(Int32.Parse(maSv));
            var diemTheoKyNamHoc = bd.GroupBy(d => new { d.Nam, d.Ky })
                                            .Select(group => new { Nam = group.Key.Nam, Ky = group.Key.Ky, bd = group.ToList() })
                                            .ToList();
            return View(diemTheoKyNamHoc);
        }
    }
}
