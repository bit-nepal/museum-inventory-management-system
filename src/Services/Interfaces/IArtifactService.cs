using Microsoft.AspNetCore.Mvc;
using mims.Models;

namespace mims.Services.Interfaces;

public interface IArtifactService
{
  string GetArtifactName();
  Task<int> AddArtifact(Artifact artifact);

    Task<int> UpdateArtifact(Artifact artifact);
  IEnumerable<Artifact> GetAllArtifacts();

  Task<int> GetArtifactCount();
  IEnumerable<Artifact> GetRecentlyAddedArtifacts(int noOfArtifacts);
  
}
