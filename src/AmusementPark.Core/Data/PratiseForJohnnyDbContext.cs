using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AmusementPark.Core.Domain;
using AmusementPark.Core.Setting.System;

namespace AmusementPark.Core.Data;

public class PratiseForJohnnyDbContext : DbContext, IUnitOfWork
{
    private readonly ConnectionString _connectionString;

    public PratiseForJohnnyDbContext(ConnectionString connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_connectionString.Value,new MySqlServerVersion(new Version(8,2,0)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        typeof(PratiseForJohnnyDbContext).GetTypeInfo().Assembly.GetTypes()
            .Where(t => typeof(IEntity).IsAssignableFrom(t) && t.IsClass).ToList()
            .ForEach(x =>
            {
                if (modelBuilder.Model.FindEntityType(x) == null)
                    modelBuilder.Model.AddEntityType(x);
            });
    }
    
    public bool ShouldSaveChanges { get; set; }
}