using App.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;
    
    //main
    private PeliculaRepository _peliculas;
    //JWT
    private RoleRepository _roles;
    private UserRepository _users;
    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }

    //main

    public IPeliculaRepository Peliculas
    {
        get
        {
            if (_peliculas == null)
            {
                _peliculas = new PeliculaRepository(_context);
            }
            return _peliculas;
        }
    }

    //jwt
    public IRoleRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RoleRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    } 
}