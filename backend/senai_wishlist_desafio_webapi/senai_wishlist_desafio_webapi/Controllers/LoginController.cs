using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_wishlist_desafio_webapi.Interfaces;
using senai_wishlist_desafio_webapi.Repositorios;
using senai_wishlist_desafio_webapi.ViewModels;

namespace senai_wishlist_desafio_webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                //busca usuario por email
                UsuarioDomain usuarioBuscado = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);
                //verifica se o usuario foi buscado 
                if (usuarioBuscado == null)
                {
                    return NotFound(new { mensagem = "Email ou Senha inválido." });
                }
                             
            //define os dados que serao fornecidos
            var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario),
                new Claim("Teste","Saulo, Guilherme, Lucas")
            };
            //chave de acesso do token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("wishlist-chave-autenticacao"));

            //credenciais do token - header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // gerar o token
            var token = new JwtSecurityToken(
                issuer: "wishlist.WebApi",
                audience: "wishlist.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );
            //Retorna Ok com o Token
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
            catch(SystemException ex) {
                return BadRequest(ex.Message);
              }
         }
    }
}