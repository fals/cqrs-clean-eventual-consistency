FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Ametista.Api/Ametista.Api.csproj", "Ametista.Api/"]
COPY ["Ametista.Command/Ametista.Command.csproj", "Ametista.Command/"]
COPY ["Ametista.Core/Ametista.Core.csproj", "Ametista.Core/"]
COPY ["Ametista.Infrastructure/Ametista.Infrastructure.csproj", "Ametista.Infrastructure/"]
COPY ["Ametista.Query/Ametista.Query.csproj", "Ametista.Query/"]
RUN dotnet restore "Ametista.Api/Ametista.Api.csproj"
COPY . .
WORKDIR "/src/Ametista.Api"
RUN dotnet build "Ametista.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ametista.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ametista.Api.dll"]