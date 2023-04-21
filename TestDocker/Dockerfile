FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7105

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/app
COPY ["./", "TestDocker/"]
RUN dotnet restore "TestDocker/TestDocker.csproj"
RUN dotnet build "TestDocker/TestDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestDocker/TestDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDocker.dll"]