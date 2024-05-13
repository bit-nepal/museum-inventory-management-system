using mims.Services.Interfaces;

namespace mims.Services;

public class EntityFrameworkCoreArtifactService : IArtifactService
{
  public string GetArtifactName()
  {
    return "DUMMY STRING";
  }
}
