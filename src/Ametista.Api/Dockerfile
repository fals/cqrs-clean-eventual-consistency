FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ametista.Api/Ametista.Api.csproj", "Ametista.Api/"]
COPY ["Ametista.Command/Ametista.Command.csproj", "Ametista.Command/"]
COPY ["Ametista.Core/Ametista.Core.csproj", "Ametista.Core/"]
COPY ["Ametista.Infrastructure/Ametista.Infrastructure.csproj", "Ametista.Infrastructure/"]
COPY ["Ametista.Query/Ametista.Query.csproj", "Ametista.Query/"]
RUN dotnet restore "Ametista.Api/Ametista.Api.csproj"
COPY . .
WORKDIR "/src/Ametista.Api"
RUN dotnet build "Ametista.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ametista.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ametista.Api.dll"]