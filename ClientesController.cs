using LHPets.Data;
using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    // GET /api/clientes
    [HttpGet]
    public ActionResult<List<Cliente>> Get() => Ok(DadosEmMemoria.Clientes);

    // POST /api/clientes
    [HttpPost]
    public ActionResult<Cliente> Post([FromBody] Cliente cliente)
    {
        if (DadosEmMemoria.Clientes.Any(c => c.Cpf == cliente.Cpf))
            return Conflict("Já existe um cliente com este CPF.");

        cliente.Id = DadosEmMemoria.Clientes.Count == 0
            ? 1
            : DadosEmMemoria.Clientes.Max(c => c.Id) + 1;

        DadosEmMemoria.Clientes.Add(cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }
}
