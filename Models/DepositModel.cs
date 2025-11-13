using System.ComponentModel.DataAnnotations;

namespace desafio_picpay_simplificado.Models;

public class DepositModel
{
    [Key]
    public int IdDeposit { get; set; }
    public int IdUser { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}