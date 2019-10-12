FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Ametista.Blazor/Ametista.Blazor.csproj", "Ametista.Blazor/"]
COPY ["Ametista.Api.Model/Ametista.Api.Model.csproj", "Ametista.Api.Model/"]
RUN dotnet restore "Ametista.Blazor/Ametista.Blazor.csproj"
COPY . .
WORKDIR "/src/Ametista.Blazor"
RUN dotnet build "Ametista.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ametista.Blazor.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish .
COPY Ametista.Blazor/nginx.conf /etc/nginx/nginx.conf