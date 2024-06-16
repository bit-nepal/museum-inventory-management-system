namespace mims.Services.Interfaces;
public interface IPasswordService
{
  public Task<Microsoft.AspNetCore.Identity.IdentityResult>
  ChangePassword(string emailOrUserName, string oldPassword,
                 string newPassword);
}
