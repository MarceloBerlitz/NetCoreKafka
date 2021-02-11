#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["NetCoreKafka.Consumer/NetCoreKafka.Consumer.csproj", "NetCoreKafka.Consumer/"]
RUN dotnet restore "NetCoreKafka.Consumer/NetCoreKafka.Consumer.csproj"
COPY . .
WORKDIR "/src/NetCoreKafka.Consumer"
RUN dotnet build "NetCoreKafka.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreKafka.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreKafka.Consumer.dll"]