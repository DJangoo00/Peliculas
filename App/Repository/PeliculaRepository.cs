using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository;

public class PeliculaRepository : GenericRepository<Pelicula>, IPeliculaRepository
{
    private readonly ApiContext _context;
    public PeliculaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Pelicula>> GetAllAsync()
    {
        return await _context.Peliculas
            .ToListAsync();
    }

    public override async Task<Pelicula> GetByIdAsync(int id)
    {
        return await _context.Peliculas
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}