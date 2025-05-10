using Contato.Leitura.Domain.Entities;
using Contato.Leitura.Domain.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Contato.Leitura.Infra.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly IMongoCollection<ContatoEntity> _contatos;

    public ContatoRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> mongoDbSettings)
    {
        var database = mongoClient.GetDatabase(mongoDbSettings.Value.Database);
        _contatos = database.GetCollection<ContatoEntity>("Contatos"); 
    }
    
    public virtual async Task<List<ContatoEntity>> ObterTodos()
    {
        return await _contatos.Find(_ => true).ToListAsync();
    }
}