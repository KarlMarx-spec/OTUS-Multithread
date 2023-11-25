using MultithreadProject;
using System.Diagnostics;

int iterations = 100_000_000;
var array = new List<long>(iterations);
long n = 0;
for (long i = 0; i < iterations; i++)
{
    array.Add(i);
}

Console.WriteLine("Конфигурация: ОЗУ 12ГБ, процессор Intel Core i7-8750H (6 ядер)");
Stopwatch timer = new();

timer.Start();
n = SumCalculator.SumClassic(array);
timer.Stop();
Console.WriteLine($"Количество итераций {iterations}, время выполнения при однопоточной работе: {timer.Elapsed}, результат {n}");
timer.Reset();

timer.Start();
n = await SumCalculator.SumMultithreadAsync(array);
timer.Stop();
Console.WriteLine($"Количество итераций {iterations}, время выполнения при многопоточной работе: {timer.Elapsed}, результат {n}");
timer.Reset();

timer.Start();
n = SumCalculator.SumLINQ(array);
timer.Stop();
Console.WriteLine($"Количество итераций {iterations}, время выполнения при многопоточной работе с LINQ: {timer.Elapsed}, результат {n}");
timer.Reset();
