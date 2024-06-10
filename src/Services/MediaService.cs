using Microsoft.AspNetCore.Components.Forms;

namespace mims.Services;

public class MediaService
{
  private readonly IConfiguration _config;
  private string StoragePath => Path.Combine(
                                        Directory.GetParent(
                                          Path.GetFullPath(AppContext.BaseDirectory)
                                        )!.Parent!.Parent!.Parent!.FullName
                                        ,
                                        "wwwroot"
                                        ,
                                        _config.GetValue<string>("FileStorage")!
                                );

  public string baseStoragePath => _config.GetValue<string>("FileStorage")!;

  public MediaService(IConfiguration config)
  {
    _config = config;
  }
  public async Task<string> CaptureFile(IBrowserFile File, long MaxFileSize)
  {
    try
    {
      string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(File.Name));
      string relativePath = Path.Combine("artifacts", newFileName);

      string absoluteDirectory = Path.Combine(StoragePath, "artifacts");
      string absolutePath = Path.Combine(absoluteDirectory, newFileName);

      Directory.CreateDirectory(absoluteDirectory);
      Console.WriteLine("File Path: " + absolutePath);

      await using FileStream fs = new(absolutePath, FileMode.Create);
      await File.OpenReadStream(MaxFileSize).CopyToAsync(fs);
      return relativePath;
    }
    catch (Exception)
    {
      return "";
      throw;
    }
  }
}
