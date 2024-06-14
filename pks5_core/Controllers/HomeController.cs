using Microsoft.AspNetCore.Mvc;
using pks5_core.Models;
using System.Diagnostics;

namespace pks5_core.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        Pks5Context db;
        public HomeController(ILogger<HomeController> logger, Pks5Context context)
        {
            _logger = logger;
            db = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult login(User model)
        {
            if (ModelState.IsValid)
            {
                var is_in_base = (from users in db.Users
                                  where model.Login == users.Login && model.Password == users.Password
                                  select users).FirstOrDefault();
                if (is_in_base is null)
                {
                    ViewBag.Error = "Неверный логин или пароль";
                    return Redirect("Index");
                }
                else
                {
                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30)
                    };
                    Response.Cookies.Append("Login", is_in_base.Login, cookieOptions);
                    Response.Cookies.Append("Password", is_in_base.Password, cookieOptions);

                    return RedirectToAction("ViewOlimps", "Authorized");

                }
            }
            else
            {
                return View("Index");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
