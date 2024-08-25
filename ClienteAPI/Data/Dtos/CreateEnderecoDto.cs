using ClienteAPI.Models;
using ClienteAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Data.Dtos;
public class CreateEnderecoDto
{
    [Required]
    [StringLength(200)]
    public string Rua { get; set; }

    [StringLength(10)]
    public string? Numero { get; set; }

    [StringLength(100)]
    public string? Complemento { get; set; }

    [Required]
    [StringLength(100)]
    public string Bairro { get; set; }

    [Required]
    [StringLength(100)]
    public string Cidade { get; set; }

    [Required]
    [StringLength(2)]
    public string Estado { get; set; }

    [Required]
    [StringLength(10)]
    [CepValidation(ErrorMessage = "CEP inválido.")]
    public string CEP { get; set; }   
}
