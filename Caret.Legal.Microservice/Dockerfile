FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Caret.Legal.Microservice/Caret.Legal.Microservice.csproj", "Caret.Legal.Microservice/"]
RUN dotnet restore "Caret.Legal.Microservice/Caret.Legal.Microservice.csproj"
COPY . .
WORKDIR "/src/Caret.Legal.Microservice"
RUN dotnet build "Caret.Legal.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Caret.Legal.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Caret.Legal.Microservice.dll"]
