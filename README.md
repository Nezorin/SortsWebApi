# SortsWebApi
Самостоятельный проект, для набора опыта разработки
## Пример использования
Пример Get запроса для сортировки вставками: ```Sort/InsertionSort?array=23&array=5&array=0```

Ответ: 
```
{ 
"id":10,
"sortName":"InsertionSort",
"startArray":[23,5,0],
"sortedArray":[0,5,23],
"sortingTime":{"ticks":2,"days":0,"hours":0,"milliseconds":0,"minutes":0,"seconds":0,"totalDays":2.3148148148148147E-12,"totalHours":5.5555555555555553E-11,"totalMilliseconds":0.0002,"totalMinutes":3.3333333333333334E-09,"totalSeconds":2E-07},
"requestTime":"2021-08-07T17:09:57.6973821+03:00"
}
```
Пример Get запроса для сортировки пузырьком: ```/Sort/BubbleSort?array=-2&array=1&array=0&array=47&array=5&array=6&array=-6```
```
{ 
"id":11,
"sortName":"BubbleSort",
"startArray":[-2,1,0,47,5,6,-6],
"sortedArray":[-6,-2,0,1,5,6,47],
"sortingTime":{"ticks":6,"days":0,"hours":0,"milliseconds":0,"minutes":0,"seconds":0,"totalDays":6.944444444444444E-12,"totalHours":1.6666666666666666E-10,"totalMilliseconds":0.0006,"totalMinutes":1E-08,"totalSeconds":6E-07},
"requestTime":"2021-08-07T17:15:00.8610892+03:00"
}
```
## Технологии
 - **C#**
 - **ASP.NET Core WebAPI**
 - **Entity Framework Core**
 - **xUnit**
 - **PostgreSQL**
