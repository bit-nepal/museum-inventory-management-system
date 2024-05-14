using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mims.Data;
using mims.Models;
using mims.Services.Interfaces;

namespace mims.Services;

public class EntityFrameworkCoreArtifactService : IArtifactService
{
  private readonly ArtifactContext _artifactContext;
  public EntityFrameworkCoreArtifactService(ArtifactContext artifactContext)
  {
    this._artifactContext = artifactContext;
  }

  public IActionResult AddArtifact()
  {
    throw new NotImplementedException();
  }

  public string GetArtifactName()
  {
    return "DUMMY STRING";
  }
  public IEnumerable<Artifact> GetAllArtifacts()
  {
    IEnumerable<Artifact> artifacts = _artifactContext.Artifacts.ToList();
    return artifacts;
  }

    public async Task<int> GetArtifactCount()
    {
        int count= await _artifactContext.Artifacts.CountAsync();
        return count;
    }
  public IEnumerable<Artifact> GetRecentlyAddedArtifacts(int noOfArtifacts)
  {
    IEnumerable<Artifact> artifacts = _artifactContext.Artifacts
      .OrderBy(artifact => artifact.CreatedDate)
      .Take(noOfArtifacts);
    return artifacts;
  }

}
