using Microsoft.EntityFrameworkCore;

namespace apbd_test_retake.Models
{
    public class FireBrigadeDbContext : DbContext
    {
        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<FirefighterAction> FirefighterActions { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<FireTruckAction> FireTruckActions { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public FireBrigadeDbContext() { }
        public FireBrigadeDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Firefighter>(mb =>
            {
                mb.HasKey(f => f.IdFirefighter);
                mb.Property(f => f.IdFirefighter).UseIdentityColumn();
                mb.Property(f => f.FirstName).IsRequired().HasMaxLength(30);
                mb.Property(f => f.LastName).IsRequired().HasMaxLength(50);

                mb.ToTable("Firefighter");
            });

            modelBuilder.Entity<FirefighterAction>(mb =>
            {
                mb.HasKey(fa => new { fa.IdFirefighter, fa.IdAction });
                //mb.Property(fa => new { fa.IdFirefighter, fa.IdAction }).UseIdentityColumn();

                mb.HasOne(fa => fa.Firefighter)
                    .WithMany(f => f.FirefighterActions)
                    .HasForeignKey(fa => fa.IdFirefighter);

                mb.HasOne(fa => fa.Action)
                    .WithMany(a => a.FirefighterActions)
                    .HasForeignKey(fa => fa.IdAction);

                mb.ToTable("Firefighter_Action");
            });

            modelBuilder.Entity<Action>(mb =>
            {
                mb.HasKey(a => a.IdAction);
                mb.Property(a => a.IdAction).UseIdentityColumn();
                mb.Property(a => a.StartTime).IsRequired();
                mb.Property(a => a.NeedSpecialEquipment).IsRequired();

                mb.ToTable("Action");
            });

            modelBuilder.Entity<FireTruckAction>(mb =>
            {
                mb.HasKey(fa => fa.IdFireTruckAction);
                mb.Property(fa => fa.IdFireTruckAction).UseIdentityColumn();
                mb.Property(fa => fa.IdFireTruck).IsRequired();
                mb.Property(fa => fa.IdAction).IsRequired();
                mb.Property(fa => fa.AssigmentDate).IsRequired();

                mb.HasOne(fa => fa.Action)
                    .WithMany(a => a.FireTruckActions)
                    .HasForeignKey(fa => fa.IdAction);

                mb.HasOne(fa => fa.FireTruck)
                    .WithMany(f => f.FireTruckActions)
                    .HasForeignKey(fa => fa.IdFireTruck);

                mb.ToTable("FireTruck_Action");
            });

            modelBuilder.Entity<FireTruck>(mb =>
            {
                mb.HasKey(f => f.IdFireTruck);
                mb.Property(f => f.IdFireTruck).UseIdentityColumn();
                mb.Property(f => f.OperationalNumber).IsRequired().HasMaxLength(10);
                mb.Property(f => f.SpecialEquipment).IsRequired();

                mb.ToTable("FireTruck");
            });
        }
    }
}
