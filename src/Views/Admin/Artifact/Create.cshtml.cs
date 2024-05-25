using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mims.Models;

namespace mims.Views.Admin.Artifacts
{
  public class CreateModel : PageModel
  {
    public void OnGet()
    {
      mims.Models.Artifact Artifact = new mims.Models.Artifact();
    }

    public async Task HandleValidSubmit(mims.Models.Artifact artifact)
    {
      // Handle the artifact data here.
      // Example:
      // await _artifactService.AddArtifactAsync(artifact);

      // For now, let's just log the artifact name
      System.Console.WriteLine($"Artifact submitted: {artifact.Name}");
    }
  }
}
