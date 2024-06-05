using Microsoft.EntityFrameworkCore;
using mims.Models;

namespace mims.Data;
public class ArtifactContext : DbContext
{
  public ArtifactContext(DbContextOptions options) : base(options) { }

  public DbSet<Artifact> Artifacts { get; set; } = null!;


  public override int SaveChanges()
  {
    PopulateCreatedAtAndUpdatedAtTimestamps();
    return base.SaveChanges();
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    PopulateCreatedAtAndUpdatedAtTimestamps();
    return await base.SaveChangesAsync(cancellationToken);
  }

  private void PopulateCreatedAtAndUpdatedAtTimestamps()
  {
    var now = DateTime.UtcNow;
    TimeZoneInfo NepaliStandartTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time");
    var NowInNepal = TimeZoneInfo.ConvertTimeFromUtc(now, NepaliStandartTimeZoneInfo);

    foreach (var changedEntity in ChangeTracker.Entries())
    {
      if (changedEntity.Entity is Artifact entity)
      {
        switch (changedEntity.State)
        {
          case EntityState.Added:
            entity.CreatedAt = NowInNepal;
            entity.UpdatedAt = NowInNepal;
            break;
          case EntityState.Modified:
            Entry(entity).Property(x => x.CreatedAt).IsModified = false;
            entity.UpdatedAt = NowInNepal;
            break;
        }
      }
    }
  }
}
