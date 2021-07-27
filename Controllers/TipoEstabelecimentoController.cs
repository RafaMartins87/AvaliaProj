using CadastrosGerais.Common;
using CadastrosGerais.Models;
using CadastrosGerais.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CadastrosGerais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsAllowAll")]
    public class TipoEstabelecimentoController : ControllerBase
    {
        private readonly ITipoEstabelecimentoRepository _tipoEstabelecimentoRepository;

        public TipoEstabelecimentoController(ITipoEstabelecimentoRepository TipoEstabelecimentoRepository)
        {
            _tipoEstabelecimentoRepository = TipoEstabelecimentoRepository;
        }

        /// <summary>
        /// Insere um objeto para cadastro.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPost("Cria")]
        public IActionResult TipoEstabelecimentoAdd(TipoEstabelecimentoModel dados)
        {
            try
            {
                return Ok(_tipoEstabelecimentoRepository.TipoEstabelecimentoAdd(dados));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("TipoEstabelecimentoAdd", "Erro ao buscar os TipoEstabelecimentos", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "TipoEstabelecimentoAdd", ex.Message));
            }
        }

        /// <summary>
        /// Get todos.
        /// </summary>
        /// <returns>Exibe todos os cadastros</returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        /// 
        [HttpGet("GetAll")]
        public IActionResult TipoEstabelecimentoGetAll()
        {
            try
            {
                return Ok(_tipoEstabelecimentoRepository.TipoEstabelecimentoGetAll());
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroGet", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroGet", ex.Message));
            }
        }

        /// <summary>
        /// Atualiza dados.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        /// 
        [HttpPost("Update")]
        public IActionResult TipoEstabelecimentoUpd(TipoEstabelecimentoModel dados)
        {
            try
            {
                return Ok(_tipoEstabelecimentoRepository.TipoEstabelecimentoUpd(dados));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroUpd", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroUpd", ex.Message));
            }
        }

        /// <summary>
        /// Deletar dados.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        /// 
        [HttpDelete("Deleta")]
        public IActionResult TipoEstabelecimentoDel(int id)
        {
            try
            {
                return Ok(_tipoEstabelecimentoRepository.TipoEstabelecimentoDel(id));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroDel", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroDel", ex.Message));
            }
        }
    }
}
