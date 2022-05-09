<h1 align="center">Tyche</h1>

<p align="center">
<img src="https://img.shields.io/badge/license-MIT-blue.svg" >
<img src="https://img.shields.io/badge/made%20by-includingByMeAndMyself-red.svg" >
<img src="https://img.shields.io/github/issues/silent-lad/VueSolitaire.svg">
</p>


<h2>Описание:</h2>
<p>Простой проект, реализующий сервис RESTful API для сортировки колоды карт по определенным параметрам.</p>
<p>Этот проект состоит из серверной части, которая представляет из себя монолитный REST web API проект, включает:</p>
<ul>
  <li>Tyche.API</li>
  <li>Tyche.BusinessLogic</li>
  <li>Tyche.DataAccess.MsSql</li>
  <li>Tyche.Domain</li>
</ul>
<p>И из клиентской части, которая представляет из себя консольное приложение с простым интерфейсом взаимодествия:</p>
<ul>
  <li>Client.CLI</li>
</ul>
<p>Основной функционал приложения:</p>

```
1 - Создать именованную колоду карт;
2 - Получить созданную колоду карт, выбранную по названию колоды;
3 - Получить список названий созданных колод карт;
4 - Получить все созданные колоды карт;
5 - Удалить все созданные колоды карт;
6 - Удалить созданную колоду карт, выбранную по названию колоды;
7 - Перетасовать колоду карт, выбранную по названию колоды.
```
<h2>Как запускать:</h2>
<p>Строка подключения располагается в <strong>Tyche.API/appsettings.json</strong> (Можно заменить на свою строку подключения)</p>

```
"DeckContext": "Data Source=(LocalDb)\\MSSQLLocalDB;Database=Deck_DB;Trusted_Connection=True;MultipleActiveResultSets=true"
```

<p>Для успешного запуска приложения необходимо выполнить команду на выбор:</p>
<ul>
  <li>Для консоли диспетчера пакетов:</li>
  
  ```
Update-Database
``` 
  <li>Для окна командной строки:</li>
    
  ```
dotnet ef database update
``` 
</ul>

<h2>Используемые технологии:</h2>
<p>Серверная и клиентская часть выполненны на <strong>c# .NET Core 5, ASP Web API</strong><p>
<p>Для хранения данных используется <strong>LocalDb</strong><p>
<p>Для работы с базой данных используется ORM <strong>entity framework core 5</strong><p>
