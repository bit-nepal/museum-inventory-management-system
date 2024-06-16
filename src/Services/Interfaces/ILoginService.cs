namespace mims.Services.Interfaces;
public interface ILoginService<TLogin>
{
  public Task<Microsoft.AspNetCore.Identity.SignInResult>
  SignInAsync(TLogin user);
}
