FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY . .
RUN dotnet restore Columbo.WebApp/Columbo.WebApp.csproj
WORKDIR /src/Columbo.WebApp
RUN dotnet build Columbo.WebApp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Columbo.WebApp.csproj -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Columbo.WebApp.dll"]
