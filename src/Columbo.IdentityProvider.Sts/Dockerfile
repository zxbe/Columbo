FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /etc/certifications/Columbo.IdentityProvider.Sts
COPY ./certifications/Columbo.IdentityProvider.Sts/ .
WORKDIR /src
COPY /src .
RUN dotnet restore Columbo.IdentityProvider.Sts/Columbo.IdentityProvider.Sts.csproj
WORKDIR /src/Columbo.IdentityProvider.Sts
RUN dotnet build Columbo.IdentityProvider.Sts.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Columbo.IdentityProvider.Sts.csproj -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /etc/Columbo.IdentityProvider.Sts/Certifications
COPY --from=publish /etc/Columbo.IdentityProvider.Sts/Certifications .
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Columbo.IdentityProvider.Sts.dll"]
