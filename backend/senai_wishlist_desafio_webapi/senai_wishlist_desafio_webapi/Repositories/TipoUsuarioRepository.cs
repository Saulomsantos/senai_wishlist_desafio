using senai_wishlist_desafio_webapi.Domains;
using senai_wishlist_desafio_webapi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_wishlist_desafio_webapi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Define o objeto ctx para chamar os métodos do context
        /// </summary>
        WishlistContext ctx = new WishlistContext();

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Recebe um objeto tipoUsuario</param>
        public void CadastarTipoUsuario(TiposUsuarios tipoUsuario)
        {
            // Adiciona tipo de usuário recebido e salva no banco
            ctx.TiposUsuarios.Add(tipoUsuario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Altera um tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Recebe um objeto tipoUsuario</param>
        public void EditarTipoUsuario(TiposUsuarios tipoUsuario)
        {
            // Define um objeto tipoUsuarioBuscado para atribuir ao tipo de usuário já existente
            // Procura um tipo de usuário pelo id passado no JSON
            TiposUsuarios tipoUsuarioBuscado = ctx.TiposUsuarios.Find(tipoUsuario.Id);

            // Caso algum tipo de usuário seja encontrado pelo id informado
            if (tipoUsuarioBuscado != null)
            {
                // Altera o título do tipo de usuário e salva no banco
                tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
                ctx.TiposUsuarios.Update(tipoUsuarioBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Retorna uma lista de tiposUsuarios</returns>
        public List<TiposUsuarios> ListarTiposUsuarios()
        {
            // Retorna a lista com os tipos de usuários
            return ctx.TiposUsuarios.ToList();
        }
    }
}
