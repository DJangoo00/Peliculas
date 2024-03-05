using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    //Main
    IPeliculaRepository Peliculas { get; }
    //JWT
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }

    Task<int> SaveAsync();
}
