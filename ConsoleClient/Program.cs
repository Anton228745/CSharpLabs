using System;
using CoreLibrary;

class Program
{
    static void Main()
    {
        // Включаем поддержку кириллицы в консоли
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine(" ЛАБОРАТОРНАЯ РАБОТА: ТИПЫ ДАННЫХ В .NET \n");

        //  1. Расчет ИМТ 
        Console.WriteLine(" Задание 1: Расчет ИМТ (BMI) ");
        Console.Write("Введите вес в кг (например, 75): ");
        if (double.TryParse(Console.ReadLine(), out double weight))
        {
            Console.Write("Введите рост в метрах (например, 1.78): ");
            if (double.TryParse(Console.ReadLine(), out double height) && height > 0)
            {
                double bmi = DataTypesLab.CalculateBmi(weight, height);
                Console.WriteLine($"Ваш индекс массы тела (ИМТ): {bmi:F2}\n");
            }
        }

        //  2. Массив без LINQ и Sort 
        Console.WriteLine("Задание 2: Массив (мин, макс, сортировка вручную) ");
        DataTypesLab.ProcessArray(10, 1, 50, out int[] sortedArray, out int min, out int max);
        Console.WriteLine($"Отсортированный массив: {string.Join(", ", sortedArray)}");
        Console.WriteLine($"Минимальное значение: {min}");
        Console.WriteLine($"Максимальное значение: {max}\n");

        //  3. Средняя длина слова 
        Console.WriteLine("Задание 3: Средняя длина слова в строке ");
        Console.WriteLine("Введите текст (например: 'Hello world. Csharp programming!'):");
        string text = Console.ReadLine();
        double avgLength = DataTypesLab.GetAverageWordLength(text);
        Console.WriteLine($"Средняя длина слова: {avgLength:F2} символов\n");

        //  4. Struct, память и ref/out параметры 
        Console.WriteLine(" Задание 4: Память, struct, ref/out и сборщик мусора ");
        
        // 4a. Использование struct (значимый тип, живет в стеке)
        PointStruct point = new PointStruct(10, 20);
        Console.WriteLine($"Структура PointStruct (Stack): X = {point.X}, Y = {point.Y}");

        // 4b & 4c. Разница при изменении объектов внутри метода
        int originalInt = 10;
        int refVarInt = 20;
        PersonClass person = new PersonClass("Алексей", 25);

        Console.WriteLine($"ДО вызова метода: int = {originalInt}, refInt = {refVarInt}, Person.Age = {person.Age}");
        
        DataTypesLab.ModifyValues(originalInt, ref refVarInt, person);
        
        Console.WriteLine($"ПОСЛЕ вызова метода:");
        Console.WriteLine($"  - Обычный int не изменился: {originalInt}");
        Console.WriteLine($"  - Переменная с ref изменилась: {refVarInt}");
        Console.WriteLine($"  - Ссылочный объект (class в Heap) изменился: {person.Age}");

        // 4e. Принудительная сборка мусора
        DataTypesLab.ForceGarbageCollection();

        Console.WriteLine("\nВсе задания лабораторной работы успешно выполнены!");
    }
}