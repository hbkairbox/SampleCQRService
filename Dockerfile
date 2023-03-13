#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY "SampleCQRService/SampleCQRService.sln" "SampleCQRService/SampleCQRService.sln"
COPY "SampleCQRService.Infrastructure/SampleCQRService.Infrastructure.csproj" "SampleCQRService.Infrastructure/SampleCQRService.Infrastructure.csproj"
COPY "SampleCQRService/SampleCQRService.csproj" "SampleCQRService/SampleCQRService.csproj"

RUN dotnet restore "SampleCQRService/SampleCQRService.sln"

COPY . .
WORKDIR "/src/."
RUN dotnet build "SampleCQRService/SampleCQRService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SampleCQRService/SampleCQRService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SampleCQRService.dll"]