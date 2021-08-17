# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0

# for manually running migrations/etc.
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef

COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 80

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh