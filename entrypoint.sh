#!/bin/bash

set -e
run_cmd="dotnet watch run --project ./login-example-SRA --server.urls http://*:80"

until dotnet ef database update --project ./login-example-SRA; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd