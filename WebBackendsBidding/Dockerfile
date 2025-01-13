FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebBackendsBidding/WebBackendsBidding.csproj", "WebBackendsBidding/"] 
RUN dotnet restore "WebBackendsBidding/WebBackendsBidding.csproj"
COPY . .
WORKDIR "/src/WebBackendsBidding"
RUN dotnet build "WebBackendsBidding.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebBackendsBidding.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebBackendsBidding.dll"]
