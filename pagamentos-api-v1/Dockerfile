#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["sapq-pucapi-v1/sapq-pucapi-v1.csproj", "sapq-pucapi-v1/"]
RUN dotnet restore "sapq-pucapi-v1/sapq-pucapi-v1.csproj"
COPY . .
WORKDIR "/src/sapq-pucapi-v1"
RUN dotnet build "sapq-pucapi-v1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sapq-pucapi-v1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sapq-pucapi-v1.dll"]