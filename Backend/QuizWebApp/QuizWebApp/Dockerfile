FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /src
COPY *.csproj .
COPY ../QuizWebAppTest/*.csproj ./QuizWebAppTest/
RUN dotnet restore
COPY . .
RUN dotnet publish QuizWebApp/QuizWebApp.csproj -c Release -o /publish
RUN dotnet publish QuizWebAppTest/QuizWebAppTest.csproj -c Release -o /publish
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "QuizWebApp.dll"]
