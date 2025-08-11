FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files FIRST (exact paths/casing per your ls)
COPY zelis.shared/zelis.shared.csproj zelis.shared/
COPY zelis.Api/Zelis.Api.csproj       zelis.Api/
RUN dotnet restore zelis.Api/Zelis.Api.csproj

# Copy the rest
COPY . .
RUN dotnet publish zelis.Api/Zelis.Api.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Zelis.Api.dll"]
