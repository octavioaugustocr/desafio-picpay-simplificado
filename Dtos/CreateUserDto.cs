using System.ComponentModel.DataAnnotations;
using desafio_picpay_simplificado.Enums;

namespace desafio_picpay_simplificado.Dtos;

public class CreateUserDto
{
    [Required(ErrorMessage = "Informe um nome")]
    public string FullName { get; set; }
    
    [Required(ErrorMessage = "Informe o CPF ou CNPJ")]
    public string CpfCnpj { get; set; }
    
    [Required(ErrorMessage = "Informe um e-mail")]
    [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Informe uma senha")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Informe um tipo de usuário")]
    public TypeUserEnum TypeUser { get; set; }
}