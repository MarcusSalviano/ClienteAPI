using ClienteAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Data.Dtos;

public class ReadEnderecoDto
{
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string CEP { get; set; }
}
