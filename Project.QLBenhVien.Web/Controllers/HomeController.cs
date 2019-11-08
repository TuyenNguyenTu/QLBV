using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Project.QLBenhVien.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : QLBenhVienControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}