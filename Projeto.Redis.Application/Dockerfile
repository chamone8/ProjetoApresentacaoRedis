#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Projeto.Redis.Application/Projeto.Redis.Application.csproj", "Projeto.Redis.Application/"]
RUN dotnet restore "Projeto.Redis.Application/Projeto.Redis.Application.csproj"
COPY . .
WORKDIR "/src/Projeto.Redis.Application"
RUN dotnet build "Projeto.Redis.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Projeto.Redis.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Projeto.Redis.Application.dll"]

