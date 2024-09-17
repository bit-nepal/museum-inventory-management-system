using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using mims.Models;
using mims.Views.Home;

namespace mims.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private const string rootViewDirectory = "/Views/Home/";
  public override void OnActionExecuting(ActionExecutingContext filterContext)
  {
    ViewBag.Layout = "~/Views/Shared/_Layout_Home.cshtml";
    base.OnActionExecuting(filterContext);
  }
  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Privacy()
  {
    return View();
  }
  public IActionResult VirtualTour()
  {
    return View();
  }
  [HttpGet("Artifacts/{ArtifactId}")]
  public IActionResult GetTenantById(int artifactId)
  {
    var detailModel = new DetailsModel() { ArtifactId = artifactId };
    Console.WriteLine("Artifact id from contreoller Details: " + artifactId);
    return View(rootViewDirectory + "ArtifactDetails.cshtml", detailModel);
  }
  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
