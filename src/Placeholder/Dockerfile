FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50071
EXPOSE 44337

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/Placeholder/Placeholder.csproj", "src/Placeholder/"]
RUN dotnet restore "src/Placeholder/Placeholder.csproj"
COPY . .
WORKDIR "/src/src/Placeholder"
RUN dotnet build "Placeholder.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Placeholder.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Placeholder.dll"]