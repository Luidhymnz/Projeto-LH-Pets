using System.ComponentModel.DataAnnotations;

namespace LHPets.Models;

public class Pet
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A espécie é obrigatória.")]
    public string Especie { get; set; } = string.Empty;

    public string Raca { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "ClienteId inválido.")]
    public int ClienteId { get; set; }
}
