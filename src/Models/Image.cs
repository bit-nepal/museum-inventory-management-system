using System.ComponentModel.DataAnnotations.Schema;
namespace mims.Models;
public class Image
{
  // format : [Column (string name, Properties:[Order = int],[TypeName = string])
  [Column("image_id")]
  public int Id { get; set; }

  [Column("image_no")]
  public string ImageNo { get; set; } = null!;

  [Column("image_url")]
  public string ImageUrl { get; set; } = null!;
}


