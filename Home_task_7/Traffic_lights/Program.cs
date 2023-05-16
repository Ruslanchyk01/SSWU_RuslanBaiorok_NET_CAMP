﻿/* нажаль вже трохи забув асинхронність, а вже нема часу пригадати, щоб зробити це завдання асинхронно. По суті моя програма працює так:
1. Запускається меню користувача, де він може запустити симуляцію, змінити таймери кольорів або закрити програму;
2. Симуляція мене відбувається так: виводяться поточні кольори двох світлофорів: червоний і зелений,
після цього йде таймер червоного кольору першого світлофора, коли час минає, світлофор змінюється на жовтий колір і виводиться інформація, що змінено колір на жовтий.
Вже аж після цього йде робота другого світлофора: зелений світить певний час, потім зміюється на червоний.
Коли змінився колір останнього світлофра, нам знову виводиться інформація, якого кольору зараз світлофори - і так по колу.
Я вставлю скріни;
3. Ну b є опція зміни таймерів
Ps. Зробив так, що можна вийти із симуляції світлофорів в головне меню контролера, щоб закрити програму, або змінити таймери і знову запустити симуляцію*/
using Traffic_lights;
Світлофорів повинно бути 4.
TrafficLight northSouth = new TrafficLight("North-South", 5, 1, 3, LightColor.Red);
TrafficLight eastWest = new TrafficLight("East-West", 5, 1, 3, LightColor.Green);

List<TrafficLight> trafficLights = new List<TrafficLight> { northSouth, eastWest };

Crossroads crossroads = new Crossroads(trafficLights);

Controller controller = new Controller(trafficLights, crossroads);

controller.SimulationController();