using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Contato.Leitura.Domain.Entities;

public class ContatoEntity
{
    public Guid Id { get; set; }
    public string Nome {get; set;}
    public string Telefone { get; set; }
    public string Email{get; set;}
    public string Ddd { get; set; }

}