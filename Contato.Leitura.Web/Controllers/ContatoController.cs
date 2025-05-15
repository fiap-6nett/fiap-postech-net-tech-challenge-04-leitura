using AutoMapper;
using Contato.Leitura.Application.Dtos;
using Contato.Leitura.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Contato.Leitura.Web.Controllers;

/// <summary>
/// Controlador respons�vel por expor os endpoints de leitura de contatos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ContatoController(
    ILogger<ContatoController> logger,
    IContatoRepository contatoRepository,
    IMapper mapper) : ControllerBase
{
    private readonly ILogger<ContatoController> _logger = logger;
    private readonly IContatoRepository _contatoRepository = contatoRepository;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Obt�m todos os contatos cadastrados no banco de dados.
    /// </summary>
    /// <returns>Lista de contatos com status 200 ou erro interno com status 500.</returns>
    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<ContatoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterTodos()
    {
        try
        {
            _logger.LogInformation($"Acessou {nameof(ObterTodos)}.");
            var response = _mapper.Map<IEnumerable<ContatoDto>>(await _contatoRepository.ObterTodos());
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Falha na API Leitura de Contato. Erro: {ex}");
            return StatusCode(500, $"Internal server error - {ex}");
        }
    }

    /// <summary>
    /// Obt�m o contato por id cadastrado no banco de dados.
    /// </summary>
    /// <returns>Contato com status 200 ou erro interno com status 500.</returns>
    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<ContatoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        try
        {
            _logger.LogInformation($"Acessou {nameof(ObterPorId)}.");
            var response = _mapper.Map<ContatoDto>(await _contatoRepository.ObterPorId(id));
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Falha na API Leitura de Contato por ID. Erro: {ex}");
            return StatusCode(500, $"Internal server error - {ex}");
        }
    }


    /// <summary>
    /// Obt�m todos os contatos por DDD cadastrados no banco de dados.
    /// </summary>
    /// <returns>Lista de contatos com status 200 ou erro interno com status 500.</returns>
    [HttpGet("[action]")]
    [ProducesResponseType(typeof(List<ContatoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterPorDdd(string ddd)
    {
        try
        {
            _logger.LogInformation($"Acessou {nameof(ObterPorDdd)}.");
            var response = _mapper.Map<IEnumerable<ContatoDto>>(await _contatoRepository.ObterPorDdd(ddd));
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Falha na API Leitura de Contato por DDD. Erro: {ex}");
            return StatusCode(500, $"Internal server error - {ex}");
        }
    }
}
