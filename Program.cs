using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск базового теста...");
            BasicTest();
            Console.WriteLine("Базовый тест завершен");
        }

        public static void BasicTest()
        {
            int initialCount = Server.GetCount();
            Console.WriteLine($"Начальное значение: {initialCount} (ожидается: 0)");

            Server.AddToCount(5);
            int afterAdd = Server.GetCount();
            Console.WriteLine($"После добавления 5: {afterAdd} (ожидается: 5)");

            Server.AddToCount(-3);
            int afterSubtract = Server.GetCount();
            Console.WriteLine($"После добавления -3: {afterSubtract} (ожидается: 2)");

            Server.AddToCount(0);
            int afterZero = Server.GetCount();
            Console.WriteLine($"После добавления 0: {afterZero} (ожидается: 2)");

            Parallel.For(0, 5, i => {
                int current = Server.GetCount();
                Console.WriteLine($"Параллельное чтение {i}: {current} (ожидается: 2)");
            });

            Server.AddToCount(-Server.GetCount());
            int resetCount = Server.GetCount();
            Console.WriteLine($"После сброса: {resetCount} (ожидается: 0)");

            Parallel.Invoke(
                () => Server.AddToCount(10),
                () => Server.AddToCount(20),
                () => Console.WriteLine($"Чтение во время параллельной записи: {Server.GetCount()}")
            );

            int finalCount = Server.GetCount();
            Console.WriteLine($"Итоговое значение после параллельных операций: {finalCount} (ожидается: 30)");

            Server.AddToCount(-finalCount);
        }
    }
}