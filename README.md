# 1. Выявление и анализ требований к системе
   
# 1.1 Постановка задачи 
Требуется разработать программную систему, предназначенную для организаторов соревнований по футболу в рамках первенства страны
## 1.1.1 Общее описание программной системы
Программа обеспечивает хранение сведений о командах, участвующих в первенстве, об игроках команд, о расписании встреч и их результатах, о цене билетов на игры.
## 1.1.2 Основные задачи системы	
К основным задачам системы относятся:
·	просмотр сведений о командах
·	просмотр расписания встреч конкретной команды
·	просмотр состава конкретной команды
·	добавление, удаление и изменение игроков
·	просмотр сведений о матчах
·	просмотр текущей турнирной таблицы

## 1.2. Первичные требования к системе
Ниже приведены первичные требования и их описание к системе:
•	Организатор может добавить игрока 
•	Организатор может удалить существующего игрока
•	Организатор может изменить сведения существующего игрока
•	Организатор может перенести несыгранный матч на свободные даты
•	Организатор может задать результат несыгранного матча или поменять результат уже завершенного
•	Организатор имеет возможность посмотреть текущее положение команд
•	Цена билета на матч формируется в зависимости от вместимости стадиона и мест встречающихся команд в прошлом сезоне.
•	Организатор имеет возможность планомерно задавать результаты матчей, переходя от одного игрового дня к другому 


## 1.3 Конкретные требования к приложению
## 1.3.1 Функциональность
Далее будет приведен интерфейс приложения, а также представлены функциональные и нефункциональные требования.
### 1.3.1.1 Раздел расписания встреч 
На рисунке 1 показано отображение раздела расписания встреч. Представленные матчи можно фильтровать по дате и их статусу завершенности. 
 ![image](https://github.com/user-attachments/assets/58e17649-b669-4aaf-97b4-7483241144ba)
|:----:|
Рисунок 1 – Календарь 

### 1.3.1.2 Главный раздел текущего игрового дня
На рисунке 2 приводится отображение раздела с матчами текущего игрового дня. 
 ![image](https://github.com/user-attachments/assets/880b14cf-703e-4a10-abde-18e0a55c332e)
|:----:|
Рисунок 2 – Главная 

### 1.3.1.3 Раздел команд
На рисунке 3 показано отображение раздела команд. Каждая из строк представляет собой кнопку перехода к подробной информации о команде.
 ![image](https://github.com/user-attachments/assets/ad95a440-039b-4e36-a5f9-7159c79afa02)
|:----:|
Рисунок 3 – Команды 

### 1.3.1.4 Окно информации о команде
В окне, изображенном на рисунке 4, организаторы могут просматривать подробные сведения о конкретной команде, а именно о их тренере, стадионе, месте в прошлом сезоне. 
 ![image](https://github.com/user-attachments/assets/b150f31f-05b9-4416-a307-6af2041f8589)
|:----:|
Рисунок 4 – Окно команды

### 1.3.1.5 Окно информации о игроке
На рисунке 5 представлено окно основной информации о игроке, служащее не только для просмотра сведений, но и для изменения уже существующих игроков и добавление новых. 
 ![Описание](https://github.com/user-attachments/assets/c7554b73-4433-40fe-be08-b26d90f460cb)
|:----:|
Рисунок 5 – Окно информации о игроке

### 1.3.1.6 Окно информации о матче
В окне, изображенном на рисунке 6, присутствует подробная информация о матче, в том числе о стоимости билетов на игру и вместимости стадиона, на котором проходит встреча. В данном окне организатор может задать результат встречи, а также изменить дату матча, в случае если данный матч еще не сыгран.
 ![image](https://github.com/user-attachments/assets/d9b64c1d-eee7-43c7-bfa5-296392c85b47)
|:----:|   
Рисунок 6 – Окно информации о матче

### 1.3.1.7 Раздел текущего положения команд
На рисунке 7 представлено отображение раздела таблицы текущего первенства, отражающего основные статистические показатели команд и их положение среди других на данный момент. Среди показателей содержатся следующие: количество игр, количество побед, количество ничей, количество поражений, количество очков на данный момент.
 ![image](https://github.com/user-attachments/assets/ea9a5516-36b3-4830-ba73-40d8a5c3aa6a)
|:----:|   
Рисунок 7 – Таблица
