# Задание по созданию API с использованием EF Core, Domain и Infrastructure слоев с сервисами и PostgreSQL

## Цель:
Разработать API для работы с продуктами, используя Entity Framework Core и PostgreSQL, с разделением на слои **Domain**, **Infrastructure** и **WebAPI**, при этом бизнес-логика будет реализована через сервисы

## Структура проекта:
1. **Domain** — содержит модели данных.
2. **Infrastructure** — содержит логику взаимодействия с базой данных через Entity Framework Core.
3. **WebAPI** — предоставляет контроллеры для обработки HTTP-запросов.

## 1. **Domain**:
В этом слое находятся только модели данных, которые определяют сущности и их свойства.

### Задачи:
- **Модель данных:** Создайте модель `Product`, которая будет содержать свойства для продукта, такие как `Id`, `Name`, `Price`, `Category`.
- Модель не должна содержать зависимости от внешних слоев, таких как база данных или сервисы.

## 2. **Infrastructure**:
Этот слой будет отвечать за доступ к данным через Entity Framework Core.

### Задачи:
- **Контекст базы данных:** Реализуйте класс контекста `DataContext`, который будет наследоваться от `DbContext` и включать `DbSet<Product>`. Контекст управляет подключением к базе данных и выполнением запросов.
- **Сервис работы с продуктами:** Вместо репозитория создайте сервис, который будет отвечать за выполнение операций с продуктами. Сервис должен использовать `DataContext` для работы с базой данных.

## 3. **WebAPI**:
Этот слой отвечает за обработку HTTP-запросов и взаимодействие с пользователем через API.

### Задачи:
- **Контроллер API:** Создайте контроллер `ProductsController`, который будет обрабатывать следующие HTTP-запросы:
  - `GET /api/products` — получить все продукты.
  - `GET /api/products/{id}` — получить продукт по ID.
  - `POST /api/products` — добавить новый продукт.
  - `PUT /api/products/{id}` — обновить продукт.
  - `DELETE /api/products/{id}` — удалить продукт.
  
- Контроллер будет использовать сервис `ProductService` для обработки запросов и выполнения операций с данными.

## 4. **Процесс разработки**:
1. **Проектирование слоев:**
   - Сначала создайте модель `Product` в слое **Domain**.
   - Реализуйте `DataContext` в слое **Infrastructure**, а также сервисы, такие как `ProductService`, которые будут выполнять операции с базой данных.
   - Настройте взаимодействие между контроллером API и сервисом `ProductService` в слое **WebAPI**.

2. **Реализация бизнес-логики:**
   - Сервис `ProductService` будет содержать всю бизнес-логику для работы с продуктами. Этот сервис будет использовать `DataContext` для выполнения операций с продуктами в базе данных.

3. **Настройка API:**
   - Создайте контроллер `ProductsController`, который будет обрабатывать HTTP-запросы и передавать их в сервисы для обработки.
   - Обеспечьте обработку ошибок и валидацию данных на уровне API.

4. **Работа с PostgreSQL:**
   - Настройте подключение к PostgreSQL через Entity Framework Core.
   - Для этого нужно будет установить пакет для PostgreSQL:
     ```bash
     dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
     ```
   - Настройте строку подключения в `appsettings.json`:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Host=localhost;Port=5432;Database=productsdb;Username=myuser;Password=mypassword"
       }
     }
     ```
   - Используйте миграции для создания базы данных:
     ```bash
     dotnet ef migrations add InitialCreate -s Webapi -p Infrastructure
     dotnet ef database update -s Webapi -p Infrastructure
     ```

## Установка пакетов:
Для работы с PostgreSQL и создания WebAPI, установите следующие NuGet пакеты:
1. `Microsoft.EntityFrameworkCore` — основной пакет для работы с Entity Framework Core.
2. `Npgsql.EntityFrameworkCore.PostgreSQL` — провайдер для PostgreSQL.
4. `Microsoft.EntityFrameworkCore.Tools` — для работы с миграциями.

