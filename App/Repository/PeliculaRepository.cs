using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using System.Reflection;
using System.Collections.Generic;
using iText.Layout.Properties;

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
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pelicula> UpdateAsync(int id, Pelicula entity)
    {
        Pelicula existingPelicula = await GetByIdAsync(id);

        PropertyInfo[] properties = entity.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity);
            if (value != null)
            {
                property.SetValue(existingPelicula, value);
            }
        }

        /* if (entity.Titulo != null)
        {
            existingPelicula.Titulo = entity.Titulo;
        }
        if (entity.Director != null)
        {
            existingPelicula.Director = entity.Director;
        }
        if (entity.Anio != 0)
        {
            existingPelicula.Anio = entity.Anio;
        }
        if (entity.Genero != null)
        {
            existingPelicula.Genero = entity.Genero;
        } */

        return existingPelicula;
    }
}