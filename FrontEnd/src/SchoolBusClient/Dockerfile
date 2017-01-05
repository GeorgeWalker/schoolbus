FROM tran-schoolbus-tools/client
# Dockerfile for package SchoolBusClient
 
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# This is required so that dotnet does not crash
ENV LTTNG_UST_REGISTER_TIMEOUT 0

COPY . /app
WORKDIR /app


RUN dotnet restore

ENV ASPNETCORE_ENVIRONMENT Staging
ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/app.dll"]
