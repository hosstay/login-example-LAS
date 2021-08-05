# # https://hub.docker.com/_/microsoft-dotnet
# FROM mcr.microsoft.com/dotnet/sdk:5.0
# # AS build

# WORKDIR /source

# # copy csproj and restore as distinct layers
# COPY *.csproj ./login-example-SRA/
# # RUN ["dotnet", "restore"]

# # copy everything else and build app
# COPY . ./login-example-SRA/
# WORKDIR /source/login-example-SRA
# RUN ["dotnet", "build"]
# # RUN ["dotnet", "publish", "-c", "release", "-o", "/app", "--no-restore"]

# EXPOSE 5000

# RUN ["dotnet", "run"]

# # final stage/image
# # FROM mcr.microsoft.com/dotnet/aspnet:5.0
# # WORKDIR /app
# # COPY --from=build /app ./ 
# # ENTRYPOINT ["dotnet", "login-example-SRA.dll"] 

# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0
# AS build

COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 80
run chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

# RUN ["dotnet", "run"]

# final stage/image
# FROM mcr.microsoft.com/dotnet/aspnet:5.0
# WORKDIR /app
# COPY --from=build /app ./ 
# ENTRYPOINT ["dotnet", "login-example-SRA.dll"] 