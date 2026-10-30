using LHPets.Models;

namespace LHPets.Data;

// Armazenamento em memória (sem banco de dados), compartilhado entre os controllers.
public static class DadosEmMemoria
{
    public static List<Cliente> Clientes { get; } = new();
    public static List<Pet> Pets { get; } = new();
}
