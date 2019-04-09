using senai_wishlist_desafio_webapi.Domains;
using System.Collections.Generic;

namespace senai_wishlist_desafio_webapi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        List<Usuarios> ListarUsuarios();

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Recebe um objeto usuario</param>
        void CadastrarUsuario(Usuarios usuario);

        /// <summary>
        /// Edita um usuário existente
        /// </summary>
        /// <param name="usuario">Recebe um objeto usuario</param>
        void EditarUsuario(Usuarios usuario);

        /// <summary>
        /// Busca um usuário através de um email e senha
        /// </summary>
        /// <param name="email">Recebe um email</param>
        /// <param name="senha">Recebe uma senha</param>
        /// <returns>Retorna um usuário encontrado</returns>
        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
