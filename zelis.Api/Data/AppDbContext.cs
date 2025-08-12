// using Microsoft.EntityFrameworkCore;

// //using zelis.Shared.Dtos;
// using zelis.Api.Models;

// namespace zelis.Api.Data
// {
//     public class AppDbContext : DbContext
//     {
     
//         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//         {

//         }

        
 
//         public DbSet<Communication> Communication { get; set; }
//         public DbSet<CommunicationStatusHistory> CommunicationStatusHistory { get; set; }
//         public DbSet<CommunicationType> CommunicationType { get; set; }
//         public DbSet<CommunicationTypeStatus> CommunicationTypeStatus { get; set; }
//         //public DbSet<GlobalStatuses> GlobalStatuses { get; set; }

//     }
// }
using Microsoft.EntityFrameworkCore;
using zelis.Api.Models;

namespace zelis.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Communication> Communication { get; set; }
        public DbSet<CommunicationType> CommunicationType { get; set; }
        public DbSet<CommunicationTypeStatus> CommunicationTypeStatus { get; set; }
        public DbSet<CommunicationStatusHistory> CommunicationStatusHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table names (optional, keeps names predictable)
            modelBuilder.Entity<Communication>().ToTable("Communication");
            modelBuilder.Entity<CommunicationType>().ToTable("CommunicationType");
            modelBuilder.Entity<CommunicationTypeStatus>().ToTable("CommunicationTypeStatus");
            modelBuilder.Entity<CommunicationStatusHistory>().ToTable("CommunicationStatusHistory");

            // CommunicationType
            modelBuilder.Entity<CommunicationType>(e =>
            {
                e.HasKey(t => t.TypeCode);
                e.Property(t => t.TypeCode).HasMaxLength(64).IsRequired();
                e.Property(t => t.DisplayName).HasMaxLength(128).IsRequired();
                //e.Property(t => t.AllowedStatuses);
            });

            // CommunicationTypeStatus (composite PK)
            modelBuilder.Entity<CommunicationTypeStatus>(e =>
            {
                e.HasKey(s => new { s.TypeCode, s.StatusCode });
                e.Property(s => s.TypeCode).HasMaxLength(64).IsRequired();
                e.Property(s => s.StatusCode).HasMaxLength(64).IsRequired();
                e.Property(s => s.Description).HasMaxLength(256);

                e.HasOne<CommunicationType>()
                 .WithMany()
                 .HasForeignKey(s => s.TypeCode)
                 .HasPrincipalKey(t => t.TypeCode)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // Communication (FK by TypeCode)
            modelBuilder.Entity<Communication>(e =>
            {
                e.HasKey(c => c.Id);
                e.Property(c => c.Title).HasMaxLength(256);
                e.Property(c => c.TypeCode).HasMaxLength(64).IsRequired();

                e.HasOne<CommunicationType>()
                 .WithMany()
                 .HasForeignKey(c => c.TypeCode)
                 .HasPrincipalKey(t => t.TypeCode);
            });

            // CommunicationStatusHistory (FK to Communication)
            modelBuilder.Entity<CommunicationStatusHistory>(e =>
            {
                e.HasKey(h => h.Id);
                e.Property(h => h.StatusCode).HasMaxLength(64).IsRequired();

                e.HasOne(h => h.Communication)
                 .WithMany()
                 .HasForeignKey(h => h.CommunicationId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // _______Seed Data______

            modelBuilder.Entity<CommunicationType>().HasData(
                new CommunicationType { TypeCode = "email", DisplayName = "Email" },
                new CommunicationType { TypeCode = "sms", DisplayName = "SMS" }
            );

            modelBuilder.Entity<CommunicationTypeStatus>().HasData(
                new CommunicationTypeStatus { TypeCode = "email", StatusCode = "sent", Description = "Email Sent" },
                new CommunicationTypeStatus { TypeCode = "email", StatusCode = "failed", Description = "Email Failed" },
                new CommunicationTypeStatus { TypeCode = "sms", StatusCode = "delivered", Description = "SMS Delivered" },
                new CommunicationTypeStatus { TypeCode = "sms", StatusCode = "undelivered", Description = "SMS Undelivered" }
            );

              modelBuilder.Entity<Communication>().HasData(
        new Communication
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Title = "Welcome Email",
            TypeCode = "email"
        },
        new Communication
        {
            Id = Guid.Parse("11111111-1111-1211-1111-111111111111"),
            Title = "Promo SMS",
            TypeCode = "sms"
        }
    );
        }
    }
}

