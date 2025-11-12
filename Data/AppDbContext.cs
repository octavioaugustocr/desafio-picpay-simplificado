using desafio_picpay_simplificado.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<UserModel> User { get; set; }
    public DbSet<TransferModel> Transfer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>(entity => entity.Property(u => u.Balance)
            .HasColumnType("decimal(18,2)"));

        modelBuilder.Entity<TransferModel>(entity => entity.Property(t => t.Value)
            .HasColumnType("decimal(18,2)"));

        modelBuilder.Entity<UserModel>(entity => entity.HasKey(u => u.IdUser));
        modelBuilder.Entity<TransferModel>(entity => entity.HasKey(t => t.IdTransfer));
    }
}