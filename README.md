# RentalHub

Projeto feito em pouco tempo disponível devido a período de provas e entregas de trabalho na faculdade, portanto está incompleto. Essa é a relação de implementações e lista de itens a serem implementados:

## Implementado:

- Endpoint Create/Update (HttpPost) mesmo endpoint e mesmo parâmetro, validando pela existencia ou não do Id, de Montadora, Modelo, Veiculo, e Locadora;
- Endpoint GetAll (HttpGet) de Montadora, Modelo, Veiculo, Locadora, e LogVeiculo;
- Endpoint GetByFilter (HttpPost)  de Montadora, Modelo, Veiculo, Locadora, e LogVeiculo;
- Configuração de AutoMapper e Entity Framework, utilizando sistema Code First (criação de tabelas com Migrations);
- Verificação de criação ou alteração de Locadora de um Veiculo para criar o LogVeiculo;
- Sistema de "IsActive" para evitar exclusão de dados;
- Filtragem simples de itens ativos e de busca por campos;
- Separação em 4 camadas (API, Application, Domain, e Repository);
- Criação de DTOs;
- Separação de códigos genéricos em classes implementáveis (RentalHubService, RentalHubRepository, BaseEntity, BasePostDto);
- Abstração e Dependency Inversion utilizando interfaces.

## Futuras implementações:

- Endpoints de "Delete" (setar registro como inativo);
- Configuração de login com Identity;
- Aprimorar endpoints de requisição, com filtros e retornos mais específicos ao invés de filtros e retornos generalizados;
- Aprimorar e abstrair filtros das queries;
- Criação do front end.
