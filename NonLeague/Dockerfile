FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 65443
EXPOSE 44387

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY NonLeague/NonLeague.csproj NonLeague/
RUN dotnet restore NonLeague/NonLeague.csproj
COPY . .
WORKDIR /src/NonLeague
RUN dotnet build NonLeague.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NonLeague.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NonLeague.dll"]
