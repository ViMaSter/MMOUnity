# Dockerized database for music2me

This repository contains everything required to setup a local database to use in conjuction with the [ASP.NET project](https://dev.azure.com/sunlab-devops/music2me/_git/web%20application) of music2me.

## Local database setup
### Initial setup
1. Ensure your Docker is able to use at least 4 GB Memory
2. Clone this repository to your local machine
3. Create a file called `.env` inside the root of your local clone of the repository with the following content and replace values wrapped in `[]`:
```
COMPOSE_PROJECT_NAME=[ANY STRING OF ALPHANUMERIC CHARACTERS]
DB_Pass=[RANDOMIZED STRING OF ALPHANUMERIC CHARACTERS]        # must adhere to MSSQL password policy
WITH_EXAMPLE_DATA=true                                        # leave this set to "true" to pre-fill the DB with a small set of example data
```
4. Run `docker-compose up --build --force-recreate --renew-anon-volumes`
5. Connect your client using the following credentials:
```
HOSTNAME = localhost
PORT     = 1433
USERNAME = sa
PASSWORT = [RANDOMIZED STRING OF ALPHANUMERIC CHARACTERS]
```
6. Replace `[RANDOMIZED STRING OF ALPHANUMERIC CHARACTERS]` with the one used inside your `.env`-file.

Note: Check [SQL Server Password Policy](https://docs.microsoft.com/en-us/sql/relational-databases/security/password-policy?view=sql-server-ver15#password-complexity) to ensure your chosen password adheres to the policy - otherwise, the sql server will not start.