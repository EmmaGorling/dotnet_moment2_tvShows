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
        ViewData["Title"] = "Serier jag har sett";
        // Read json-file
        string jsonStr = System.IO.File.ReadAllText("shows.json");
        // Deserialize
        var shows = JsonSerializer.Deserialize<List<TvshowModel>>(jsonStr);

        return View(shows);
    }

    /* ----- Views for adding a Tvshow ----- */
    public IActionResult AddTvShow() 
    {
        ViewData["Title"] = "Lägg till en serie";
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

            // Set Cooke with the title
            HttpContext.Response.Cookies.Append("Latest", $"{model.Title}");

            // Reset form
            ModelState.Clear();

            // Redirect to same page to update the partial
            return RedirectToAction("AddTvShow");
        }

        return View();
    }

    /* ------ Partial for showing last added show ------- */
    public IActionResult LastAddedPartial()
    {
        return PartialView("_LastAdded");
    }

}