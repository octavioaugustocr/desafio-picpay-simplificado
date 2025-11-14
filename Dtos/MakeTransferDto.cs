using System.ComponentModel.DataAnnotations;

namespace desafio_picpay_simplificado.Dtos;

public class MakeTransferDto
{
    [Required(ErrorMessage = "Informe o valor que deseja transferir")]
    [Range(0.01, int.MaxValue, ErrorMessage = "A quantia informada é inválida!")]
    public decimal Value { get; set; }
    
    [Required(ErrorMessage = "Informe o ID do pagador")]
    [Range(0, int.MaxValue, ErrorMessage = "O ID informado é inválido!")]
    public int Payer { get; set; }
    
    [Required(ErrorMessage = "Informe o ID do destinatário")]
    [Range(0, int.MaxValue, ErrorMessage = "O ID informado é inválido!")]
    public int Payee { get; set; }
}