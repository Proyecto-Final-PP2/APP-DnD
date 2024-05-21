# Stage 1: Build the .NET app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["API_DnD.csproj", "./"]
RUN dotnet restore "./API_DnD.csproj"
COPY . .
RUN dotnet build "API_DnD.csproj" -c Release -o /app/build

# Stage 2: Publish the .NET app
FROM build AS publish
RUN dotnet publish "API_DnD.csproj" -c Release -o /app/publish

# Stage 3: Create the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_DnD.dll"]
