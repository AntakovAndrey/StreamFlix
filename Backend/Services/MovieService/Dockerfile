FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY "Domain/MovieService.Domain.Core/*.csproj" "Domain/MovieService.Domain.Core/"
COPY "Domain/MovieService.Domain.Interfaces/*.csproj" "Domain/MovieService.Domain.Interfaces/"

COPY "Application/MovieService.Application.Interfaces/*.csproj" "Application/MovieService.Application.Interfaces/"

COPY "Infrastructure/MovieService.Infrastructure.Data/*.csproj" "Domain/MovieService.Infrastructure.Core/"
COPY "Infrastructure/MovieService.Infrastructure.RabbitMQ/*.csproj" "Infrastructure/MovieService.Infrastructure.RabbitMQ/"

COPY "MovieService.API/*.csproj" "MovieService.API/"

RUN dotnet restore "MovieService.API/MovieService.API.csproj"

COPY "Domain/MovieService.Domain.Core/" "Domain/MovieService.Domain.Core/"
COPY "Domain/MovieService.Domain.Interfaces/" "Domain/MovieService.Domain.Interfaces/"

COPY "Application/MovieService.Application.Interfaces/" "Application/MovieService.Application.Interfaces/"

COPY "Infrastructure/MovieService.Infrastructure.Data/" "Infrastructure/MovieService.Infrastructure.Data/"
COPY "Infrastructure/MovieService.Infrastructure.RabbitMQ/" "Infrastructure/MovieService.Infrastructure.RabbitMQ/"

COPY "MovieService.API/" "MovieService.API/"

WORKDIR "/source/MovieService.API"
RUN dotnet publish -o /app 

FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["./MovieService.API"]