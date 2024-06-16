using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mims.Authorization.Constants;
using mims.Views.Admin.Artifact;

namespace mims.Controllers;

[Authorize(Policy = ApplicationPolicy.Administrators)]
[Route("Admin/Artifacts")]
public class ArtifactController : Controller
{
  private readonly ILogger<ArtifactController> _logger;
  private const string rootViewDirectory = "/Views/Admin/Artifact/";
  public ArtifactController(ILogger<ArtifactController> logger)
  {
    _logger = logger;
  }


  [Authorize(Policy = ApplicationPolicy.Administrators)]
  public IActionResult Index()
  {
    return View(rootViewDirectory + "Index.cshtml");
  }

  [Authorize(Policy = ApplicationPolicy.Administrators)]
  [Route("Create")]
  public IActionResult Create()
  {
    return View(rootViewDirectory + "Create.cshtml");
  }

  [Authorize(Policy = ApplicationPolicy.Administrators)]
  [Route("Update/{ArtifactId}")]
  // [HttpGet("{ArtifactId}")]
  public IActionResult Update(int artifactId)
  {
    var updateModel = new UpdateModel() { ArtifactId = artifactId };
    Console.WriteLine("Artifact id from contreoller Update : " + artifactId);
    return View($"{rootViewDirectory}Update.cshtml", updateModel);
  }

  [Authorize(Policy = ApplicationPolicy.Administrators)]
  [HttpGet("{ArtifactId}")]
  public IActionResult GetTenantById(int artifactId)
  {
    var detailModel = new DetailsModel() { ArtifactId = artifactId };
    Console.WriteLine("Artifact id from contreoller Details: " + artifactId);
    return View(rootViewDirectory + "Details.cshtml", detailModel);
  }

}
