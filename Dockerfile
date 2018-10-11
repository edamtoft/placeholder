FROM microsoft/dotnet:2.1-sdk as build
WORKDIR /build
COPY . .
RUN dotnet publish src/Placeholder -c Release -o /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime-bionic
RUN apt-get update && apt-get install -y libfontconfig1
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT [ "dotnet", "Placeholder.dll" ]