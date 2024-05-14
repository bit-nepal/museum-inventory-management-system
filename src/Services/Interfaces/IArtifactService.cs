using Microsoft.AspNetCore.Mvc;
using mims.Models;

namespace mims.Services.Interfaces;

public interface IArtifactService
{
  string GetArtifactName();
  IActionResult AddArtifact();
  IEnumerable<Artifact> GetAllArtifacts();

  Task<int> GetArtifactCount();
}
