using Microsoft.AspNetCore.Mvc;

namespace pks5_core.Controllers
{
    public class AuthorizedController : Controller
    {
        private readonly ILogger<AuthorizedController> _logger;
        Pks5Context db;
        public AuthorizedController(ILogger<AuthorizedController> logger, Pks5Context context)
        {
            _logger = logger;
            db = context;
        }
        [HttpGet]
        public IActionResult ViewOlimps()
        {
            var user = (from usr in db.Users
                        where usr.Login == Request.Cookies["Login"]
                        where usr.Password == Request.Cookies["Password"]
                        select usr).FirstOrDefault();


            if (user == null)
            {
                return Redirect("Index");
            }
            SortResponse response = new SortResponse();
            var olimps_data = (from olimp in db.Olimp
                               select olimp).ToList();

            Tuple<SortResponse, List<Olimps>> tuple = new Tuple<SortResponse, List<Olimps>>(response, olimps_data);
            return View(tuple);
        }
        [HttpPost]
        public IActionResult ViewOlimps(SortResponse response)
        {
            var user = (from usr in db.Users
                        where usr.Login == Request.Cookies["Login"]
                        where usr.Password == Request.Cookies["Password"]
                        select usr).FirstOrDefault();

            if (user == null)
            {
                return Redirect("Home");
            }
            var olimps_data = (from olimp in db.Olimp
                               where response.choosen_vid == olimp.Vid
                               select olimp).ToList();
            Tuple<SortResponse, List<Olimps>> tuple = new Tuple<SortResponse, List<Olimps>>(response, olimps_data);

            return View(tuple);
        }
        [HttpGet]
        public IActionResult ViewMarks()
        {
            var user = (from usr in db.Users
                        where usr.Login == Request.Cookies["Login"]
                        where usr.Password == Request.Cookies["Password"]
                        select usr).FirstOrDefault();


            if (user == null)
            {
                return Redirect("Index");
            }
            SearchResponse response = new SearchResponse();
            var marks_data = (from mark in db.Marks
                              select mark).ToList();

            Tuple<SearchResponse, List<Mark>> tuple = new Tuple<SearchResponse, List<Mark>>(response, marks_data);
            return View(tuple);
        }

        [HttpPost]
        public IActionResult ViewMarks(SearchResponse response)
        {
            var user = (from usr in db.Users
                        where usr.Login == Request.Cookies["Login"]
                        where usr.Password == Request.Cookies["Password"]
                        select usr).FirstOrDefault();


            if (user == null)
            {
                return Redirect("Index");
            }

            var marks_data = (from mark in db.Marks
                              where mark.Subject.Contains(response.search_string)
                              select mark).ToList();

            Tuple<SearchResponse, List<Mark>> tuple = new Tuple<SearchResponse, List<Mark>>(response, marks_data);
            return View(tuple);
        }


        [HttpGet]
        public IActionResult ViewPrepods()
        {
            var user = (from usr in db.Users
                        where usr.Login == Request.Cookies["Login"]
                        where usr.Password == Request.Cookies["Password"]
                        select usr).FirstOrDefault();


            if (user == null)
            {
                return Redirect("Index");
            }

            var prepods_data = (from prepod in db.Prepods
                              select prepod).ToList();

            
            return View(prepods_data);
        }
    }
}
