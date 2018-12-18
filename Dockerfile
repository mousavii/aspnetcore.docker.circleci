FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY adc.host/*.csproj ./adc.host/
COPY adc.utility/*.csproj ./adc.utility/
COPY adc.tests/*.csproj ./adc.tests/
COPY adc.integration.tests/*.csproj ./adc.integration.tests/
RUN dotnet restore

# copy and build everything else
COPY adc.host/. ./adc.host/
COPY adc.utility/. ./adc.utility/
COPY adc.tests/. ./adc.tests/
COPY adc.integration.tests/. ./adc.integration.tests/

RUN dotnet build

FROM build-env AS test
WORKDIR /app/adc.tests
RUN dotnet test

FROM test AS publish
WORKDIR /app/adc.host
RUN dotnet publish -o out

FROM microsoft/aspnetcore:2.0 AS runtime
WORKDIR /app
COPY --from=publish /app/adc.host/out ./
ENTRYPOINT ["dotnet", "adc.host.dll"]
