using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Web_QLDiemSV.Models;
using Newtonsoft.Json;
using Web_QLDiemSV.Repository;


namespace Web_QLDiemSV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISinhVienRepo _repo;
        private const string SessionMaSv = "maSv";
        private const string login = "isLogin";

        public HomeController(ILogger<HomeController> logger, ISinhVienRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(TaiKhoan objUser)
        {
            bool isLogin = _repo.PostDangNhap(objUser) == "true";
            if(isLogin)
            {
                HttpContext.Session.SetString(SessionMaSv, objUser.MaSinhVien.ToString());
                HttpContext.Session.SetString(login, "true");
                return RedirectToAction(actionName: "Index", controllerName: "SinhVien");
            }
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString(SessionMaSv, "");
            HttpContext.Session.SetString(login, "false");
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
