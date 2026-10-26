using System;

namespace CoreLibrary;

// 4a. Пример структуры (value-тип, хранится в стеке)
public struct PointStruct
{
    public int X;
    public int Y;

    public PointStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// 4b. Пример класса для демонстрации ссылочного типа (хранится в куче)
public class PersonClass
{
    public string Name { get; set; } // Ссылочный тип (строка)
    public int Age { get; set; }      // Значимый тип (int)

    public PersonClass(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class DataTypesLab
{
    /// <summary>
    /// 1. Расчет индекса массы тела (ИМТ / BMI).
    /// </summary>
    public static double CalculateBmi(double weightKg, double heightM)
    {
        if (heightM <= 0) throw new ArgumentException("Рост должен быть больше нуля.");
        return weightKg / (heightM * heightM);
    }

    /// <summary>
    /// 2. Генерация массива, поиск мин/макс и сортировка БЕЗ использования LINQ и встроенных методов (Sort, Max).
    /// </summary>
    public static void ProcessArray(int size, int minValue, int maxValue, out int[] sortedArray, out int min, out int max)
    {
        var random = new Random();
        sortedArray = new int[size];

        // Генерируем элементы
        for (int i = 0; i < size; i++)
        {
            sortedArray[i] = random.Next(minValue, maxValue + 1);
        }

        // Ищем минимум и максимум вручную
        min = sortedArray[0];
        max = sortedArray[0];
        for (int i = 1; i < size; i++)
        {
            if (sortedArray[i] < min) min = sortedArray[i];
            if (sortedArray[i] > max) max = sortedArray[i];
        }

        // Сортируем массив вручную (пузырьком)
        for (int i = 0; i < sortedArray.Length - 1; i++)
        {
            for (int j = 0; j < sortedArray.Length - i - 1; j++)
            {
                if (sortedArray[j] > sortedArray[j + 1])
                {
                    int temp = sortedArray[j];
                    sortedArray[j] = sortedArray[j + 1];
                    sortedArray[j + 1] = temp;
                }
            }
        }
    }

    /// <summary>
    /// 3. Определение средней длины слова в строке (без регулярных выражений и ручного перечисления разделителей).
    /// </summary>
    public static double GetAverageWordLength(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return 0;

        int totalLetters = 0;
        int wordCount = 0;
        bool inWord = false;

        foreach (char c in input)
        {
            // Используем стандартные методы char для проверки на букву или цифру
            if (char.IsLetterOrDigit(c))
            {
                if (!inWord)
                {
                    inWord = true;
                    wordCount++;
                }
                totalLetters++;
            }
            else
            {
                inWord = false;
            }
        }

        return wordCount == 0 ? 0 : (double)totalLetters / wordCount;
    }

    /// <summary>
    /// 4c. Демонстрация передачи параметров (значимые vs ссылочные типы).
    /// </summary>
    public static void ModifyValues(int regularInt, ref int refInt, PersonClass person)
    {
        regularInt = 999;       // Изменится только внутри метода (копия)
        refInt = 777;           // Изменится и снаружи, так как передан по ссылке (ref)
        person.Age = 100;       // Ссылочный объект изменится снаружи, так как передается ссылка на кучу
    }

    /// <summary>
    /// 4e. Принудительный запуск сборщика мусора (Garbage Collector).
    /// </summary>
    public static void ForceGarbageCollection()
    {
        Console.WriteLine("\n[GC] Запуск принудительной сборки мусора...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine($"[GC] Сборка завершена. Память в куче до соотв. поколений очищена. Всего поколений: {GC.MaxGeneration}");
    }
}