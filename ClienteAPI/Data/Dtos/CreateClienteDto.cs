using ClienteAPI.Models;
using ClienteAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Data.Dtos;
public class CreateClienteDto
{
    [Required(ErrorMessage = "O nome do filme é obrigatório")]
    [MaxLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O sobreno é obrigatório")]
    [MaxLength(200, ErrorMessage = "O sobrenome não pode exceder 200 caracteres")]
    public string Sobrenome { get; set; }
    
    [Required(ErrorMessage = "O CPF é obrigatório")]
    [CpfValidation(ErrorMessage = "CPF inválido.")]
    public string CPF { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Telefone { get; set; }

    [Required]
    public CreateEnderecoDto Endereco { get; set; }
}
