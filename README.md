![loom](https://user-images.githubusercontent.com/18274298/100971031-85616680-3579-11eb-83da-a240bb236200.jpg)

# Loom

> Loom is a solution for chatting about real-time issues.

## Setting up the development environment on Mac

Pull the Azure SQL Edge container image from Microsoft Container Registry.

```console
sudo docker pull mcr.microsoft.com/azure-sql-edge:latest
```

Start an Azure SQL Edge instance running

```console
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Pa$$w0rd' -p 1433:1433 --name mssql -d mcr.microsoft.com/azure-sql-edge
```

Connection string for sqlserver in Docker container

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Initial Catalog=Loom;User Id=sa;Password=Pa$$w0rd;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True;"
}
```
