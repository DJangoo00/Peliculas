using Domain.Entities;

namespace API.Dtos;

public partial class PeliculaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Director { get; set; }
    public int Anio { get; set; }
    public string Genero { get; set; }
}
