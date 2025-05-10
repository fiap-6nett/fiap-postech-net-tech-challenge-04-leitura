using Contato.Leitura.Domain.Entities;

namespace Contato.Leitura.Domain.Interfaces;

public interface IContatoRepository
{
    Task<List<ContatoEntity>> ObterTodos();    
}