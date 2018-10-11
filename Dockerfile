FROM microsoft/dotnet:2.1-sdk as build
WORKDIR /build
COPY . .
RUN dotnet publish src/Placeholder -c Release -o /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT [ "dotnet", "Placeholder.dll" ]