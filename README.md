# SortsWebApi
Самостоятельный проект, для набора опыта разработки
## Пример использования
Пример GET запроса для сортировки слиянияем: ```https://localhost:5001/Sort/MergeSort?array=12441&array=-234&array=0&array=0&array=1&array=0&array=124&array=12&array=13&array=-8&array=124421```

Ответ: 
```
{
"id":20,
"sortName":"MergeSort",
"startArray":[12441, -234, 0, 0, 1, 0, 124, 12, 13, -8, 124421],
"sortedArray":[-234, -8, 0, 0, 0, 1, 12, 13, 124, 12441, 124421],
"sortingTime":{"ticks":2650,"days":0,"hours":0,"milliseconds":0,"minutes":0,"seconds":0,"totalDays":3.0671296296296296E-09,"totalHours":7.361111111111111E-08,"totalMilliseconds":0.265,"totalMinutes":4.416666666666667E-06,"totalSeconds":0.000265},
"requestTime":"2021-08-09T19:26:21.678226+03:00"
}
```
Пример GET запроса для случайной сортировки: ```https://localhost:5001/Sort/BogoSort?array=12441&array=-234&array=0&array=0&array=1&array=0&array=124&array=12&array=13&array=-8&array=124421```

Ответ: 
``` 
{
"id": 19,
"sortName":"BogoSort",
"startArray":[12441, -234, 0, 0, 1, 0, 124, 12, 13, 8, 124421],
"sortedArray":[-234, -8, 0, 0, 0, 1, 12, 13, 124, 12441, 124421],
"sortingTime":{"ticks":129127766,"days":0,"hours":0,"milliseconds":912,"minutes":0,"seconds":12,"totalDays":0.00014945343287037037,"totalHours":     0.003586882388888889,"totalMilliseconds":12912.7766,"totalMinutes":0.21521294333333332,"totalSeconds":12.9127766},
"requestTime":"2021-08-09T19:22:09.5751466+03:00"
}
```
## Технологии
 - **C#**
 - **ASP.NET Core WebAPI**
 - **Entity Framework Core**
 - **xUnit**
 - **PostgreSQL**
 - **Swagger**
