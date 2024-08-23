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

// public enum AcquisitionMode
// {
//   Buying = 1,
//   Built = 2,
//   Credit = 3,
//   Exchange = 4,
//   Rent = 5,
//   Replica = 6,
//   Gift = 7,
//   Donation = 8,
//   [Display(Name = "Legal Security")] LegalSecurity = 9,
//   Others = 10
// }
public enum AcquisitionMode
{
  Buying = 0,
  Built = 1,
  Credit = 2,
  Exchange = 3,
  Rent = 4,
  Replica = 5,
  Gift = 6,
  Donation = 7,
  [Display(Name = "Legal Security")] LegalSecurity = 8,
  Others = 9
}
