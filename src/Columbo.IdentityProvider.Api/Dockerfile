FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY . .
RUN dotnet restore Columbo.IdentityProvider.Api/Columbo.IdentityProvider.Api.csproj
WORKDIR /src/Columbo.IdentityProvider.Api
RUN dotnet build Columbo.IdentityProvider.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Columbo.IdentityProvider.Api.csproj -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Columbo.IdentityProvider.Api.dll"]
