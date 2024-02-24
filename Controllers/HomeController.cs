using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebAppMVC.Models;
using System.Text.Encodings.Web;

namespace FirstWebAppMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public List<Person> personList = new();


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

        personList.Add(new Person()
        {
            Name = "Thalha",
            Age = 20,
            Department = "ECE"
        });
        personList.Add(new Person()
        {
            Name = "Hammadh",
            Age = 18,
            Department = "AI"
        });
    }

    public IActionResult Index()
    {
        return View();
    }

    // /Home/Welcome?name=Rick&numtimes=4
    public string Welcome(string name, int numTimes = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    }

    public IActionResult Data()
    {
        // Data sharing from Controller to View

        // 1) using ViewData
        ViewData["Message"] = "This is the message from the controller";

        // 2) Passing the attribute
        var person = new Person()
        {
            Name = "Thalha",
            Age = 20,
            Department = "ECE"
        };
        // return View(person);

        // for sharing both data - use ViewData and personList
        ViewData["Person"] = person;

        return View(personList);

        // return View("Data")
        // return View("Data", person)
    }

    // Multiple models in a single View using ViewBag
    public IActionResult MultiView()
    {
        ViewData["title"] = "CRUD APP";
        // 
        ViewBag.Name = "Thalha";
        ViewBag.BadName = "Vinisha";
        ViewBag.Person = new Person() { Name = "person1", Age = 20, Department = "ECE" };
        ViewBag.Profile = new Profile() { name = "person2", age = 20, dept = "ECE" };
        ViewBag.PersonList = new List<Person>
        {
            new Person { Name = "Thalha", Age = 20, Department = "ECE"},
            new Person { Name = "Deepthi", Age = 20, Department = "ECE"},
            new Person { Name = "Vinisha", Age = 20, Department = "ECE"}
        };
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Form()
    {
        return View();
    }

    // 

    [HttpPost]
    public IActionResult Data(Person person)
    {
        personList.Add(person);

        Console.WriteLine(personList);

        return View(personList);
    }

    // 


}
