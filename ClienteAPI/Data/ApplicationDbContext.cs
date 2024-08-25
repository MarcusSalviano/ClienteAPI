using ClienteAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    // Construtor que recebe opções para configurar o DbContext
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets para cada modelo
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    // Configuração do modelo usando Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configura o relacionamento 1:1 entre Cliente e Endereco
        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Endereco)
            .WithOne(e => e.Cliente)
            .HasForeignKey<Endereco>(e => e.ClienteId)
            .OnDelete(DeleteBehavior.Restrict)
            ;

        base.OnModelCreating(modelBuilder);
    }
}
