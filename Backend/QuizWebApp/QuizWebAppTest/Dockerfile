FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
COPY . ./
COPY ../QuizWebApp/QuizWebApp.csproj ./QuizWebApp/
RUN dotnet restore
RUN dotnet build