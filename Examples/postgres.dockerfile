FROM postgres
COPY SQL/create-multiple-postgresql-databases.sh /docker-entrypoint-initdb.d/
