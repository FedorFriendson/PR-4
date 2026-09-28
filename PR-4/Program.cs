using System.Diagnostics;
using System.Globalization;

namespace PR_4;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = new int[1000000];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = i + 1; // Заполняет от 1 до 1000
        }
        
        Console.Write("Какую переменную вы ищете: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Каким способом вы хотите найти переменную? Выберите цифру");
        Console.WriteLine("1 - Линейная; 2 - бинарная");
        Console.Write("Выбор: ");
        int num2 = int.Parse(Console.ReadLine());
        var timer = Stopwatch.StartNew();
        if (num2 == 1)
        {
            line_seach(nums, num);
            
        }
        if (num2 == 2)
        {
            binarySeach(nums, num);
        }
        else if(num2!=1 && num2 != 2)
        {
            Console.WriteLine("Ошибка");
        }
        timer.Stop();
        Console.WriteLine($"Время анализа: {timer.ElapsedMilliseconds} мс");
    }

    static void line_seach(int[] nums, int num)
    {
        bool found = false;

        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine($"сравнение  №{i}");
            if (nums[i] == num)
            {
                found = true;
                int index = Array.IndexOf(nums, num);
                Console.WriteLine($"Линейный поиск: найдено на позиции {index}");
                Console.WriteLine($"Сравнений: {i+1}");
               
            }
        }

        if (!found)
        {
            Console.WriteLine($"Линейный поиск: значение {num} не найдено.");
        }
    }

    static void binarySeach(int[] nums, int num)
    {
        bool found = false;
        int low = 0;
        int high = nums.Length - 1;
        int comparisons = 0;

        while (low <= high)
        {
            
            comparisons++;
            Console.WriteLine($"сравнение  №{comparisons}");
            int mid = (low + high) / 2;

            if (nums[mid] == num)
            {
                found = true;
                Console.WriteLine($"Бинарный поиск: найдено на позиции {mid}");
                Console.WriteLine($"Сравнений: {comparisons}");
                Console.WriteLine($"Время анализа: ");
                Console.WriteLine("Нажмите, чтобы продолжить");
                Console.ReadKey();
                break;
            }

            if (nums[mid] < num)
            {
                low = mid + 1; // Сдвигаем левую границу вправо
            }
            else
            {
                high = mid - 1; // Сдвигаем правую границу влево
            }
        }

        if (!found)
        {
            Console.WriteLine($"Бинарный поиск: значение {num} не найдено.");
            Console.WriteLine($"Сравнений: {comparisons}");
        }
    }
}