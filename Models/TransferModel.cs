namespace desafio_picpay_simplificado.Models;

public class TransferModel
{
    public int IdTransfer { get; set; }
    public decimal Value { get; set; }
    public int Payer { get; set; }
    public int Payee { get; set; }
    public DateTime Date { get; set; }
}