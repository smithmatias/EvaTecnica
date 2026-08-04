using EvaluacionDev.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionDev.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tarea> Tareas => Set<Tarea>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Tareas)
            .WithOne(t => t.Usuario)
            .HasForeignKey(t => t.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                Nombre = "Matias",
                Email = "matias@example.com",
                Activo = true,
                FechaAlta = DateTime.UtcNow
            },
            new Usuario
            {
                Id = 2,
                Nombre = "Lucia",
                Email = "lucia@example.com",
                Activo = true,
                FechaAlta = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<Tarea>().HasData(
            new Tarea
            {
                Id = 1,
                Titulo = "Preparar evaluacion tecnica",
                Descripcion = "Armar API base para CRUD",
                Completada = false,
                FechaCreacion = DateTime.UtcNow,
                FechaVencimiento = DateTime.UtcNow.AddDays(7),
                UsuarioId = 1
            },
            new Tarea
            {
                Id = 2,
                Titulo = "Revisar candidatos",
                Descripcion = "Validar ejercicio entregado",
                Completada = false,
                FechaCreacion = DateTime.UtcNow,
                FechaVencimiento = DateTime.UtcNow.AddDays(3),
                UsuarioId = 2
            }
        );
    }
}
