## Site para venda de lanches 


==>SOBRE O PROJETO:
  Projeto ASP.NET Core MVC v: 2.0, um site para venda de lanches. Um projeto que tem por objetivo melhorar minhas habilidades com os recursos do MVC criando uma           aplicação simples.


==>ARQUITETURA DO PROJETO:
  Para este projeto foi usada a arquitetura MONOLÍTICA (UI Layer ===> MVC ), onde na camada de apresentação de uma raquitetura em três camadas( UI Layer --> Business       Logic Layer --> Data Access Layer), usamos somente a camada de apresentação e nela usamos o Padrão MVC. Na aplicação definimos Modelo de dados no MODEL, o negócio       parcialmente no CONTROLLER, NA VIEW a interface com usúario.


==>MODELO DE DOMINIO:
  -Classes que representão o negócio
  -Lanche (Nome, preço, descrição curta, descrição longa, imagem, imagem miniatura, CATEGORIA, é preferido, esta disponível)
  -Categoria (Nome e descrição)

==>ENTITY FRAMEWORK CORE 2.0: Para mapeiar as classes para as tabelas na abordagem Code-First(Gerar o banco e popular as tabelas a partir das classes)

==>PADRAO REPOSITORY: Serve para remover o acoplamento entre CONTROLLER ==> EF Core

                    ==> Incluindo uma camada entre o CONTROLLER==>(REPOSITORY)==>EF Core==>BD
                    
                    ==> Padrão repository é um padrão estrutural que separa a lógica de domínio da lógica de acesso aos dados
                        usado para desacoplar o modelo de domínio do código de acesso a dados.
                        
                    ==>Sua implementação e feita por meio de INTERFACES.
==>CONTROLLER E VIEWS:
                  
