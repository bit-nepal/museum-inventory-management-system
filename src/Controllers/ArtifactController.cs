using Microsoft.AspNetCore.Mvc;

namespace mims.Controllers;

[Route("Admin/Artifact")]
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
    public IActionResult Update()
    {
        return View(rootViewDirectory + "Update.cshtml");
    }
}
