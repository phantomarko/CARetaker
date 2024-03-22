![Tests](https://github.com/phantomarko/CARetaker/actions/workflows/tests.yml/badge.svg?branch=master)

CARetaker
=========

Create, share and assign maintenance plans for your car.

## Set Up

1. Ensure the containers are not up and running.

2. Set environment variables. Create a `.env` from `.env.example` and assign a value to the database password.

3. Start containers.

4. Execute migrations. Check the doc in *Migrations > Update Database*.

## Migrations

### Update Database

Using `dotnet-ef`. Execute the following command setting the correct connection string.

```console
dotnet-ef database update --project .\Infrastructure\ --startup-project .\Tool.MigrationRunner\ --connection "YOUR_CONNECTION"
```

Using `VS Package Manager Console`. Using the referred console, set `Tool.MigrationRunner` as startup project and `Infrastructure` as default project and then execute the following command setting the correct connection string.

```console
Update-Database -Connection "YOUR_CONNECTION"
```