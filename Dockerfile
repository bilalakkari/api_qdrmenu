# Use the ASP.NET Core runtime image as the base image for deployment
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

COPY * csproj ./
RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "WebApplication2.dll"]