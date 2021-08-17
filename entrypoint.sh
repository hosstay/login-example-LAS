#!/bin/bash

set -e
run_cmd="dotnet watch run --project ./login-example-SRA --server.urls http://*:80"

until dotnet ef database update --project ./login-example-SRA; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - adding migrations"
# generate random name for the migration since I can't find a way to run migrations without a unique name (unlike django)
RANDOM_MIGRATION_NAME=$(tr -dc A-Za-z0-9 </dev/urandom | head -c 20 ; echo '')

dotnet ef migrations add $RANDOM_MIGRATION_NAME --project ./login-example-SRA

>&2 echo "Added migration under name '$RANDOM_MIGRATION_NAME' - applying migrations"
dotnet ef database update --project ./login-example-SRA

>&2 echo "Applied migrations - running command"
exec $run_cmd