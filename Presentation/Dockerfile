
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ../ArtCollab.sln ../
COPY ../Application/Application.csproj ../Application/
COPY ../Domain/Domain.csproj ../Domain/
COPY ../Infrastructure/Infrastructure.csproj ../Infrastructure/
COPY ../Presentation/Presentation.csproj ../Presentation/
COPY ../Infrastructure.Test/Infrastructure.Test.csproj ../Infrastructure.Test/
COPY ../Presentation.Test/Presentation.Test.csproj ../Presentation.Test/
COPY ../Domain.Test/Domain.Test.csproj ../Domain.Test/
COPY ../Shared/Shared.csproj ../Shared/
COPY . ../
WORKDIR "/src"
RUN dotnet build "../Presentation/Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "../Application/Application.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "../Domain/Domain.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "../Infrastructure/Infrastructure.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "../Infrastructure.Test/Infrastructure.Test.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "../Presentation.Test/Presentation.Test.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "../Domain.Test/Domain.Test.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet build "../Shared/Shared.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "../Presentation/Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "../Application/Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "../Domain/Domain.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "../Infrastructure/Infrastructure.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "../Infrastructure.Test/Infrastructure.Test.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "../Presentation.Test/Presentation.Test.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "../Domain.Test/Domain.Test.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN dotnet publish "../Shared/Shared.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ../
ENTRYPOINT ["dotnet", "../Presentation/Presentation.dll"]
ENTRYPOINT ["dotnet", "../Application/Application.dll"]
ENTRYPOINT ["dotnet", "../Domain/Domain.dll"]
ENTRYPOINT ["dotnet", "../Infrastructure/Infrastructure.dll"]
ENTRYPOINT ["dotnet", "../Infrastructure.Test/Infrastructure.Test.dll"]
ENTRYPOINT ["dotnet", "../Presentation.Test/Presentation.Test.dll"]
ENTRYPOINT ["dotnet", "../Domain.Test/Domain.Test.dll"]
ENTRYPOINT ["dotnet", "../Shared/Shared.dll"]


