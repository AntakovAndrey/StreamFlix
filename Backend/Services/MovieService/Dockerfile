FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY "MovieService.API/*.csproj" "MovieService.API/"

RUN dotnet restore "MovieService.API/MovieService.API.csproj"

COPY "MovieService.API/" "MovieService.API/"

WORKDIR "/source/MovieService.API"
RUN dotnet publish -o /app 

FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=build /app .
ENTRYPOINT ["./MovieService.API"]
