using System.ComponentModel.DataAnnotations.Schema;
namespace mims.Models;
public class Artifact
{
  // format : [Column (string name, Properties:[Order = int],[TypeName = string])

  [Column("artifact_id")]
  public int Id { get; set; }

  [Column("name")]
  public string Name { get; set; } = null!;


  // virtual for lazy loading
  // public virtual Scheme? Scheme { get; set; }
  // public virtual ICollection<Feature>? Features { get; set; }
  // public virtual ICollection<TenantDatabase>? Databases { get; set; } = null!;
}
