using System.ComponentModel.DataAnnotations;

namespace desafio_picpay_simplificado.Dtos;

public class UpdateUserDto
{
    [Required(ErrorMessage = "Informe o nome")]
    public string FullName { get; set; }
    [Required(ErrorMessage = "Informe a senha")]
    public string Password { get; set; }
}