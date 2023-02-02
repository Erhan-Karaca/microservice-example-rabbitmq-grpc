#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 9000
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Api/WebApi/OncuService.Api.WebApi/OncuService.Api.WebApi.csproj", "src/Api/WebApi/OncuService.Api.WebApi/"]
COPY ["src/Api/Core/OncuService.Api.Application/OncuService.Api.Application.csproj", "src/Api/Core/OncuService.Api.Application/"]
COPY ["src/Common/OncuService.Common/OncuService.Common.csproj", "src/Common/OncuService.Common/"]
RUN dotnet restore "src/Api/WebApi/OncuService.Api.WebApi/OncuService.Api.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Api/WebApi/OncuService.Api.WebApi"
RUN dotnet build "OncuService.Api.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OncuService.Api.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OncuService.Api.WebApi.dll"]