#!/usr/bin/env bash
# Call this with three parameters
#   1: The password used to connect to the database
#   2: true/false; if set to true, the database is populated with additional example data
echo "Installing 'netcat' if not present..."
apt-get update && apt-get install -y netcat

echo "Installing 'flyway'..."
wget -qO- https://repo1.maven.org/maven2/org/flywaydb/flyway-commandline/5.2.4/flyway-commandline-5.2.4-linux-x64.tar.gz | tar xvz && ln -s `pwd`/flyway-5.2.4/flyway /usr/local/bin

echo "Waiting for MS SQL server for potential initial database restoration..."
while ! nc -z localhost 1433; do
  sleep 0.1
done

DATABASE_NAME=${3,,}
sed -i "s/{{DATABASE_NAME}}/$DATABASE_NAME/g" "$PWD/queries/initDB/V0__CreateDatabase.sql"

echo "Running flyway database creation queries:"
SCHEMARESULT=$(flyway migrate -url="jdbc:sqlserver://localhost:1433" -user="sa" -password="$1" -locations="filesystem:$PWD/queries/initDB")
echo "Running flyway database creation result: $SCHEMARESULT"

requestedQueries="filesystem:$PWD/queries/base"
if [ "${2,,}" == "true" ]
then
  requestedQueries+=",filesystem:$PWD/queries/exampleData"
fi

echo "Running flyway with the following queries: $requestedQueries"

SCHEMARESULT=$(flyway migrate -url="jdbc:sqlserver://localhost:1433;databaseName=$DATABASE_NAME" -user="sa" -password="$1" -locations="$requestedQueries")
echo "Running flyway result: $SCHEMARESULT"