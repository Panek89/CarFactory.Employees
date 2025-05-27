FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY *.sln ./
COPY */*.csproj ./

RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore

COPY . ./

RUN dotnet publish ./CarFactory.Employees.API/CarFactory.Employees.API.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/out .

EXPOSE ${API_PORT}

ENTRYPOINT ["dotnet", "CarFactory.Employees.API.dll"]
