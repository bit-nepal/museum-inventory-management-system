using Microsoft.AspNetCore.Mvc;
using mims.Data;
using mims.Models;

namespace mims.Controllers
{
    public class ArtifactController : Controller
    {
        private readonly ArtifactContext _artifactContext;
        public ArtifactController(ArtifactContext artifactContext)
        {
            _artifactContext = artifactContext;
        }


    }
}
