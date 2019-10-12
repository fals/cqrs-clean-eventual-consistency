FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY Ametista.Blazor .
RUN dotnet restore "Ametista.Blazor"
COPY . .
RUN dotnet build "Ametista.Blazor" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ametista.Blazor" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/Ametista_Blazor/dist .
COPY nginx.conf /etc/nginx/nginx.conf