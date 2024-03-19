![Tests](https://github.com/phantomarko/CARetaker/actions/workflows/tests.yml/badge.svg?branch=master)

CARetaker
=========

Create, share and assign maintenance plans for your car.

## Set Up

### Database

Launch a SQL Server container via Docker:
```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```