using Microsoft.AspNetCore.Identity;
using mims.Models;

namespace mims.Services.Interfaces;

public interface IArtifactService
{
  Task<IdentityResult> AddArtifact(Artifact artifact);
  Task<IdentityResult> UpdateArtifact(Artifact artifact);
  Task<IEnumerable<Artifact>> GetAllArtifacts();
  Task<Artifact> GetArtifact(int ArtifactId);
  Task<int> DeleteArtifact(int ArtifactId);

}
