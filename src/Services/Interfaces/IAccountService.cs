using mims.DTOs;

namespace mims.Services.Interfaces;
public interface IAccountService
{
  public Task<Microsoft.AspNetCore.Identity.IdentityResult>
  ChangePassword(ApplicationUserChangePasswordDTO user);

  public Task<Microsoft.AspNetCore.Identity.IdentityResult>
  ChangeUsername(ApplicationUserChangeUsernameDTO user);

  public Task<string>
  GetUsername();
}
