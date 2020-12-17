FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
LABEL maintainer="elvia@elvia.no"
WORKDIR /app
COPY . .
RUN dotnet restore \
    GridTariffAPI/GridTariffApi.csproj \
    && dotnet publish \
    GridTariffAPI/GridTariffApi.csproj \
    --output ./out \
    --configuration Release
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS runtime
LABEL maintainer="elvia@elvia.no"

# Workaround
# Unhandled exception. System.NotSupportedException: Globalization Invariant Mode is not supported.
# https://github.com/dotnet/SqlClient/issues/220
RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

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
ENTRYPOINT ["dotnet", "GridTariffApi.dll"]
