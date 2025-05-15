using Contato.Leitura.Domain.Entities;

namespace Contato.Leitura.Domain.Interfaces;

public interface IContatoRepository
{
    Task<List<ContatoEntity>> ObterTodos();
    Task<ContatoEntity> ObterPorId(Guid id);
    Task<List<ContatoEntity>> ObterPorDdd(string ddd);
}