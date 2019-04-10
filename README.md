# DreamWish
Projeto desafio de uma wishlist que compreende o sistema de uma lista de desejos

# Clonando o repositório GitHub
Execute o comando abaixo para clonar este repositório do GitHub para um diretório do seu computador:

git clone https://github.com/Saulomsantos/senai_wishlist_desafio.git

# Criando o banco de dados
Com os arquivos do repositório atualizados, abra o SQL Server Management Studio e em seguida os seguintes arquivos:


DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\bd\scripts\SENAI_WISHLIST_DESAFIO_CRIACAO_DDL_01.sql

DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\bd\scripts\SENAI_WISHLIST_DESAFIO_MANIPULACAO_DML_02.sql

DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\bd\scripts\SENAI_WISHLIST_DESAFIO_CONSULTA_DQL_03.sql


No script de criação (DDL_01), clique em executar. Assim, o banco de dados será criado com as tabelas necessárias.

No script de manipulação (DML_02), clique em executar. As tabelas serão alimentadas com alguns dados para que o sistema funcione minimamente.

No script de consulta (DQL_03), clique em executar. Dessa forma é possível visualizar se os dados foram inseridos corretamente.

# Importando a coleção JSON para o Postman
Abra o Postman e importe a coleção de requisições através do arquivo DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\postman collection\SENAI_WISHLIST_DESAFIO.postman_collection.json

Neste momento, deve constar a seguinte estrutura:

- USUARIOS
    - Usuarios.Listar
    - Usuarios.Cadastrar
    - Usuarios.Editar

- DESEJOS
    - Desejos.ListarTodos
    - Desejos.Cadastrar

- TIPOSUSUARIOS
    - TiposUsuarios.Listar
    - TiposUsuarios.Cadastrar
    - TiposUsuarios.Editar

- LOGIN
    - Login

# Executando a API
A API pode ser executada de duas formas.

Primeira:
Execute o cmd no caminho DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\backend\senai_wishlist_desafio_webapi\senai_wishlist_desafio_webapi

No cmd, digite dotnet run e aperte enter

Segunda:
Abra o arquivo DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\backend\senai_wishlist_desafio_webapi\senai_wishlist_desafio_webapi.sln no VisualStudio Community e clique em executar senai_wishlist_desafio_webapi

Com a API em execução, já é possível simular as requisições pelo Postman.

O que deve ser informado no corpo da requisição pode ser consultado na documentação pelo arquivo DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\documentacao\senai_wishlist_desafio_documentacao.pdf ou através da url https://localhost:5000/swagger

O usuário padrão para realizar o login já está inserido no corpo:

email : admin@admin.com
senha: admin12345

#OBS.: 

É de extrema importância alterar no arquivo WishlistContext.cs o Data Source utilizado na sua máquina, na linha de optionsBuilder.
Do contrário as requisições retornarão 400 - Bad Request.

# Executando a aplicação web
O primeiro passo a ser realizado é instalar as dependências da biblioteca React. 
Para isso, execute o cmd no caminho DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\frontend\senai_wishlist_desafio e digite npm install e apert enter.
Este comando irá criar o diretório node_modules e pode levar alguns minutos.

A aplicação web pode ser executada de duas formas.

Primeira:
Execute o cmd no caminho DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\frontend\senai_wishlist_desafio, digite npm start e aperte enter.

Segunda:
Abra o diretório DiretorioOndeORepositorioFoiClonado\senai_wishlist_desafio\frontend\senai_wishlist_desafio no VisualStudio Code, abra o console de comandos (um atalho é aperta ctrl + ') e digite npm start e aperte enter.

A página inicial contém algumas informações sobre o sitema.

Além desta, foram incluídas as páginas e Login (https://localhost:3000/api/Login) e Desejos (https://localhost:3000/api/Desejos).

Qualquer outra outra URL resultará em uma página não encontrada.
