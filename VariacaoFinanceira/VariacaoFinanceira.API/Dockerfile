#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VariacaoFinanceira.API/VariacaoFinanceira.API.csproj", "VariacaoFinanceira.API/"]
COPY ["VariacaoFinanceira.Application/VariacaoFinanceira.Application.csproj", "VariacaoFinanceira.Application/"]
COPY ["VariacaoFinanceira.Domain/VariacaoFinanceira.Domain.csproj", "VariacaoFinanceira.Domain/"]
COPY ["VariacaoFinanceira.Ioc/VariacaoFinanceira.Ioc.csproj", "VariacaoFinanceira.Ioc/"]
COPY ["VariacaoFinanceira.Infrastructure/VariacaoFinanceira.Infrastructure.csproj", "VariacaoFinanceira.Infrastructure/"]
RUN dotnet restore "./VariacaoFinanceira.API/./VariacaoFinanceira.API.csproj"
COPY . .
WORKDIR "/src/VariacaoFinanceira.API"
RUN dotnet build "./VariacaoFinanceira.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VariacaoFinanceira.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VariacaoFinanceira.API.dll"]