# Login Example SRA

An implementation of a website with login using ASP.NET MVC, React, and SQL Server built in docker (In Progress)

## Getting Started

### Prerequisites

* Have docker and docker-compose installed

## Deployment

* run 'docker-compose up'

Webpage runs at localhost:8080

## Logging into the database manually

through container:
```
    For some reason sqlcmd through the container doesn't allow me to copy and paste and also requires you type 'go' at the end after the ';'
```
* get container id for db by finding it via 'sudo docker ps'
* log into db with "sudo docker exec -ti login-example-sra_db_1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Docker1!'"

or via mssql on host machine:
```
    mssql will allow me to copy and paste, but requires a '\' at the end of each line. doesn't require a 'go' after the semicolon.
```
* install mssql with npm
* do a 'sudo docker ps' and look at ports to see what ports login-example-sra_db_1 is running on
* get container ip address via sudo docker exec login-example-sra_db_1 cat /etc/hosts (probably bottom line)
* run mssql -s \<container-ip-address> -o \<container-port> -u SA -p 'Docker1!'

via GUI (in my case SQL Server (mssql) for VS Code):
```
    This option is the one I use as it allows copy and pasting and doesn't require '\'s or 'go's 
```
* install extension
* add connection with details collected from the above options (first prompt is just ip address)
* right click the database and choose 'New Query'
* write your query.
* right click in the query file and choose 'Execute Query'

## Built With

* [ASP.NET MVC](https://dotnet.microsoft.com/apps/aspnet/mvc) - Web Framework
* [Docker](https://www.docker.com/) - Containerization

## Authors

* **Taylor Hoss** - [hosstay](https://github.com/hosstay)
