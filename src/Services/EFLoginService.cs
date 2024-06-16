using mims.Models;
using Microsoft.AspNetCore.Identity;
using mims.DTOs;
using System.ComponentModel.DataAnnotations;
using mims.Services.Interfaces;
namespace mims.Services;

public class EFLoginService : ILoginService<ApplicationUserLoginDTO>
{
  private SignInManager<ApplicationUser> _signInManager;
  private UserManager<ApplicationUser> _userManager;
  private ILogger<EFLoginService> _logger;
  private static readonly EmailAddressAttribute _emailAddressAttribute = new();

  public EFLoginService(SignInManager<ApplicationUser> signInManager,
                        UserManager<ApplicationUser> userManager,
                        ILogger<EFLoginService> logger)
  {
    _logger = logger;
    _signInManager = signInManager;
    _userManager = userManager;
  }

  public async Task<SignInResult> SignInAsync(ApplicationUserLoginDTO user)
  {
    Console.WriteLine("SignInAsync Called!!");
    try
    {
      _logger.LogInformation($"Sign-in attempt for user: {user.UserName}");
      var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
      _logger.LogInformation($"Sign-in result for user {user.UserName}: {result.Succeeded}", user.UserName, result.Succeeded);
      return result;
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
    return new SignInResult();
  }
}
