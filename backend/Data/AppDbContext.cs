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

    private static readonly DateTime FechaBase = new DateTime(2026, 1, 15, 9, 0, 0, DateTimeKind.Utc);

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
                FechaAlta = FechaBase
            },
            new Usuario
            {
                Id = 2,
                Nombre = "Lucia",
                Email = "lucia@example.com",
                Activo = true,
                FechaAlta = FechaBase
            }
        );

        modelBuilder.Entity<Tarea>().HasData(
            new Tarea
            {
                Id = 1,
                Titulo = "Preparar evaluacion tecnica",
                Descripcion = "Armar API base para CRUD",
                Completada = false,
                FechaCreacion = FechaBase,
                FechaVencimiento = FechaBase.AddDays(7),
                UsuarioId = 1
            },
            new Tarea
            {
                Id = 2,
                Titulo = "Revisar candidatos",
                Descripcion = "Validar ejercicio entregado",
                Completada = false,
                FechaCreacion = FechaBase,
                FechaVencimiento = FechaBase.AddDays(3),
                UsuarioId = 2
            },
            new Tarea
            {
                Id = 3,
                Titulo = "Documentar endpoints",
                Descripcion = "Escribir el README de la API",
                Completada = true,
                FechaCreacion = FechaBase,
                FechaVencimiento = FechaBase.AddDays(1),
                UsuarioId = 1
            },
            new Tarea
            {
                Id = 4,
                Titulo = "Migrar base de datos",
                Descripcion = null,
                Completada = false,
                FechaCreacion = FechaBase,
                FechaVencimiento = null,
                UsuarioId = 2
            },
            new Tarea
            {
                Id = 5,
                Titulo = "Revisar accesos",
                Descripcion = "",
                Completada = true,
                FechaCreacion = FechaBase,
                FechaVencimiento = FechaBase.AddDays(10),
                UsuarioId = 1
            },
            new Tarea
            {
                Id = 6,
                Titulo = "Actualizar dependencias",
                Descripcion = "Subir paquetes a la ultima version",
                Completada = true,
                FechaCreacion = FechaBase,
                FechaVencimiento = FechaBase.AddDays(15),
                UsuarioId = 2
            }
        );
    }
}
