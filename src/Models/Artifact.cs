using System.ComponentModel.DataAnnotations.Schema;
namespace mims.Models;
public class Artifact
{
  // format : [Column (string name, Properties:[Order = int],[TypeName = string])
  [Column("artifact_id")]
  public int Id { get; set; }
  [Column("name")]
  public string Name { get; set; } = null!;
  [Column("description")]
  public string Description { get; set; } = null!;
  [Column("used_matriel")]
  public string UsedMaterial { get; set; } = null!;
  [Column("period")]
  public string Period { get; set; } = null!;
  [Column("inscription")]
  public string Inscription { get; set; } = null!;
  //Make this own One to Many
  [Column("measurement")]
  public string Measurement { get; set; } = null!;
  //TODO--------------
  [Column("weight")]
  public string Weight { get; set; } = null!;
  [Column("date_of_aquisition")]
  public string DateOfAquisition { get; set; } = null!;
  [Column("place_of_origin")]
  public string PlaceOfOrigin { get; set; } = null!;
  [Column("name_of_donor")]
  public string NameOfDonor { get; set; } = null!;
  [Column("place_of_receipt")]
  public string PlaceOfReceipt { get; set; } = null!;
  [Column("location")]
  public string Location { get; set; } = null!;
  [Column("physical_condition")]
  public string PhysicalCondition { get; set; } = null!;
  [Column("number_of_object")]
  public string Number { get; set; } = null!;
  [Column("name_of_artist")]
  public string NameOfArtist { get; set; } = null!;
  [Column("estimated_value")]
  public string EstimatedValue { get; set; } = null!;
  [Column("photo_no")]
  public string PhotoNumber { get; set; } = null!;
  [Column("signature_of_receiver")]
  public string SignatureOfReceiver { get; set; } = null!;
  [Column("remarks")]
  public string remarks { get; set; } = null!;

  // virtual for lazy loading
  // public virtual Scheme? Scheme { get; set; }
  // public virtual ICollection<Feature>? Features { get; set; }
  // public virtual ICollection<TenantDatabase>? Databases { get; set; } = null!;
}
