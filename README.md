# MyMaps

## Что используется
- **Net8.0**
- **PostgreSQL**

## Конфигурация
### Настройка apsettings.json
- **ConnectionStrings:DefaultConnection** - строка подключения к PostgreSQL
- **Пример:**
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=MyMapsDb;Username=postgres;Password=14008"
  }
}

```
### Настройка JwtTokenServiceOptions.json
- **JwtTokenServiceOptions:Issuer** - название этого сервиса в токене
- **JwtTokenServiceOptions:SecretKey** - ключ для подписи токена (любая комбинация символов)
- **JwtTokenServiceOptions:Lifetime** - время жизни токена в секундах
- **Пример:**
```json
{
  "JwtTokenServiceOptions": {
    "Issuer": "MyMapsApi",
    "SecretKey": "a672311c6c8243b0adef53bd1b0593d1",
    "Lifetime": 86400
  }
}
```


## Работа с миграциями
1. Установить dotnet-ef для работы с миграциями из консоли: `dotnet tool install --global dotnet-ef --version 8.0.11`
2. Создать новую миграцию: `dotnet ef migrations add <название_миграции> -s './MyMapsApi.WebHost/' --project './MyMapsApi.Infra.PostgreSql/' -- --environment <ваше_окружение>`
3. Создать БД, из папки с решением: `dotnet ef database update -s './MyMapsApi.WebHost/' --project './MyMapsApi.Infra.PostgreSql/' -- --environment <ваше_окружение>`


# Документация API MyMaps

## Аутентификация

*Конечная точка вхола/регистрации не защищена*

### Вход/Регистрация  
**Endpoint:** `POST /api/auth/login-or-register`  
Аутентифицирует пользователя или регистрирует нового, возвращая JWT-токен.

**Параметры запроса:**  
```json
{
  "name": "имя_пользователя",
  "password": "пароль123"
}
```
- `name`: минимум 1 символ  
- `password`: минимум 6 символов  

**Пример ответа:**  
```json
{
  "data": "eyJhbGci...",
  "isSuccess": true,
  "statusCode": 200,
  "errors": null
}
```

## Работа с постами

*Все конечные точки тут защищённые*

### Создание поста  
**Endpoint:** `POST /api/posts`  

**Параметры запроса:**  
```json
{
  "longitude": 37.6176,
  "latitude": 55.7558,
  "commentary": "Текст поста"
}
```
Возвращает пост в формате:  
```json
{
  "data": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "longitude": 0,
    "latitude": 0,
    "commentary": "string",
    "name": "string"
  },
  "isSuccess": true,
  "statusCode": 0,
  "errors": [
    "string"
  ]
}
```
### Удаление поста  
**Endpoint:** `DELETE /api/posts?postId={uuid}`  
Параметр:  
- `postId`: UUID поста

Возвращает статус код 200 без тела

### Получение всех постов  
**Endpoint:** `GET /api/posts`  
Возвращает массив постов в формате:  
```json
{
  "data": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "longitude": 0,
      "latitude": 0,
      "commentary": "string",
      "name": "string"
    }
  ],
  "isSuccess": true,
  "statusCode": 0,
  "errors": [
    "string"
  ]
}
```

**Примечание:** Все защищенные endpoints требуют JWT-токена в заголовке `Authorization`, например: `Authorization: Bearer {тут_ваш_токен}`.