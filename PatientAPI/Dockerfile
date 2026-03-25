# Step 1: Use Microsoft's .NET 9 base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Step 2: Use .NET 9 SDK to build your app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["PatientAPI.csproj", "./"]
RUN dotnet restore "PatientAPI.csproj"
COPY . .
RUN dotnet build "PatientAPI.csproj" -c Release -o /app/build

# Step 3: Publish the app
FROM build AS publish
RUN dotnet publish "PatientAPI.csproj" -c Release -o /app/publish

# Step 4: Final container
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientAPI.dll"]