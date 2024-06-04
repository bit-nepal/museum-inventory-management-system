using System.ComponentModel.DataAnnotations;
namespace mims.Models;

// public class AcquisitionMode
// {
//   public const string Buying = nameof(Buying);
//   public const string Built = nameof(Built);
//   public const string Credit = nameof(Credit);
//   public const string Exchange = nameof(Exchange);
//   public const string Rent = nameof(Rent);
//   public const string Replica = nameof(Replica);
//   public const string Gift = nameof(Gift);
//   public const string Donation = nameof(Donation);
//   public const string LegalSecurity = "Legal Security";
//
//   public IEnumerable<string> GetAllAcquisitionModes()
//   {
//     return new List<string> {
//       Buying,
//       Built,
//       Credit,
//       Exchange,
//       Rent,
//       Replica,
//       Gift,
//       Donation,
//       LegalSecurity
//     };
//   }
// }
//

public enum AcquisitionMode
{
  Buying,
  Built,
  Credit,
  Exchange,
  Rent,
  Replica,
  Gift,
  Donation,
  [Display(Name = "Legal Security")] LegalSecurity
}
