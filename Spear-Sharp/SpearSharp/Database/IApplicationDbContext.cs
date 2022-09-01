using System;
using Microsoft.EntityFrameworkCore;
using SpearSharp.Models;

namespace SpearSharp.Database
{
	public interface IApplicationDbContext
	{
         DbSet<Building> Buildings { get; set; }
         DbSet<Kingdom> Kingdoms { get; set; }
         DbSet<Player> Players { get; set; }
         DbSet<Troop> Troops { get; set; }
         DbSet<TroopTemplate> TroopsTemplate { get; set; }
         DbSet<BuildingTemplate> BuildingsTemplate { get; set; }

        IQueryable<T> Set<T>() where T : class;

        int SaveChanges();
    }
}

