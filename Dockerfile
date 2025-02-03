FROM mcr.microsoft.com/dotnet/aspnet:8.0.2-alpine3.18 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["/src/RealEstateListingAPI/RealEstateListing.Api.csproj", "RealEstateListingAPI/"]
COPY ["/src/RealEstateListing.Application/RealEstateListing.Application.csproj", "RealEstateListing.Application/"]
COPY ["/src/RealEstateListing.Domain/RealEstateListing.Domain.csproj", "RealEstateListing.Domain/"]
COPY ["/src/RealEstateListing.Infrastructure/RealEstateListing.Infrastructure.csproj", "RealEstateListing.Infrastructure/"]
RUN dotnet restore "RealEstateListingAPI/RealEstateListing.Api.csproj"
COPY ./src .
WORKDIR "/src/RealEstateListingAPI"
RUN dotnet build "RealEstateListing.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealEstateListing.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealEstateListing.Api.dll"]