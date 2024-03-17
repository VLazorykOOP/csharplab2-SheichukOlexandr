using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear(); // Очистка консолi
            Console.WriteLine("Меню вибору завдання:");
            Console.WriteLine("1. Перевiрка добутку елементiв тризначним числом в масивi");
            Console.WriteLine("2. Пiдрахунок кiлькостi елементiв, бiльших за попереднiй");
            Console.WriteLine("3. Пiдрахунок суми елементiв на побiчнiй дiагоналi масиву");
            Console.WriteLine("4. Пiдрахунок кiлькостi додатних елементiв у кожному рядку масиву");
            Console.WriteLine("5. Вихiд");

            Console.Write("Оберiть завдання (або введiть '5' для виходу):  ");
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Некоректний вибiр. Спробуйте ще раз.");
                    break;
            }
            Console.WriteLine("\nНатиснiть будь-яку кнопку для продовження...");
            Console.ReadKey(); // Чекає натискання будь-якої кнопки
        }
    }

    static void Task1()
    {
        Console.WriteLine("Завдання 1:");
        Console.WriteLine("Введiть розмiрнiсть масиву:");
        int n = int.Parse(Console.ReadLine());

        // Одновимiрний масив
        double[] array1D = new double[n];

        // Двовимiрний масив
        double[,] array2D = new double[n, n];

        // Заповнення масиву випадковими числами та введення з клавiатури
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            array1D[i] = random.Next(1, 1000); // випадковi числа вiд 1 до 999

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine($"Введiть елемент [{i}, {j}] масиву:");
                double value;
                while (!double.TryParse(Console.ReadLine().Replace(',', '.'), out value)) // Перевiрка правильностi введення числа з плаваючою точкою
                {
                    Console.WriteLine("Введене значення не є числом. Спробуйте ще раз:");
                    Console.WriteLine($"Введiть елемент [{i}, {j}] масиву:");
                }
                array2D[i, j] = value;
            }
        }

        // Виведення одновимiрного масиву як матрицi
        Console.WriteLine("Одновимiрний масив:");
        for (int i = 0; i < array1D.Length; i++)
        {
            Console.Write(array1D[i] + " ");
            if ((i + 1) % n == 0) // Перехiд на новий рядок пiсля виведення кожного рядка матрицi
                Console.WriteLine();
        }
        Console.WriteLine();

        // Перевiрка наявностi добутку елементiв тризначним числом
        bool found1D = CheckForThreeDigitProduct(array1D);
        Console.WriteLine("Добуток елементiв одновимiрного масиву тризначним числом: " + (found1D ? "Так" : "Нi"));

        // Виведення двовимiрного масиву
        Console.WriteLine("Двовимiрний масив:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array2D[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Перевiрка наявностi добутку елементiв тризначним числом у двовимiрному масивi
        bool found2D = CheckForThreeDigitProduct(array2D);
        Console.WriteLine("Добуток елементiв двовимiрного масиву тризначним числом: " + (found2D ? "Так" : "Нi"));
    }

    static bool CheckForThreeDigitProduct(double[] arr)
    {
        double product = 1;
        foreach (double num in arr)
        {
            product *= num;
        }
        return product.ToString().Length == 3;
    }

    static bool CheckForThreeDigitProduct(double[,] arr)
    {
        double product = 1;
        foreach (double num in arr)
        {
            product *= num;
        }
        return product.ToString().Length == 3;
    }


static void Task2()
    {
        Console.WriteLine("Завдання 2:");
        Console.WriteLine("Введiть розмiрнiсть масиву:");
        int n = int.Parse(Console.ReadLine());

        double[] array = new double[n];

        Console.WriteLine("Введiть елементи масиву:");

        for (int i = 0; i < n; i++)
        {
            array[i] = double.Parse(Console.ReadLine());
        }

        int count = 0;
        for (int i = 1; i < n; i++)
        {
            if (array[i] > array[i - 1])
                count++;
        }

        Console.WriteLine($"Кiлькiсть елементiв, бiльших за попереднiй: {count}");
    }

    static void Task3()
    {
        Console.WriteLine("Завдання 3:");
        Console.WriteLine("Введiть розмiрнiсть масиву:");
        int n = int.Parse(Console.ReadLine());

        int[,] array = new int[n, n];

        Console.WriteLine("Введiть елементи масиву:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += array[i, n - i - 1];
        }

        Console.WriteLine($"Сума елементiв на побiчнiй дiагоналi: {sum}");
    }

    static void Task4()
    {
        Console.WriteLine("Завдання 4:");
        Console.WriteLine("Введiть кiлькiсть рядкiв масиву:");
        int n = int.Parse(Console.ReadLine());

        int[][] jaggedArray = new int[n][];

        Console.WriteLine("Введiть кiлькiсть елементiв у кожному рядку:");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Рядок {i + 1}: ");
            int m = int.Parse(Console.ReadLine());
            jaggedArray[i] = new int[m];
        }

        Console.WriteLine("Введiть елементи масиву:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j] = int.Parse(Console.ReadLine());
            }
        }

        int[] positiveCounts = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                if (jaggedArray[i][j] > 0)
                {
                    positiveCounts[i]++;
                }
            }
        }

        Console.WriteLine("Кiлькiсть додатних елементiв у кожному рядку:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Рядок {i + 1}: {positiveCounts[i]}");
        }
    }
}
