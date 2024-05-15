using Microsoft.AspNetCore.Mvc;
using mims.Models;

namespace mims.Services.Interfaces;

public interface IArtifactService
{
  string GetArtifactName();
  IActionResult AddArtifact(Artifact artifact);
  IEnumerable<Artifact> GetAllArtifacts();

  Task<int> GetArtifactCount();
  IEnumerable<Artifact> GetRecentlyAddedArtifacts(int noOfArtifacts);
  
}
