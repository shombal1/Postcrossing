# Postcrossing

Что бы запустить приложение локально нужно установить Docker-Desktop.
После этого нужно выполнить команду в директории репозитория.

```shell
docker compose -f ./docker/docker-compose.yml up -d
```

Для миграции базы данных нужно установть ef
```shell
dotnet tool install --global dotnet-ef
```

Для создания таблиц в базе двнных нужно выполнить в директории репозитория нужно выполнить команду
```shell
dotnet ef database update  -p Postcrossing.Storage -s Postcrossing.Api
```

