using Microsoft.AspNetCore.Components.Forms;

namespace mims.Services;

public class MediaService
{
  private readonly IConfiguration _config;
  private readonly IWebHostEnvironment _environment;
  private string StoragePath => Path.Combine(
                                       _environment.WebRootPath,
                                       _config.GetValue<string>("FileStorage")!
                                );

  public string baseStoragePath => _config.GetValue<string>("FileStorage")!;

  public MediaService(IConfiguration config, IWebHostEnvironment environment)
  {
    _config = config;
    _environment = environment;
  }
  public async Task<string> CaptureFile(IBrowserFile File, long MaxFileSize)
  {
    Console.WriteLine("Capturing File");
    try
    {
      string newFileName = Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(File.Name));
      Console.WriteLine("New Name: " + newFileName);
      string relativePath = Path.Combine("artifacts", newFileName);
      Console.WriteLine("Relative Path: " + relativePath);
      string absoluteDirectory = Path.Combine(StoragePath, "artifacts");
      Console.WriteLine("Absolute Path: " + absoluteDirectory);
      string absolutePath = Path.Combine(absoluteDirectory, newFileName);

      Directory.CreateDirectory(absoluteDirectory);
      Console.WriteLine("File Path: " + absolutePath);

      await using FileStream fs = new(absolutePath, FileMode.Create, FileAccess.ReadWrite);
      await File.OpenReadStream(MaxFileSize).CopyToAsync(fs);
      Console.WriteLine("Successfully uploaded file Name:" + relativePath);
      return relativePath;
    }
    catch (Exception e)
    {
      Console.WriteLine("Error Occured ::");
      Console.WriteLine(e.Message);
      return "";
      throw;
    }
  }
}
