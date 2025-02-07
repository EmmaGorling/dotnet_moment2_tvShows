using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TvShows.Models;

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
        ViewData["Title"] = "Lägg till serie";
        return View();
    }
    [HttpPost]
    public IActionResult AddTvShow(TvshowModel model)
    {
        ViewData["Title"] = "Lägg till serie";
        // Validate input
        if(ModelState.IsValid) {
            // Read json-file
            string jsonStr = System.IO.File.ReadAllText("shows.json");
            // Deserialize
            var shows = JsonSerializer.Deserialize<List<TvshowModel>>(jsonStr);

            // Add new show
            if(shows != null)
            {
                shows.Add(model);
                // Serialize JSON
                jsonStr = JsonSerializer.Serialize(shows);
                // Write to file
                System.IO.File.WriteAllText("shows.json", jsonStr);
            }
        }

        return View();
    }
}