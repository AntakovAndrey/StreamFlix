FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY "Domain/ParsingService.Domain.Core/*.csproj" "Domain/ParsingService.Domain.Core/"
COPY "Application/ParsingService.Application.Interfaces/*.csproj" "Application/ParsingService.Application.Interfaces/"
COPY "Infrastructure/ParsingService.Infrastructure.Parsers/*.csproj" "Infrastructure/ParsingService.Infrastructure.Parsers/"
COPY "Infrastructure/ParsingService.Infrastructure.RabbitMQ/*.csproj" "Infrastructure/ParsingService.Infrastructure.RabbitMQ/"
COPY "ParsingService.API/*.csproj" "ParsingService.API/"
RUN dotnet restore "ParsingService.API/ParsingService.API.csproj"

COPY "Domain/ParsingService.Domain.Core/" "Domain/ParsingService.Domain.Core/"
COPY "Application/ParsingService.Application.Interfaces/" "Application/ParsingService.Application.Interfaces/"
COPY "Infrastructure/ParsingService.Infrastructure.Parsers/" "Infrastructure/ParsingService.Infrastructure.Parsers/"
COPY "Infrastructure/ParsingService.Infrastructure.RabbitMQ/" "Infrastructure/ParsingService.Infrastructure.RabbitMQ/"
COPY "ParsingService.API/" "ParsingService.API/"
WORKDIR "/source/ParsingService.API"
RUN dotnet publish -o /app 

FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["./ParsingService.API"]