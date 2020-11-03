FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
LABEL maintainer="elvia@elvia.no"
WORKDIR /app
COPY . .
RUN dotnet restore \
    Kunde.TariffApi.csproj \
    && dotnet publish \
    Kunde.TariffApi.csproj \
    --output ./out \
    --configuration Release
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime
LABEL maintainer="elvia@elvia.no"
ENV ASPNETCORE_URLS=http://*:8080
RUN addgroup application-group --gid 1001 \
    && adduser application-user --uid 1001 \
    --ingroup application-group \
    --disabled-password
WORKDIR /app
COPY --from=build /app/out .
RUN chown --recursive application-user .
USER application-user
EXPOSE 8080
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENTRYPOINT ["dotnet", "Kunde.TariffApi.dll"]
