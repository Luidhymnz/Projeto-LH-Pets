using LHPets.Data;
using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/pets")]
public class PetsController : ControllerBase
{
    // GET /api/pets
    [HttpGet]
    public ActionResult<List<Pet>> Get() => Ok(DadosEmMemoria.Pets);

    // POST /api/pets
    [HttpPost]
    public ActionResult<Pet> Post([FromBody] Pet pet)
    {
        if (!DadosEmMemoria.Clientes.Any(c => c.Id == pet.ClienteId))
            return NotFound($"Cliente {pet.ClienteId} não encontrado.");

        pet.Id = DadosEmMemoria.Pets.Count == 0
            ? 1
            : DadosEmMemoria.Pets.Max(p => p.Id) + 1;

        DadosEmMemoria.Pets.Add(pet);
        return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
    }

    // GET /api/pets/cliente/{clienteId}
    [HttpGet("cliente/{clienteId}")]
    public ActionResult<List<Pet>> GetPorCliente(int clienteId)
    {
        if (!DadosEmMemoria.Clientes.Any(c => c.Id == clienteId))
            return NotFound($"Cliente {clienteId} não encontrado.");

        var pets = DadosEmMemoria.Pets.Where(p => p.ClienteId == clienteId).ToList();
        return Ok(pets);
    }
}
