![Tests](https://github.com/phantomarko/CARetaker/actions/workflows/tests.yml/badge.svg?branch=master)

CARetaker
=========

Create, share and assign maintenance plans for your car.

## Set Up

1. Ensure the containers are not up and running.

2. Set environment variables. Create a `.env` from `.env.example` and assign the missings values.

3. Start containers.

4. Execute migrations. Check the doc in *Migrations > Update Database*.

## Migrations

### Update Database

Using `dotnet-ef`. Execute the following command setting the correct connection string.

```console
dotnet-ef database update --project .\Infrastructure\ --startup-project .\Tools.MigrationRunner\ --connection "YOUR_CONNECTION"
```

Using `VS Package Manager Console`. Using the referred console, set `Tools.MigrationRunner` as startup project and `Infrastructure` as default project and then execute the following command setting the correct connection string.

```console
Update-Database -Connection "YOUR_CONNECTION"
```

### Connection Strings

Use the following template to build a valid connection string:

```
Server={STRING},{INTEGER};Database={STRING};User Id={STRING};Password={STRING};Encrypt={BOOLEAN};
```