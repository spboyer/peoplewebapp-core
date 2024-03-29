FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["peoplewebapp-core.csproj", "./"]
RUN dotnet restore "./peoplewebapp-core.csproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "peoplewebapp-core.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "peoplewebapp-core.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "peoplewebapp-core.dll"]
