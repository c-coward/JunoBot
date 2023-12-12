FROM mcr.microsoft.com/dotnet/sdk:8.0.100-1-alpine3.18-amd64
WORKDIR /App

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out
ENTRYPOINT [ "dotnet", "out/JunoBot.dll" ]