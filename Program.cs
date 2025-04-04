using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Базовый тест...");
            BasicTest();
            Console.WriteLine("Тест закончен...");
        }

        public static void BasicTest()
        {
            // 1. Проверка начального значения
            int initialCount = Server.GetCount();
            Console.WriteLine($"Начальное значение: {initialCount} (Должно: 0)");

            // 2. Добавление значения и проверка
            Server.AddToCount(5);
            int afterAdd = Server.GetCount();
            Console.WriteLine($"После добавление 5: {afterAdd} (Должно: 5)");

            // 3. Добавление отрицательного значения
            Server.AddToCount(-3);
            int afterSubtract = Server.GetCount();
            Console.WriteLine($"После добавление -3: {afterSubtract} (Должно: 2)");

        }
    }
}