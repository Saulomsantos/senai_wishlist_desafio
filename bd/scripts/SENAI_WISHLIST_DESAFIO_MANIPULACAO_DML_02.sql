-- DEFINE O BANCO DE DADOS SENAI_WISHLIST_DESAFIO SERÁ UTILIZADO
USE SENAI_WISHLIST_DESAFIO;

-- INSERE NA COLUNA TiposUsuarios DOIS VALORES, ADMINISTRADOR E COMUM
INSERT INTO TiposUsuarios (Titulo)
VALUES					  ('ADMINISTRADOR')
						 ,('COMUM');

-- INSERE NA COLUNA Usuarios TRÊS USUÁRIOS: ADMIN, FERNANDO E HELENA
INSERT INTO Usuarios (TipoUsuarioId, Nome, Email, Senha)
VALUES				 (1, 'admin', 'admin@admin.com', 'admin12345')
					,(2, 'Fernando', 'fernando@email.com', '12345')
					,(2, 'Helena', 'helena@email.com', '12345');

-- INSERE NA COLUNA Desejos QUATRO DESEJOS: A, B, C E D
INSERT INTO Desejos (Descricao, UsuarioId)
VALUES			    ('Desejo A', 2)
				   ,('Desejo B', 2)
				   ,('Desejo C', 3)
				   ,('Desejo D', 3);