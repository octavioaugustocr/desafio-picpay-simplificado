using desafio_picpay_simplificado.Enums;

namespace desafio_picpay_simplificado.Models;

public class UserModel
{
    public int IdUser { get; set; }
    public string FullName { get; set; }
    public string CpfCnpj { get; set; }
    public decimal Balance { get; set; } = 0;
    public string Email { get; set; }
    public string Password { get; set; }
    public TypeUserEnum TypeUser { get; set; }
}