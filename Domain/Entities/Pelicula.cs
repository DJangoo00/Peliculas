namespace Domain.Entities;

public partial class Pelicula : BaseEntity
{
    public string Titulo { get; set; }
    public string Director { get; set; }
    public int Anio { get; set; }
    public string Genero { get; set; }
}
