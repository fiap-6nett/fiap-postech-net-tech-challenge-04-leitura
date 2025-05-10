using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Contato.Leitura.Domain.Entities;

public class ContatoEntity
{
    public Guid Id { get; private set; }
    public string Nome {get; private set;}
    public string Telefone { get; private set; }
    public string Email{get; private set;}
    public string Ddd { get; private set; }

}