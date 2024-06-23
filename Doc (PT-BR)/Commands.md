# Comandos utulizados

```

dotnet ef migrations add NAME --project HighScoreAPI.Data --Startup-project HighScoreAPI.WEBAPI

dotnet ef database update


adição de referencias :

dotnet add reference ../HighScoreAPI.Application/HighScoreAPI.Application.csproj
dotnet add reference ../HighScoreAPI.Data/HighScoreAPI.Data.csproj
dotnet add reference ../HighScoreAPI.Domain/HighScoreAPI.Domain.csproj
dotnet add reference ../HighScoreAPI.WEBAPI/HighScoreAPI.WEBAPI.csproj



tech usadas :

ef core tools , design , sql server , in memory
xunit , moq 
