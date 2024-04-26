# Easy Tracker API
Базовое апи таск трекера!

## about me
i am the best people in KOD. Millioner, playboy, filantrop.

## project technologi
- dotnet 
- web api
- efcore
- identyty core

## API
- "**/api/account/getall**" - вывод всех пользователей (List<user>)
- "**/api/account/get/{name}**" - вывод данных пользователя по имени (user)
- "**/api/account/register/{[FromBody] User}**" - регистрация нового пользователя
- "**/api/account/verify/{[FromBody] User}**" - подтверждение аккаунта (bool)

- "**/api/tasks/getall**" - вывод всех задач (IEnumerable<TrackerTask>)
- "**/api/tasks/get/{id}**" - вывод задачи по id (TrackerTask)
- "**/api/tasks/add/{[FromBody] TrackerTask}**" - создать задачу
- "**/api/tasks/delete/{id}**" - удалить задачу по id
- "**/api/tasks/complete/{id}**" - выполнить задачу по id
- "**/api/tasks/addrandom/{id}**" - создать рандомную задачу