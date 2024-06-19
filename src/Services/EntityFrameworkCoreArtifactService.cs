using Microsoft.AspNetCore.Identity;
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

  public async Task<IdentityResult> AddArtifact(Artifact artifact)
  {
    try
    {
      var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
      if (artifact is null)
      {
        return IdentityResult.Failed(new IdentityError { Description = "Artifact Cannot Be Null !" });
      }
      else if (artifact.EntryNo is null)
      {
        return IdentityResult.Failed(new IdentityError { Description = "Entry No. Cannot be Empty !" });
      }
      else if (artifact.Name is null)
      {
        return IdentityResult.Failed(new IdentityError { Description = "Name cannot be Empty" });
      }
      else if (artifact.Description is null)
      {
        return IdentityResult.Failed(new IdentityError { Description = "Description cannot be Empty" });
      }
      else if (artifact.PrimaryPhoto?.ImageUrl is null)
      {
        return IdentityResult.Failed(new IdentityError { Description = "Image is Required !" });

      }
      else if (artifact.PrimaryPhoto.ImageNo is null)
      {
        return IdentityResult.Failed(new IdentityError { Description = "Image No. cannot be Empty !" });
      }
      else
      {
        await _artifactContext.AddAsync(artifact);
        int rowsAffected = await _artifactContext.SaveChangesAsync();
        if (rowsAffected > 0)
        {
          return IdentityResult.Success;
        }
        else
        {
          return IdentityResult.Failed(new IdentityError { Description = "Something went Wrong !!" });
        }
      }
    }
    catch (Exception e)
    {
      Console.WriteLine(e.StackTrace);
      return IdentityResult.Failed(new IdentityError { Description = "Something went Wrong !!" });
    }
  }

  public async Task<IEnumerable<Artifact>> GetAllArtifacts()
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    IEnumerable<Artifact> artifacts = _artifactContext.Artifacts
                                                          .ToList()
                                                          .Where(artifact => !artifact.IsDeleted);
    return artifacts;
  }

  public async Task<IdentityResult> UpdateArtifact(Artifact artifact)
  {
    try
    {
      var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
      _artifactContext.Update(artifact);
      var rowsAffected = await _artifactContext.SaveChangesAsync();
      if (rowsAffected > 0)
      {
        return IdentityResult.Success;
      }
      else
      {
        return IdentityResult.Failed(new IdentityError { Description = "Something went Wrong !!" });
      }
    }
    catch (Exception e)
    {
      return IdentityResult.Failed(new IdentityError { Description = e.Message });
    }
  }

  public async Task<Artifact> GetArtifact(int ArtifactId)
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    var artifact = await _artifactContext.Artifacts
                                          .Include(a => a.PrimaryPhoto)
                                          .FirstOrDefaultAsync(a => a.Id == ArtifactId);
    return artifact;
  }

  public async Task<int> DeleteArtifact(int ArtifactId)
  {
    var _artifactContext = await _artifactContextFactory.CreateDbContextAsync();
    Artifact? artifact = await _artifactContext.Artifacts.FindAsync(ArtifactId);
    artifact.IsDeleted = true;
    return await _artifactContext.SaveChangesAsync();
  }
}
