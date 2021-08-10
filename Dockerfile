# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0

COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 80

CMD ["dotnet", "watch", "run", "--project", "./login-example-SRA", "--server.urls", "http://*:80"]