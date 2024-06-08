using System.ComponentModel.DataAnnotations.Schema;
namespace mims.Models;
public class Artifact
{
  // format : [Column (string name, Properties:[Order = int],[TypeName = string])


  [Column("artifact_id")]
  public int Id { get; set; }

  [Column("name")]
  public string Name { get; set; } = null!;

  [Column("entry_no")]
  public string EntryNo { get; set; } = null!;

  [Column("description")]
  public string Description { get; set; } = null!;

  [Column("time_period")]
  public string? TimePeriod { get; set; }

  [Column("measurement")]
  public string? Measurement { get; set; }

  [Column("weight")]
  public string? Weight { get; set; }

  [Column("has_inscription")]
  public bool HasInscription { get; set; } = false;

  [Column("inscription")]
  public string? Inscription { get; set; }

  [Column("date_of_aquisition")]
  public DateOnly? DateOfAcquisition { get; set; }

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

  [Column("number_of_objects")]
  public string? Number { get; set; }

  [Column("name_of_artist")]
  public string? NameOfArtist { get; set; }

  [Column("estimated_value")]
  public int? EstimatedValue { get; set; }

  [Column("remarks")]
  public string? Remarks { get; set; }

  [Column("is_deleted")]
  public bool IsDeleted { get; set; } = false;

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; }

  [Column("mode_of_acquisition")]
  [AcquisitionModeValidation]
  public AcquisitionMode ModeOfAcquisition { get; set; }

  [Column("primary_photo")]
  public Image? PrimaryPhoto { get; set; }

  [Column("photos")]
  public ICollection<Image>? Photos { get; set; }
  // virtual for lazy loading
  //
  // public virtual Scheme? Scheme { get; set; }
  // public virtual ICollection<Feature>? Features { get; set; }
  // public virtual ICollection<TenantDatabase>? Databases { get; set; } = null!;
}
