﻿
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY *.sln ./
COPY AppointmentSystem.API/*.csproj ./AppointmentSystem.API/
COPY AppointmentSystem.Application/*.csproj ./AppointmentSystem.Application/
COPY AppointmentSystem.Domain/*.csproj ./AppointmentSystem.Domain/
COPY AppointmentSystem.Infrastructure/*.csproj ./AppointmentSystem.Infrastructure/
COPY AppointmentSystem.Tests/*.csproj ./AppointmentSystem.Tests/

RUN dotnet restore


COPY . ./


WORKDIR /app/AppointmentSystem.API
RUN dotnet publish -c Release -o /app/out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "AppointmentSystem.API.dll"]
