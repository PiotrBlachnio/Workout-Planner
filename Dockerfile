FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY WorkoutPlanner.csproj /build/

RUN dotnet restore ./build/WorkoutPlanner.csproj

COPY . ./build/

WORKDIR /build/

RUN dotnet publish ./WorkoutPlanner.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT [ "dotnet", "WorkoutPlanner.dll" ]