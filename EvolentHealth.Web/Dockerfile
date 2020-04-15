#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EvolentHealth.Web/EvolentHealth.Web.csproj", "EvolentHealth.Web/"]
RUN dotnet restore "EvolentHealth.Web/EvolentHealth.Web.csproj"
COPY . .
WORKDIR "/src/EvolentHealth.Web"
RUN dotnet build "EvolentHealth.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EvolentHealth.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvolentHealth.Web.dll"]