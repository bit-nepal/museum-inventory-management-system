using Microsoft.AspNetCore.Mvc;
using mims.Views.Admin.Account;
using mims.Views.Admin.Artifact;

namespace mims.Controllers;

[Route("Admin/Account")]
public class AccountController : Controller
{
  private readonly ILogger<AccountController> _logger;
  private const string rootViewDirectory = "/Views/Admin/Account/";
  public AccountController(ILogger<AccountController> logger)
  {
    _logger = logger;
  }

    [Route("Login")]
  public IActionResult Index()
  {
    return View(rootViewDirectory + "Login.cshtml");
  }

  [Route("Profile")]
  public IActionResult Profile()
  {
    return View(rootViewDirectory + "Profile.cshtml");
  }

    [Route("Password")]
    public IActionResult Password()
    {
        return View(rootViewDirectory + "Password.cshtml");
    }

  //  [Route("Update/{ArtifactId}")]
  //// [HttpGet("{ArtifactId}")]
  //public IActionResult Update(int artifactId)
  //{
  //      //var updateModel = new UpdateModel() { ArtifactId = artifactId };
  //      //Console.WriteLine("Artifact id from controller Update : " + artifactId);
  //      //return View($"{rootViewDirectory}Update.cshtml", updateModel);
  //      return View($"{rootViewDirectory}Update.cshtml");
  //  }

  //[HttpGet("{ArtifactId}")]
  //public IActionResult GetTenantById(int artifactId)
  //{
  //  var detailModel = new DetailsModel() { ArtifactId = artifactId };
  //  Console.WriteLine("Artifact id from controller Details: " + artifactId);
  //  return View(rootViewDirectory + "Details.cshtml", detailModel);
  //}

}
