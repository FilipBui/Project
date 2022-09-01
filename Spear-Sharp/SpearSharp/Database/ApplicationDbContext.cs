using Microsoft.EntityFrameworkCore;
using SpearSharp.Models;
using SpearSharp.Models.BuildingModels;

namespace SpearSharp.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Kingdom> Kingdoms { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Troop> Troops { get; set; }
        public DbSet<TroopTemplate> TroopsTemplate { get; set; }
        public DbSet<BuildingTemplate> BuildingsTemplate { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasOne(p => p.Kingdom).WithOne(k => k.Ruler).HasForeignKey<Kingdom>(k => k.RulerId);
            modelBuilder.Entity<Player>().Property(p => p.Username).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Password).HasColumnType("varchar(100)").IsRequired();
            
            modelBuilder.Entity<Building>()
             .HasDiscriminator<string>("building_type")
             .HasValue<Barracks>("Barracks")
             .HasValue<Farm>("Farm")
             .HasValue<Townhall>("Townhall");

            modelBuilder.Entity<Building>().HasData(new Building { Id = 1, Type = "Fortification", Level = 1, HP = 2000, KingdomId = 1 });
            modelBuilder.Entity<Building>().HasData(new Building { Id = 2, Type = "Townhall", Level = 1, HP = 200, KingdomId = 1 });
            modelBuilder.Entity<Building>().HasData(new Building { Id = 1, Type = "Barracks", Level = 1, HP = 50, KingdomId = 1 });

            modelBuilder.Entity<BuildingTemplate>().HasData(new BuildingTemplate { Id = 1, Type = "Townhall", BuildingTime = 3, HP = 200, Cost = 200 });
            modelBuilder.Entity<BuildingTemplate>().HasData(new BuildingTemplate { Id = 2, Type = "Mine", BuildingTime = 1, HP = 100, Cost = 100, Generation = 5 });
            modelBuilder.Entity<BuildingTemplate>().HasData(new BuildingTemplate { Id = 3, Type = "Farm", BuildingTime = 1, HP = 100, Cost = 100, Generation = 5 });
            modelBuilder.Entity<BuildingTemplate>().HasData(new BuildingTemplate { Id = 4, Type = "Barracks", BuildingTime = 2, HP = 100, Cost = 100 });

            modelBuilder.Entity<TroopTemplate>().HasData(new TroopTemplate { Id = 1, TroopType = "Footman", TrainingTime = 1, HP = 20, Cost = 25, Armor = 5, Damage = 5, Upkeep = 5 });
            modelBuilder.Entity<TroopTemplate>().HasData(new TroopTemplate { Id = 2, TroopType = "KnightCavalry", TrainingTime = 4, HP = 35, Cost = 50, Armor = 15, Damage = 15, Upkeep = 15 });
            modelBuilder.Entity<TroopTemplate>().HasData(new TroopTemplate { Id = 3, TroopType = "Senator", TrainingTime = 2, HP = 40, Cost = 50, Armor = 10, Damage = 10, Upkeep = 10 });
            modelBuilder.Entity<TroopTemplate>().HasData(new TroopTemplate { Id = 4, TroopType = "Spearman", TrainingTime = 2, HP = 20, Cost = 40, Armor = 5, Damage = 15, Upkeep = 8 });
            modelBuilder.Entity<TroopTemplate>().HasData(new TroopTemplate { Id = 5, TroopType = "Spy", TrainingTime = 5, HP = 10, Cost = 100, Armor = 5, Damage = 5, Upkeep = 5 });
        }

        IQueryable<T> IApplicationDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}