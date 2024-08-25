using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteAPI.Models;

public class Endereco
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Rua { get; set; }

    [Required]
    [StringLength(10)]
    public string Numero { get; set; }

    [StringLength(100)]
    public string Complemento { get; set; }

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

    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; }
}
