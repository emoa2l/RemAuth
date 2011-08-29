namespace RemAuth.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
           return View();
        }
    }
}
