using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence;

public partial class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
    }

    //DbSet para la funcionalidad
    public virtual DbSet<Pelicula> Peliculas {get; set;}
    //jwt
    public virtual DbSet<RefreshToken> Refreshtokens { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }

    //metodo para aplicar las configuracion de las entidades
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
