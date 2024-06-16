using mims.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using mims.Services.Interfaces;

namespace mims.Services;

public class EFPasswordService : IPasswordService
{
  private UserManager<ApplicationUser> _userManager;
  private static readonly EmailAddressAttribute _emailAddressAttribute = new();

  public EFPasswordService(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  public async Task<IdentityResult> ChangePassword(string emailOrUserName,
                                                   string oldPassword,
                                                   string newPassword)
  {
    var user = await GetUserFromEmailOrUserName(emailOrUserName);
    return await _userManager.ChangePasswordAsync(user, oldPassword,
                                                  newPassword);
  }

  private async Task<ApplicationUser>
  GetUserFromEmailOrUserName(string emailOrUserName)
  {
    if (string.IsNullOrEmpty(emailOrUserName))
      throw new ValidationException("Email or Username Required !!");

    if (_emailAddressAttribute.IsValid(emailOrUserName))
    {
      return await _userManager.FindByEmailAsync(emailOrUserName);
    }
    else
    {
      return await _userManager.FindByNameAsync(emailOrUserName);
    }
  }
}
