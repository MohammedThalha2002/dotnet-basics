using Microsoft.AspNetCore.Mvc;
using FirstWebAppMVC.Models;

namespace FirstWebAppMVC.Controllers;

public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Data()
    {
        string name = "Vinisha_ECE"; // database

        // Console.WriteLine(name);

        // 1) ViewData[]
        ViewData["name"] = name.Split("_")[0];
        ViewData["dept"] = name.Split("_")[1];

        // 2) Using objects
        var profileData = new Profile()
        {
            name = "Vinisha",
            dept = "ECE",
            age = 20
        };
        // 1)
        ViewData["profileData"] = profileData;
        // 2


        return View(profileData);
    }
}