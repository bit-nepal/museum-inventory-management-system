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
    await _artifactContext.AddAsync(artifact);
    return await _artifactContext.SaveChangesAsync();
    // return _artifactContext.SaveChanges();
  }

  public async Task<IEnumerable<Artifact>> GetAllArtifacts()
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    IEnumerable<Artifact> artifacts = _artifactContext.Artifacts
                                                          .ToList()
                                                          .Where(artifact => !artifact.IsDeleted);
    return artifacts;
  }

  public async Task<int> GetArtifactCount()
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    int count = await _artifactContext.Artifacts.Where(a => a.IsDeleted == false).CountAsync();
    return count;
  }
  public async Task<IEnumerable<Artifact>> GetRecentlyAddedArtifacts(int noOfArtifacts)
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    IEnumerable<Artifact> artifacts = await _artifactContext.Artifacts
      .Where(artifact => !artifact.IsDeleted)
      .OrderByDescending(artifact => artifact.CreatedAt)
      .Take(noOfArtifacts).ToListAsync();
    return artifacts;
  }

  public async Task<int> UpdateArtifact(Artifact artifact)
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    artifact.UpdatedAt = DateTime.Now;
    _artifactContext.Update(artifact);
    return await _artifactContext.SaveChangesAsync();
  }

  public async Task<Artifact> GetArtifact(int ArtifactId)
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    var artifact = await _artifactContext.Artifacts.FindAsync(ArtifactId);
    return artifact;
  }
}
