Estrutura da Pirâmide de Testes para o Projeto HighScoreAPI
1. Testes Unitários (70% a 80% dos testes)

    HighScoreAPI.Domain:
        Testar entidades e validações de contrato.
        Testar lógica de negócios simples dentro das entidades.

    HighScoreAPI.Data:
        Testar repositórios (usando um banco de dados em memória).
        Testar contexto do banco de dados.

    HighScoreAPI.Application:
        Testar serviços.
        Testar regras de negócios complexas.

2. Testes de Integração (15% a 20% dos testes)

    HighScoreAPI.Data + HighScoreAPI.Application:
        Testar a integração entre repositórios e serviços.
        Testar transações e interações complexas com o banco de dados.

    HighScoreAPI.WEBAPI + HighScoreAPI.Application:
        Testar a integração entre controladores e serviços.
        Garantir que as respostas da API estão corretas e no formato esperado.

3. Testes de Interface/Funcionais/End-to-End (5% a 10% dos testes)

    HighScoreAPI.WEBAPI:
        Testar rotas da API.
        Testar fluxos completos de usuário, desde a requisição até a resposta.

Exemplo de Estrutura de Testes no Projeto
Testes Unitários

    HighscoreRepositoryTests.cs
    HighscoreServiceTests.cs
    HighscoreEntityTests.cs

Testes de Integração

    HighscoreRepositoryIntegrationTests.cs
    HighscoreServiceIntegrationTests.cs
    HighscoreControllerIntegrationTests.cs

Testes Funcionais

    HighscoreApiEndToEndTests.cs