using Microsoft.EntityFrameworkCore;

namespace senai_wishlist_desafio_webapi.Domains
{
    public partial class WishlistContext : DbContext
    {
        public WishlistContext()
        {
        }

        public WishlistContext(DbContextOptions<WishlistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desejos> Desejos { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // ATENÇÃO
                // ALTERAR O DATA SOURCE DE ACORDO COM O BANCO DE DADOS QUE ESTÁ INSTALADO NA SUA MÁQUINA
                // Apesar dos bancos de dados terem o mesmo nome (SENAI_WISHLIST_DESAFIO), o servidor pode ser diferente
                // No SENAI utilizamos SqlExpress (linha comentada)
                // Eu (Saulo) uso SqlDeveloper na minha máquina
                // Verifique qual servidor você instalou na sua e altere antes de rodar a API

                // optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=SENAI_WISHLIST_DESAFIO; user id=sa; pwd=132;");
                optionsBuilder.UseSqlServer("Data Source=.\\SqlDeveloper; Initial Catalog=SENAI_WISHLIST_DESAFIO; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desejos>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Desejos)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Desejos__Usuario__5165187F");
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__TiposUsu__7B406B565F27C5D0")
                    .IsUnique();

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D1053475E3092A")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Usuarios__7D8FE3B2709569CA")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__TipoUs__4E88ABD4");
            });
        }
    }
}
