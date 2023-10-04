# Use a base image with the .NET SDK for building and running tests
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory inside the container
WORKDIR /app

# Copy your test application code into the container
COPY . ./

# Restore dependencies and build the test application
RUN dotnet restore
RUN dotnet build