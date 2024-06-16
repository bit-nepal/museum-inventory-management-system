using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mims.Authorization.Constants;
using mims.Models;

namespace mims.Data;
public class ArtifactContext : IdentityDbContext<ApplicationUser>
{
  public ArtifactContext(DbContextOptions<ArtifactContext> options) : base(options) { }

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

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder); // This is crucial for Identity configuration


    // Define the role
    var adminRole = new IdentityRole
    {
      Id = Guid.NewGuid().ToString(),
      Name = ApplicationRoles.Admin,
      NormalizedName = ApplicationRoles.Admin.ToUpper()
    };

    var adminUser = new ApplicationUser()
    {
      Id = Guid.NewGuid().ToString(),
      UserName = "admin",
      NormalizedUserName = "ADMIN",
      Email = "admin@jyapusamaj.com",
      NormalizedEmail = "ADMIN@JYAPUSAMAJ.COM",
      EmailConfirmed = true,
    };

    PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
    adminUser.PasswordHash = ph.HashPassword(adminUser, "supersecretpassword");


    builder.Entity<IdentityRole>().HasData(adminRole);

    builder.Entity<ApplicationUser>().HasData(adminUser);

    // Seed the user-role relationship
    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
    {
      RoleId = adminRole.Id,
      UserId = adminUser.Id
    });

    // Optionally, you can seed the claim for the role
    builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
    {
      Id = 1,
      ClaimType = ApplicationClaims.Role,
      ClaimValue = ApplicationRoles.Admin,
      UserId = adminUser.Id
    });

  }
}
