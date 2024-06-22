using mims.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using mims.Services.Interfaces;
using mims.DTOs;

namespace mims.Services;

public class EFAccountService : IAccountService
{
  private UserManager<ApplicationUser> _userManager;
  private static readonly EmailAddressAttribute _emailAddressAttribute = new();
  private readonly IHttpContextAccessor _httpContextAccessor;

  public EFAccountService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
  {
    _userManager = userManager;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<IdentityResult> ChangePassword(ApplicationUserChangePasswordDTO u)
  {
    var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext!.User);
    var user = await _userManager.FindByIdAsync(userId!);

    if (u.OldPassword is null || u.NewPassword is null)
    {
      return IdentityResult.Failed(new IdentityError { Description = "Password cannot be empty!" });
    }
    if (!u.NewPassword.Equals(u.ConfirmNewPassword))
    {
      return IdentityResult.Failed(new IdentityError { Description = "New Password And Confirmation Password doesnt match !" });
    }

    if (user is null)
    {
      return IdentityResult.Failed(new IdentityError { Description = "User not found !" });
    }

    var passwordCheck = await _userManager.CheckPasswordAsync(user, u.OldPassword);
    if (!passwordCheck)
    {
      return IdentityResult.Failed(new IdentityError { Description = "Incorrect Password !" });
    }


    return await _userManager.ChangePasswordAsync(user, u.OldPassword, u.NewPassword);
  }


  public async Task<IdentityResult> ChangeUsername(ApplicationUserChangeUsernameDTO u)
  {
    var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext!.User);
    var user = await _userManager.FindByIdAsync(userId!);
    if (user is null)
    {
      return IdentityResult.Failed(new IdentityError { Description = "User Not Found !" });
    }
    if (u.Password is null)
    {
      return IdentityResult.Failed(new IdentityError { Description = "Password cannot be empty!" });
    }

    if (await _userManager.CheckPasswordAsync(user, u.Password) == false)
    {
      return IdentityResult.Failed(new IdentityError { Description = "Incorrect Password !" });
    }

    user.UserName = u.NewUserName;
    user.NormalizedEmail = _userManager.NormalizeEmail(u.NewUserName);

    return await _userManager.UpdateAsync(user);
  }
  public async Task<string> GetUserName()
  {
    var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext!.User);
    var user = await _userManager.FindByIdAsync(userId!);
    return user.UserName;
  }
}
