namespace mims.DTOs;
public class ApplicationUserChangePasswordDTO
{
  public string OldPassword { get; set; } = null!;
  public string NewPassword { get; set; } = null!;
  public string ConfirmNewPassword { get; set; } = null!;
}
