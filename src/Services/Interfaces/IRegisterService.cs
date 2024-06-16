using Microsoft.AspNetCore.Identity;

namespace mims.Services.Interfaces;
public interface IRegisterService<TRegister>
{
  public Task<IdentityResult> RegisterAdmin(TRegister user);
}
