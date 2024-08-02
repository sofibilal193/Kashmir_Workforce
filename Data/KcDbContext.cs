using Microsoft.EntityFrameworkCore;
using KC.API.Model;
using System.Text.Json;

namespace KC.API.Data
{
    public class KcDbContext : DbContext
    {
        public KcDbContext (DbContextOptions<KcDbContext> options)
            : base(options)
        {
        }

        public DbSet<KC.API.Model.Labour> Labours { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Labour entity
            modelBuilder.Entity<Labour>(entity =>
            {
                entity.ToTable("Labours");

                entity.HasKey(l => l.Id);

                entity.Property(l => l.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(l => l.Age)
                    .IsRequired();

                entity.Property(l => l.MobileNumber)
                    .HasMaxLength(15);

                entity.Property(l => l.Email)
                    .HasMaxLength(100);

                // Configure JSON conversion for Skills property
                entity.Property(l => l.Skills)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<Skill>>(v, (JsonSerializerOptions)null));

                // Configure other properties as needed
            });

            // Apply other entity configurations similarly
        }
    }
}
