using Microsoft.AspNetCore.Mvc;
using mims.Models;

namespace mims.Services.Interfaces;

public interface IArtifactService
{
  string GetArtifactName();
  Task<int> AddArtifact(Artifact artifact);

  Task<int> UpdateArtifact(Artifact artifact);
  Task<IEnumerable<Artifact>> GetAllArtifacts();

  Task<int> GetArtifactCount();
  Task<IEnumerable<Artifact>> GetRecentlyAddedArtifacts(int noOfArtifacts);

}
