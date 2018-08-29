FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Ametista.Sync/Ametista.Sync.csproj", "Ametista.Sync/"]
COPY ["Ametista.Command/Ametista.Command.csproj", "Ametista.Command/"]
COPY ["Ametista.Core/Ametista.Core.csproj", "Ametista.Core/"]
COPY ["Ametista.Infrastructure/Ametista.Infrastructure.csproj", "Ametista.Infrastructure/"]
COPY ["Ametista.Query/Ametista.Query.csproj", "Ametista.Query/"]
RUN dotnet restore "Ametista.Sync/Ametista.Sync.csproj"
COPY . .
WORKDIR "/src/Ametista.Sync"
RUN dotnet build "Ametista.Sync.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ametista.Sync.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ametista.Sync.dll"]