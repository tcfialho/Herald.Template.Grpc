#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GrpcApi.Grpc/GrpcApi.Grpc.csproj", "GrpcApi.Grpc/"]
COPY ["GrpcApi.Application/GrpcApi.Application.csproj", "GrpcApi.Application/"]
COPY ["GrpcApi.Infrastructure/GrpcApi.Infrastructure.csproj", "GrpcApi.Infrastructure/"]
RUN dotnet restore "GrpcApi.Grpc/GrpcApi.Grpc.csproj"
COPY . .
WORKDIR "/src/GrpcApi.Grpc"
RUN dotnet build "GrpcApi.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcApi.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcApi.Grpc.dll"]
