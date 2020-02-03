#!/bin/bash

# wait for database to start...

if [ ! -z "$SA_PASSWORD" ]; then
  echo "$0: inicializando dump da estrutura"
  for i in {30..0}; do
    if sqlcmd -U SA -P $SA_PASSWORD -Q 'SELECT 1;' &> /dev/null; then
      echo "$0: SQL Server started"
      break
    fi
    echo "$0: SQL Server startup in progress..."
    sleep 1
  done
fi