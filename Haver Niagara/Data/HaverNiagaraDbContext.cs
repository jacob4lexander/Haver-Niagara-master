using Haver_Niagara.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Haver_Niagara.ViewModels;

namespace Haver_Niagara.Data
{
    public class HaverNiagaraDbContext : DbContext
    {
        //To give access to IHttpContextAccessor for Audit Data with IAuditable
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Property to hold the UserName value
        public string UserName
        {
            get; private set;
        }

        //Added from Step 10-Auditable.Txt
        public HaverNiagaraDbContext(DbContextOptions<HaverNiagaraDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            if (_httpContextAccessor.HttpContext != null)
            {
                UserName = _httpContextAccessor.HttpContext?.User.Identity.Name;
                UserName ??= "Unknown";
            }
            else
            {
                UserName = "Seed Data";
            }
        }
        public HaverNiagaraDbContext(DbContextOptions<HaverNiagaraDbContext> options)
            : base(options) 
        { 
        }

        public DbSet<CAR> CARs { get; set; }
        public DbSet<Defect> Defects { get; set; }
        public DbSet<Engineering> Engineerings { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<NCR> NCRs { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartName> PartNames { get; set; } //added

        public DbSet<SAPNumber> SAPNumbers { get; set; } //added
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<DefectList> DefectLists { get; set; } //Defect Lists junfction table
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<QualityInspection> QualityInspections { get; set; }
        public DbSet<Procurement> Procurements { get; set; }
        public DbSet<QualityInspectionFinal> QualityInspectionFinals { get; set; }//added for last section

        //Employee/Subscription
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operation>()
                .Property(n => n.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Part>()
                .Property(n => n.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Engineering>()
                .Property(n => n.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<QualityInspection>()
                .Property(n => n.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<DefectList>()
                .Property(n=>n.DefectListID) 
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Defect>()
                .Property(n=>n.ID) 
                .ValueGeneratedOnAdd();


            //Unique Constraint for Email Addresses
            modelBuilder.Entity<Employee>()
                .HasIndex(a => new { a.Email })
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Subscriptions)
                .WithOne(s => s.Employee)
                .OnDelete(DeleteBehavior.Cascade);

            ////Unique Constraint for Defect Name
            modelBuilder.Entity<Defect>()
                .HasIndex(a => new { a.Name })
                .IsUnique();

            //Unique Constraint for Supplier Name
            modelBuilder.Entity<Supplier>()
                .HasIndex(a => new { a.Name })
                .IsUnique();


        }

        //Added from Step10-Auditable.Txt
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = now;
                            trackable.CreatedBy = UserName;
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;
                    }
                }
            }
        }

    }
}
