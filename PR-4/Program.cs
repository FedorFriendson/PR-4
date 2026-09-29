using System.Diagnostics;
using System.Globalization;

namespace PR_4;

class Program
{
    static void Main(string[] args)
    {
        int index = 0;
        int[] nums = new int[1000000];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = i + 1;
        }
        
        Console.Write("Какую переменную вы ищете: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Каким способом вы хотите найти переменную? Выберите цифру");
        Console.WriteLine("1 - Линейная; 2 - бинарная");
        Console.Write("Выбор: ");
        int num2 = int.Parse(Console.ReadLine());
        var timer = Stopwatch.StartNew();
        Console.Clear();
        if (num2 == 1)
        {
            
            index = line_seach(nums, num);
            
        }
        if (num2 == 2)
        {
            
            index =   binarySeach(nums, num);
        }
        else if(num2!=1 && num2 != 2)
        {
            Console.WriteLine("Ошибка");
        }
        timer.Stop();
        if (num2 == 1 || num2 == 2)
        {
            Console.WriteLine($"Индекс требуемой переменной: {index}");
        }
        Console.WriteLine($"Время анализа: {timer.ElapsedMilliseconds} мс");
    }

    static int line_seach(int[] nums, int num)
    {
        for (int i = 0; i < nums.Length; i++)
            if (nums[i] == num) return i;   // нашли — вернуть индекс
        return -1; 
    }

    static int binarySeach(int[] nums, int num)
    {
        int move = 0;
        int low = 0, high = nums.Length - 1;
        while (low <= high)
        {
            move++;
            Console.WriteLine($"Операций: {move}");
            int mid = (low + high) / 2;
            if (nums[mid] == num) return mid;       // нашли
            if (nums[mid] < num) low = mid + 1;     // искомое правее
            else high = mid - 1;                 // искомое левее
        }
        return -1;   
    }
}