# Dev Environment

## Setup Docker

1. Download and Install [Docker Desktop](https://www.docker.com/products/docker-desktop)
2. If you are running Docker inside of a Hyper-V VM you will need to enable nested virtualization

    ```powershell
    Set-VMProcessor -VMName <VMName> -ExposeVirtualizationExtensions $true
    ```

## Setup Database Locally

1. Download [Azure Data Studio](https://docs.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver15#download-azure-data-studio)
2. Pull the SQL container image from Microsoft Container Registry

    Examples:

    ```powershell
    docker pull mcr.microsoft.com/mssql/server:2019-latest
    ```

    or

    ```powershell
    docker pull mcr.microsoft.com/azure-sql-edge:latest
    ```

3. Start the SQL instance

    ```powershell
    docker run -e 'ACCEPT_EULA=1' -e 'SA_PASSWORD=MyP@ssword' -p 1433:1433 --name sql2019 -h sql2019 -d mcr.microsoft.com/mssql/server:2019-latest
    ```

    See also: [Run SQL Server container images with Docker](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-powershell)

    or

    ```powershell
    docker run -e 'ACCEPT_EULA=1' -e 'MSSQL_USER=SA' -e 'MSSQL_SA_PASSWORD=MyP@ssword' -e 'MSSQL_PID=Developer' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
    ```

    See also: [Deploy Azure SQL Edge with Docker](https://docs.microsoft.com/en-us/azure/azure-sql-edge/disconnected-deployment)

4. Confirm you can access the database using Azure Data Studio, for example see [Connect to a SQL Server](https://docs.microsoft.com/en-us/sql/azure-data-studio/quickstart-sql-server?view=sql-server-ver15#connect-to-a-sql-server)

## Deploy Application Database

1. Open Visual Studio
2. Open the Package Manager Console from Tools -> Nuget Package Manager -> Package Manager Console
3. Set the `Default project` to be _src\Infrastructure_
4. Enter the following command

    ```command
     Update-Database -ConnectionString "Server=localhost;Database=Synopsis;user id=sa;password=MyP@ssword;" -ConnectionProviderName "System.Data.SqlClient" -Verbose
    ```

5. Connect to the database and confirm all tables were created and populated with seed data
6. To revert back to an empty datbase run the command

    ```command
    Update-Database -ConnectionString "Server=localhost;Database=Synopsis;user id=sa;password=MyP@ssword;" -ConnectionProviderName "System.Data.SqlClient" -TargetMigration $InitialDatabase -Verbose
    ```
