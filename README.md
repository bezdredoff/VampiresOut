Версия 01.

На данный момент мы уже реализовали несколько ключевых функций для игры в Unity, используя UI Toolkit и скрипты. Вот что уже готово:

✅ 1. Запуск уровня с объектами для поиска
Как работает:

Загружается сцена с фоновым изображением - Sample Scene.
На экране отображаются фон и объекты для поиска (3 летучих мыши).
Игрок может кликать по объектам, которые исчезают при нажатии.
Счётчик найденных объектов уменьшается.
Как реализовано:

UI Toolkit используется для отображения интерфейса.
GameManager управляет логикой уровня.
HiddenObject отвечает за клик по объектам.

✅ 2. Обновление счётчика найденных объектов
Как работает:

Количество оставшихся объектов обновляется в UI Label.

GameManager хранит список объектов и следит за их количеством.
UI Label обновляется после каждого найденного объекта.

✅ 3. Пинчзум и перемещение по уровню пальцем
ScrollAndZoomController позволяет перемещаться по карте влево-вправо и зумировать колесом мыши с компьютера, а также двумя пальцами на телефоне (но вроде это плохо работает)
Также в этом скрипте установлено ограничение на размеры фонового изображения
