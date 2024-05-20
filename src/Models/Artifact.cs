using System.ComponentModel;
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
  public string? UsedMaterial { get; set; }
  [Column("period")]
  public string? Period { get; set; }
  [Column("inscription")]
  public string? Inscription { get; set; }
  //Make this own One to Many
  [Column("measurement")]
  public string? Measurement { get; set; }
  //TODO--------------
  [Column("weight")]
  public string? Weight { get; set; }
  [Column("date_of_aquisition")]
  public string? DateOfAquisition { get; set; }
  [Column("place_of_origin")]
  public string? PlaceOfOrigin { get; set; }
  [Column("name_of_donor")]
  public string? NameOfDonor { get; set; }
  [Column("place_of_receipt")]
  public string? PlaceOfReceipt { get; set; }
  [Column("location")]
  public string? Location { get; set; }
  [Column("physical_condition")]
  public string? PhysicalCondition { get; set; }
  [Column("number_of_object")]
  public string? Number { get; set; }
  [Column("name_of_artist")]
  public string? NameOfArtist { get; set; }
  [Column("estimated_value")]
  public string? EstimatedValue { get; set; }
  [Column("photo_no")]
  public string? PhotoNumber { get; set; }
  [Column("signature_of_receiver")]
  public string? SignatureOfReceiver { get; set; }
  [Column("remarks")]
  public string? remarks { get; set; }
  [Column("created_date")]
  public DateTime CreatedDate { get; set; }
  [Column("updated_date")]
  public DateTime UpdatedDate { get; set; }
  // virtual for lazy loading
  // public virtual Scheme? Scheme { get; set; }
  // public virtual ICollection<Feature>? Features { get; set; }
  // public virtual ICollection<TenantDatabase>? Databases { get; set; } = null!;
}
