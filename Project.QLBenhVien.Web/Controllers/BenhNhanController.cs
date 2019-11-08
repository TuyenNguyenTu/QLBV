using Project.QLBenhVien.EntityFramework;
using Project.QLBenhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.QLBenhVien.Web.Controllers
{
    public class BenhNhanController : QLBenhVienControllerBase
    {
        // GET: BenhNhan
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetBenhNhan()
        {
            QLBenhVienDbContext db = new QLBenhVienDbContext();
            List<BenhNhan> benhNhanList = db.BenhNhans.ToList();
            return Json(benhNhanList, JsonRequestBehavior.AllowGet);
        }
    }
}