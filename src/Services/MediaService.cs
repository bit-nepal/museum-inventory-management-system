using Microsoft.AspNetCore.Components.Forms;

namespace mims.Services;

public class MediaService
{
  private readonly IConfiguration _config;
  public MediaService(IConfiguration config)
  {
    _config = config;
  }
  public async Task<string> CaptureFile(IBrowserFile File, long MaxFileSize)
  {
    try
    {
      string basePath = Path.GetFullPath(AppContext.BaseDirectory);
      string projectDirectory = Directory.GetParent(basePath)!.Parent!.Parent!.FullName;

      string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(File.Name));
      string relativePath = Path.Combine("artifacts", newFileName);

      string absoluteDirectory = Path.Combine(projectDirectory, _config.GetValue<string>("FileStorage")!, "artifacts");
      string absolutePath = Path.Combine(absoluteDirectory, newFileName);

      Directory.CreateDirectory(absoluteDirectory);
      Console.WriteLine("File Path: " + absolutePath);
      await using FileStream fs = new(absolutePath, FileMode.Create);
      await File.OpenReadStream(MaxFileSize).CopyToAsync(fs);
      return relativePath;
    }
    catch (Exception)
    {
      throw;
    }
  }
}
