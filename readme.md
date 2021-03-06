# Заметки о многопоточности в C# с примерами.

## [Перейти к содержанию ⮚](content.md)

<br>


## __Разница в терминах, Concurrency vs Multithreading vs Asynchrony vs Parallelism__

### __Конкурентность (Concurrency)__
**Конкурентность** - это наиболее общий термин, который говорит, что одновременно выполняется более одной задачи.

Конкурентное исполнение - это самый общий термин, который не говорит о том, каким образом эта конкурентность будет получена: путем приостановки некоторых вычислительных элементов и их переключение на другую задачу, путем действительно одновременного исполнения, путем делегации работы другим устройствам или еще как-то. Это не важно.

Конкурентное исполнение говорит о том, что за определенный промежуток времени будет решена более, чем одна задача. Точка.

### __Параллельное исполнение__
__Параллельное исполнение (parallel computing)__ подразумевает наличие более одного вычислительного устройства (например, процессора), которые будут одновременно выполнять несколько задач.

Параллельное исполнение - это строгое подмножество конкурентного исполнения. Это значит, что на компьютере с одним процессором параллельное программирование - невозможно.

### __Многопоточность__
__Многопоточность__ - это один из способов реализации конкурентного исполнения путем выделения абстракции "рабочего потока" (worker thread).

Потоки "абстрагируют" от пользователя низкоуровневые детали и позволяют выполнять более чем одну работу "параллельно". Операционная система, среда исполнения или библиотека прячет подробности того, будет многопоточное исполнение конкурентным (когда потоков больше чем физических процессоров), или параллельным (когда число потоков меньше или равно числу процессоров и несколько задач физически выполняются одновременно).

### __Асинхронное исполнение__
__Асинхронность (asynchrony)__ подразумевает, что операция может быть выполнена кем-то на стороне: удаленным веб-узлом, сервером или другим устройством за пределами текущего вычислительного устройства.

Основное свойство таких операций в том, что начало такой операции требует значительно меньшего времени, чем основная работа. Что позволяет выполнять множество асинхронных операций одновременно даже на устройстве с небольшим числом вычислительных устройств.


<!-- Источник <sup id="a1">[1](#f1)</sup> -->

> ### Источники
><t id="f1">1) </t>[https://ru.stackoverflow.com/](https://ru.stackoverflow.com/questions/445768/Многопоточное-vs-асинхронное-программирование)
 <!-- [↩](#a1) -->