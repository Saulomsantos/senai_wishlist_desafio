using senai_wishlist_desafio_webapi.Domains;
using senai_wishlist_desafio_webapi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace senai_wishlist_desafio_webapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishlistContext ctx = new WishlistContext();

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            Usuarios usuarioBuscado = ctx.Usuarios.ToList().Find(u => u.Email == email && u.Senha == senha);

            return usuarioBuscado;
        }

        public void CadastrarUsuario(Usuarios usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        public void EditarUsuario(Usuarios usuario)
        {
            Usuarios usuarioBuscado = ctx.Usuarios.Find(usuario.Id);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.TipoUsuarioId = usuario.TipoUsuarioId;

                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
