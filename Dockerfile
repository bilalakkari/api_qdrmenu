# Use the ASP.NET Core runtime image as the base image for deployment
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the DLLs and other necessary files from your local machine to the container
COPY bin/Debug/net6.0 .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "WebApplication2.dll"]