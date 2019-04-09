using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai_wishlist_desafio_webapi.Domains;
using senai_wishlist_desafio_webapi.Interfaces;
using senai_wishlist_desafio_webapi.Repositories;

namespace senai_wishlist_desafio_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository TipoUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Retorna uma lista de tiposUsuarios</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTiposUsuarios()
        {
            try
            {
                return Ok(TipoUsuarioRepository.ListarTiposUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarTipoUsuario(TiposUsuarios tipoUsuario)
        {
            try
            {
                TipoUsuarioRepository.CadastarTipoUsuario(tipoUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Altera um tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Recebe um objeto tipoUsuario</param>
        /// <returns>Retorna um status code</returns>
        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult EditarTipoUsuario(TiposUsuarios tipoUsuario)
        {
            try
            {
                TipoUsuarioRepository.EditarTipoUsuario(tipoUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}