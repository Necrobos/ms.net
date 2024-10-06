# ms.net
-----------
Приложение "АВИТО НА МИНИМАЛКАХ"
--------------
Существует 3 типа пользователей:
----------------
Покупатель — покупает товар, выложенный на площадку.

Продавец — выкладывает товар на продажу.

Администратор — контролирует работу приложения и следит за нарушениями правил.
_____________________
Работа с логинами пользователей
------
+ Пользователи регистрируются указав: ФИО, почта, пароль, дата рождения, паспортные данные для подтверждения возраста. Также обязателен логин, который должен быть уникальным.
+ Данные в системе после регистрации сохраняются, также пользователь может удалить свой аккаунт, либо выйти с аккаунта на устройстве.
+ Администратор может удалить аккаунт пользователя, если он нарушает права или аккаунт является ботом.
___________________
Работа с записями
--------
INDEX — пользователи могут смотреть список выложенных товаров.

CREATE — Продавцы могут создавать новую страницу продажи товара с указанием цены, характеристик, города и тд.

READ — Пользователи могут просматривать определенную запись для уточнения деталий товара.

UPDATE — Продавцы могут редактировать детали своих выложенных на продажу товаров  (записей).

DELETE — Продавцы могут удалять свои свои товары, которые они выставили на продажу. Администратор может удалять запись, если она не соответсвует теме или нарушает права (права человека, содержит оскорбление, неприятный контент и т. д.)
