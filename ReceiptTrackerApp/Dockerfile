FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReceiptTrackerApp/ReceiptTrackerApp.csproj", "ReceiptTrackerApp/"]
RUN dotnet restore "ReceiptTrackerApp/ReceiptTrackerApp.csproj"
COPY . .
WORKDIR "/src/ReceiptTrackerApp"
RUN dotnet build "ReceiptTrackerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReceiptTrackerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReceiptTrackerApp.dll"]
