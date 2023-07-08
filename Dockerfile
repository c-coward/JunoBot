FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /App

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out
ENTRYPOINT [ "dotnet", "out/JunoBot.dll" ]