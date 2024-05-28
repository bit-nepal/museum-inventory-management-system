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

  public Task<int> AddArtifact(Artifact artifact)
  {
    //if (ModelState.IsValid)
    //{
    //    _artifactContext.Artifacts.Add(obj);
    //    _artifactContext.SaveChanges();
    //    return RedirectToAction("Index");
    //}
    //return View(obj);
    //Artifact a = new Artifact();
    artifact.CreatedDate = new DateTime();
    artifact.UpdatedDate = new DateTime();
    _artifactContext.AddAsync(artifact);
    return _artifactContext.SaveChangesAsync();


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
    int count = await _artifactContext.Artifacts.CountAsync();
    return count;
  }
  public async Task<IEnumerable<Artifact>> GetRecentlyAddedArtifacts(int noOfArtifacts)
  {
    IEnumerable<Artifact> artifacts = await _artifactContext.Artifacts
      .OrderByDescending(artifact => artifact.CreatedDate)
      .Take(noOfArtifacts).ToListAsync();
    return artifacts;
  }

  public Task<int> UpdateArtifact(Artifact artifact)
  {
    artifact.CreatedDate = new DateTime();
    artifact.UpdatedDate = new DateTime();
    _artifactContext.Update(artifact);
    return _artifactContext.SaveChangesAsync();
  }

}
