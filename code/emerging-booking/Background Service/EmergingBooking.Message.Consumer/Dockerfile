FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Background Service/EmergingBooking.Message.Consumer/EmergingBooking.Message.Consumer.csproj", "Background Service/EmergingBooking.Message.Consumer/"]
RUN dotnet restore "Background Service/EmergingBooking.Message.Consumer/EmergingBooking.Message.Consumer.csproj"
COPY . .
WORKDIR "/src/Background Service/EmergingBooking.Message.Consumer"
RUN dotnet build "EmergingBooking.Message.Consumer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EmergingBooking.Message.Consumer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmergingBooking.Message.Consumer.dll"]