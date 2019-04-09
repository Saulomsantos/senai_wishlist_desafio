using System;
using System.Collections.Generic;

namespace senai_wishlist_desafio_webapi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Desejos = new HashSet<Desejos>();
        }

        public int Id { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public TiposUsuarios TipoUsuario { get; set; }
        public ICollection<Desejos> Desejos { get; set; }
    }
}
