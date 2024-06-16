using mims.Models;
using Microsoft.AspNetCore.Identity;
using mims.DTOs;
using System.ComponentModel.DataAnnotations;
using mims.Authorization.Constants;
using mims.Services.Interfaces;
namespace mims.Services;

public class EFRegisterService : IRegisterService<ApplicationUserRegisterDTO>
{
  private UserManager<ApplicationUser> _userManager;
  private static readonly EmailAddressAttribute _emailAddressAttribute = new();

  public EFRegisterService(UserManager<ApplicationUser> userManager)
  {
    _userManager = userManager;
  }

  public Task<IdentityResult>
  RegisterAdmin(ApplicationUserRegisterDTO userDTO)
  {
    var user = new ApplicationUser()
    {
      UserName = userDTO.UserName,
      Email = userDTO.Email,
      PhoneNumber = userDTO.PhoneNumber
    };
    _userManager.CreateAsync(user, userDTO.Password);

    var claim = new System.Security.Claims.Claim(ApplicationClaims.Role,
                                                 ApplicationRoles.Admin);
    _userManager.AddClaimAsync(user, claim);
    Console.WriteLine("Added CLaims");
    return _userManager.CreateAsync(user, userDTO.Password);
  }
}
