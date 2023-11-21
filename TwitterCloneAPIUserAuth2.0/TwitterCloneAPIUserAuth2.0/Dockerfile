#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TwitterCloneAPIUserAuth2.0/TwitterCloneAPIUserAuth2.0.csproj", "TwitterCloneAPIUserAuth2.0/"]
RUN dotnet restore "TwitterCloneAPIUserAuth2.0/TwitterCloneAPIUserAuth2.0.csproj"
COPY . .
WORKDIR "/src/TwitterCloneAPIUserAuth2.0"
RUN dotnet build "TwitterCloneAPIUserAuth2.0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TwitterCloneAPIUserAuth2.0.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwitterCloneAPIUserAuth2.0.dll"]