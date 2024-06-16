using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mims.Authorization.Constants;
using mims.Models;

namespace mims.Controllers;

[Authorize(Policy = ApplicationPolicy.Administrators)]
public class AdminController : Controller
{
  private readonly ILogger<AdminController> _logger;

  public AdminController(ILogger<AdminController> logger)
  {
    _logger = logger;
  }

  [Authorize(Policy = ApplicationPolicy.Administrators)]
  public IActionResult Index()
  {
    return View();
  }


  [Authorize(Policy = ApplicationPolicy.Administrators)]
  public IActionResult Privacy()
  {
    return View();
  }

  [Authorize(Policy = ApplicationPolicy.Administrators)]
  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
