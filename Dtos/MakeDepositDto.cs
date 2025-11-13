using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace desafio_picpay_simplificado.Dtos;

public class MakeDepositDto
{
    [Required(ErrorMessage = "Informe o ID do usuário")]
    public int IdUser { get; set; }
    
    [Required(ErrorMessage = "Informe a quantia que deseja depositar")]
    [Range(0.01, int.MaxValue, ErrorMessage = "A quantia informada é inválida!")]
    [Precision(18,2)]
    public decimal Amount { get; set; }
}