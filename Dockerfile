FROM mcr.microsoft.com/dotnet/runtime:8.0-alpine
WORKDIR /App

COPY ./release ./
ENTRYPOINT ["dotnet", "JunoBot.dll"]