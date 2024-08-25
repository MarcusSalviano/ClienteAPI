using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Data.Dtos;

public class ReadClienteDto
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
