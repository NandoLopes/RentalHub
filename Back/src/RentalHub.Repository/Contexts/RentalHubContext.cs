using Microsoft.EntityFrameworkCore;
using RentalHub.Domain;

namespace RentalHub.Repository.Contexts;

public class RentalHubContext : DbContext
{
    public RentalHubContext(DbContextOptions<RentalHubContext> options)
        : base(options)
    {
    }

    public DbSet<Montadora> Montadoras { get; set; }
    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Locadora> Locadoras { get; set; }
    public DbSet<LogVeiculo> LogsVeiculos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Locadora>()
            .HasMany(L => L.Veiculos)
            .WithOne(V => V.Locadora)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Locadora>()
            .HasMany(L => L.Logs)
            .WithOne(V => V.Locadora)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Locadora>()
            .HasIndex(L => L.CNPJ)
            .IsUnique();

        modelBuilder.Entity<Montadora>()
            .HasMany(MON => MON.Modelos)
            .WithOne(MOD => MOD.Montadora)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Montadora>()
            .HasIndex(M => M.Nome)
            .IsUnique();

        modelBuilder.Entity<Modelo>()
            .HasMany(M => M.Veiculos)
            .WithOne(V => V.Modelo)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Veiculo>()
            .HasMany(V => V.Logs)
            .WithOne(L => L.Veiculo)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Veiculo>()
            .HasIndex(V => new { V.Placa, V.Chassi })
            .IsUnique();
    }
}
