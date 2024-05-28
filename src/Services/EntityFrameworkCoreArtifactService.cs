using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mims.Data;
using mims.Models;
using mims.Services.Interfaces;

namespace mims.Services;

public class EntityFrameworkCoreArtifactService : IArtifactService
{
  // private readonly ArtifactContext _artifactContext;
  private readonly IDbContextFactory<ArtifactContext> _artifactContextFactory;
  public EntityFrameworkCoreArtifactService(IDbContextFactory<ArtifactContext> artifactContextFactory)
  {
    this._artifactContextFactory = artifactContextFactory;
  }

  public async Task<int> AddArtifact(Artifact artifact)
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
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
    await _artifactContext.AddAsync(artifact);
    return await _artifactContext.SaveChangesAsync();


  }

  public string GetArtifactName()
  {
    return "DUMMY STRING";
  }
  public async Task<IEnumerable<Artifact>> GetAllArtifacts()
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    IEnumerable<Artifact> artifacts = _artifactContext.Artifacts.ToList();
    return artifacts;
  }

  public async Task<int> GetArtifactCount()
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    int count = await _artifactContext.Artifacts.CountAsync();
    return count;
  }
  public async Task<IEnumerable<Artifact>> GetRecentlyAddedArtifacts(int noOfArtifacts)
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    IEnumerable<Artifact> artifacts = await _artifactContext.Artifacts
      .OrderByDescending(artifact => artifact.CreatedDate)
      .Take(noOfArtifacts).ToListAsync();
    return artifacts;
  }

  public async Task<int> UpdateArtifact(Artifact artifact)
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    artifact.CreatedDate = new DateTime();
    artifact.UpdatedDate = new DateTime();
    _artifactContext.Update(artifact);
    return await _artifactContext.SaveChangesAsync();
  }

}
