using Microsoft.AspNetCore.Mvc;

namespace TvShows.Controllers;

public class HomeController : Controller {

    /* ----- Index view ----- */
    public IActionResult Index()
    {
        return View();
    }

    /* ----- View for added TvShows ----- */
    public IActionResult TvShows()
    {
        return View();
    }

    /* ----- View for adding a Tvshow ----- */
    public IActionResult AddTvShow() 
    {
        return View();
    }
}