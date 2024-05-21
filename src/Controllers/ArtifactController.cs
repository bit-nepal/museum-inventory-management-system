using Microsoft.AspNetCore.Mvc;

namespace mims.Controllers;

[Route("Admin/Artifacts")]
public class ArtifactController : Controller
{
  private readonly ILogger<ArtifactController> _logger;
  private const string rootViewDirectory = "/Views/Admin/Artifact/";
  public ArtifactController(ILogger<ArtifactController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View(rootViewDirectory + "Index.cshtml");
  }
  [Route("Create")]
  public IActionResult Create()
  {
    return View(rootViewDirectory + "Create.cshtml");
  }
  [Route("Update")]
  [HttpGet("{ArtifactId}")]
  public IActionResult Update(int ArtifactId)
  {
    Console.WriteLine("Artifact id from contreoller : " +  ArtifactId);
        return View($"{rootViewDirectory}Update.cshtml?{nameof(ArtifactId)}={ArtifactId}"  );
        //return RedirectToPage("/Admin/Artifacts/Update", new { ArtifactId });
    }

  [HttpGet("{ArtifactId}")]
  public IActionResult GetTenantById(int ArtifactId)
  {
    return View(rootViewDirectory + "Details.cshtml");
  }

}
