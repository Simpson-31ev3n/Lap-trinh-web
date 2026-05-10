using BaiTapVeNha3.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha3.Controllers
{
    public class StudentController : Controller
    {
        // Lưu trữ số lượng SV đăng ký theo từng ngành (static để giữ giữa các request)
        private static Dictionary<string, int> _soLuongTheoNganh = new Dictionary<string, int>
        {
            { "CNPM", 0 },
            { "HTTT", 0 },
            { "ANM",  0 },
            { "TTNT", 0 },
            { "MMT",  0 }
        };

        // GET: /Student/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Student/Index
        [HttpPost]
        public IActionResult Index(StudentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Tăng số lượng đăng ký của ngành được chọn
            if (_soLuongTheoNganh.ContainsKey(model.ChuyenNganh))
                _soLuongTheoNganh[model.ChuyenNganh]++;
            else
                _soLuongTheoNganh[model.ChuyenNganh] = 1;

            // Truyền số lượng sang View kết quả
            ViewBag.SoLuong = _soLuongTheoNganh[model.ChuyenNganh];

            return View("ShowKQ", model);
        }
    }
}
