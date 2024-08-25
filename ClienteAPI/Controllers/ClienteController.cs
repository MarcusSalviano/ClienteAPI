using AutoMapper;
using ClienteAPI.Data;
using ClienteAPI.Data.Dtos;
using ClienteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ClienteController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaCliente([FromBody] CreateClienteDto clienteDto)
    {
        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaClientePorId), new { id = cliente.Id }, cliente);
    }   

    [HttpGet]
    public IEnumerable<ReadClienteDto> RecuperarCliente([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.Include(c => c.Endereco).Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaClientePorId(int id)
    {
        var cliente = _context.Clientes.Include(c => c.Endereco).FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();
        var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
                
        return Ok(clienteDto);
    }
}
