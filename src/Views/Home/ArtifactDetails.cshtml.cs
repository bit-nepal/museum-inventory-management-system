using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mims.Views.Home
{
  public class DetailsModel : PageModel
  {
    [BindProperty(SupportsGet = true)]
    public int ArtifactId { get; set; }
    public void OnGet()
    {
    }
  }
}
