using AutoMapper;
using Contato.Leitura.Domain.Entities;
using Contato.Leitura.Application.Dtos;

namespace Contato.Leitura.Web.Configuration.Mappings
{
    /// <summary>
    /// Define o perfil de mapeamento entre a entidade ContatoEntity e o DTO ContatoDto.
    /// </summary>
    public class ContatoMappingProfile : Profile
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ContatoMappingProfile"/>.
        /// Define os mapeamentos entre os modelos de domínio e os DTOs.
        /// </summary>
        public ContatoMappingProfile()
        {
            CreateMap<ContatoEntity, ContatoDto>();
        }
    }
}