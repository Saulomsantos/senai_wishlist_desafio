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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
                return Ok(UsuarioRepository.ListarUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.CadastrarUsuario(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(); ;
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult EditarUsuario(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.EditarUsuario(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


    }
}