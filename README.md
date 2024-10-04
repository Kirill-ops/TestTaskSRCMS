**Задание.**

**Сделать asp.net web api 2 контроллер для редактирования таблицы врачей.**

Контроллер должен поддерживать операции:
- Добавление записи
- Редактирование записи
- Удаление записи
- Получения списка записей для формы списка с поддержкой сортировки и постраничного возврата данных (должна быть возможность через параметры указать по какому полю список должен быть отсортирован и так же через параметры указать какой фрагмент списка (страницу) необходимо вернуть)
- Получение записи по ид для редактирования

Объект, возвращаемый методом получения записи для редактирования и объекты, возвращаемые методом получения списка должны быть разными:
- объект для редактирования должен содержать только ссылки (id) связанных записей из других таблиц,
- объект списка не должен содержать внещних ссылок, вместо них необходимо возвращать значение из связанной таблицы (т.е. не id специализации врача, а название).
Никаких лишних полей в объектах быть не должно.

В качестве базы необходимо использовать MS SQL.
Таблицы в базе:
- Участки: Номер
- Специализации: Название
- Кабинеты: Номер
- Врачи ФИО, Кабинет (ссылка), Специализация (ссылка), Участок (для участковых врачей, ссылка)

**Инструкция для тестирования**

- скачать Postman.
- отправить POST запрос на адресс http://localhost:5025/help
- После этого в папке TestTaskSRCMS.Web появится папка Files с файлом postDoctor.json, который нужно использовать в POST запросе на адрес http://localhost:5025/doctors
- Данный запрос добавит в БД нового врача.
- Для редактирования и удаления врача, нужно сначала отправить POST запрос на адресс http://localhost:5025/help/ID, где ID - это Id врача в БД
- Данный запрос создаст файлы putDoctor.json и deleteDoctor.json, который нужно использовать в PUT и DELETE запросах на адрес http://localhost:5025/doctors, чтобы изменить и удалить врача, соответственно.
- Чтобы получить информацию о врачах нужно отправить GET запрос на адресс http://localhost:5025/doctors. С помощью параметров можно указать по какому полю сделать сортировку и лимит записей. 
- Чтобы получить информацию о конкретном враче нужно отправить GET запрос на адресс http://localhost:5025/doctors/ID, где ID - это Id врача в БД
