using System.Text.Json;

namespace Contato.Leitura.Application.Dtos;

public class ContatoDto
{    
    public Guid Id { get; set; }       
    public string Nome { get; set; }    
    public string Telefone { get; set; }    
    public string Email { get; set; }
    public string Ddd { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}