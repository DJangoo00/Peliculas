using Domain.Entities;

namespace Domain.Interfaces;
public interface IPeliculaRepository : IGenericRepository<Pelicula>
{
    Task<Pelicula> UpdateAsync (int id, Pelicula entity);
}