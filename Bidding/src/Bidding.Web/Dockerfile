FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /src
COPY ["src/Bidding.Web/Bidding.Web.csproj", "src/Bidding.Web/"]
COPY ["src/Bidding.Application/Bidding.Application.csproj", "src/Bidding.Application/"]
COPY ["src/Bidding.Persistence.EfCore/Bidding.Persistence.EfCore.csproj", "src/Bidding.Persistence.EfCore/"]
COPY ["src/Bidding.Domain/Bidding.Domain.csproj", "src/Bidding.Domain/"]
RUN dotnet restore "src/Bidding.Web/Bidding.Web.csproj"
RUN dotnet restore "Bidding/Bidding.csproj"
COPY . . 
WORKDIR "/src/Bidding.Web"
RUN dotnet build "Bidding.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Bidding.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bidding.Web.dll"]
