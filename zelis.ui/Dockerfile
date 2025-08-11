FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files FIRST (exact paths/casing)
COPY zelis.shared/zelis.shared.csproj zelis.shared/
COPY zelis.ui/Zelis.UI.csproj         zelis.ui/
RUN dotnet restore zelis.ui/Zelis.UI.csproj

# Copy the rest of the source
COPY . .
RUN dotnet publish zelis.ui/Zelis.UI.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Zelis.UI.dll"]
