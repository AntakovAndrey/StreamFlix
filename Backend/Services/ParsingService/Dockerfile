FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY "Domain/ParsingService.Domain.Core/*.csproj" "Domain/ParsingService.Domain.Core/"
COPY "Domain/ParsingService.Domain.Interfaces/*.csproj" "Domain/ParsingService.Domain.Interfaces/"

COPY "Application/ParsingService.Application.Interfaces/*.csproj" "Application/ParsingService.Application.Interfaces/"
COPY "Infrastructure/ParsingService.Infrastructure.Data/*.csproj" "Infrastructure/ParsingService.Infrastructure.Data/"
COPY "Infrastructure/ParsingService.Infrastructure.Parsers/*.csproj" "Infrastructure/ParsingService.Infrastructure.Parsers/"

COPY "ParsingService.API/*.csproj" "ParsingService.API/"
RUN dotnet restore "ParsingService.API/ParsingService.API.csproj"

COPY "Domain/ParsingService.Domain.Core/" "Domain/ParsingService.Domain.Core/"
COPY "Domain/ParsingService.Domain.Interfaces/" "Domain/ParsingService.Domain.Interfaces/"
COPY "Application/ParsingService.Application.Interfaces/*.csproj" "Application/ParsingService.Application.Interfaces/"
COPY "Infrastructure/ParsingService.Infrastructure.Data/" "Infrastructure/ParsingService.Infrastructure.Data/"
COPY "Infrastructure/ParsingService.Infrastructure.Parsers/" "Infrastructure/ParsingService.Infrastructure.Parsers/"
COPY "ParsingService.API/" "ParsingService.API/"
WORKDIR "/source/ParsingService.API"
RUN dotnet publish -o /app 

FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["./ParsingService.API"]