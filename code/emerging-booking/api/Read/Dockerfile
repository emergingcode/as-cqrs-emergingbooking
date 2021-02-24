FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["EmergingBooking/EmergingBooking.csproj", "EmergingBooking/"]
RUN dotnet restore "EmergingBooking/EmergingBooking.csproj"
COPY . .
WORKDIR "/src/EmergingBooking"
RUN dotnet build "EmergingBooking.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EmergingBooking.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmergingBooking.dll"]