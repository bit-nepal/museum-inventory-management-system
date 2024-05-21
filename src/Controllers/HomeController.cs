using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using mims.Models;

namespace mims.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
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

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
