#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Projections/OncuService.Projections.MailService/OncuService.Projections.MailService.csproj", "src/Projections/OncuService.Projections.MailService/"]
COPY ["src/Common/OncuService.Common/OncuService.Common.csproj", "src/Common/OncuService.Common/"]
RUN dotnet restore "src/Projections/OncuService.Projections.MailService/OncuService.Projections.MailService.csproj"
COPY . .
WORKDIR "/src/src/Projections/OncuService.Projections.MailService"
RUN dotnet build "OncuService.Projections.MailService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OncuService.Projections.MailService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OncuService.Projections.MailService.dll"]