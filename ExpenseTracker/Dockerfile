FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ExpenseTracker/ExpenseTracker.csproj", "ExpenseTracker/"]
RUN dotnet restore "ExpenseTracker/ExpenseTracker.csproj"

COPY . .
WORKDIR "/src/ExpenseTracker"
RUN dotnet build "ExpenseTracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExpenseTracker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpenseTracker.dll"]
