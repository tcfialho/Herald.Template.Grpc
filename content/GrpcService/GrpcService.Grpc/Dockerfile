#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GrpcService.Grpc/GrpcService.Grpc.csproj", "GrpcService.Grpc/"]
COPY ["GrpcService.Application/GrpcService.Application.csproj", "GrpcService.Application/"]
COPY ["GrpcService.Infrastructure/GrpcService.Infrastructure.csproj", "GrpcService.Infrastructure/"]
RUN dotnet restore "GrpcService.Grpc/GrpcService.Grpc.csproj"
COPY . .
WORKDIR "/src/GrpcService.Grpc"
RUN dotnet build "GrpcService.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcService.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcService.Grpc.dll"]
