using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERIESanalyzer
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            List<int> numbers;

            if (IsValidSeriesArgs(args))
            {
                
                numbers = StringToInt(args);
            }
            else
            {
                numbers = GetUserNumbers();
            }
            int userchoise;
            do
            {
                ShwoMenue();
                Console.WriteLine("Choose one of the options one to ten.");
                string input = Console.ReadLine();
                if (int.TryParse(input, out userchoise))
                {
                    switch (userchoise)
                    {
                        case 1:
                            numbers=GetUserNumbers();
                            break;
                        case 2:
                            PrintOrignalseries(numbers);
                            break;
                        case 3:
                            PrintRversedseries(numbers);
                            break;
                        case 4:
                            GetSorted(numbers);
                            break;
                        case 5:
                            Console.WriteLine($"The highest number is: {GetMaxNumber(numbers)}");
                            break;
                        case 6:
                            Console.WriteLine($"The lowest number is: {GetMinNumber(numbers)}");
                            break;
                        case 7:
                            Console.WriteLine($"The series average is: { GetAverage(numbers)}");
                            break;
                        case 8:
                            Console.WriteLine($"The series contains: {GetCountItems(numbers)} entries.");
                            break;
                        case 9:
                            Console.WriteLine($"the sum is: { Getsum(numbers)}");
                            break;
                        case 10:
                            Console.WriteLine("goodbye");
                            break;
                        default:
                            Console.WriteLine("invalid choise please select number 1-10:");
                            break;



                    }
                }
                else
                {
                    Console.WriteLine("invalid choise please select number 1-10:");
                }
                
            }
            while (userchoise != 10);
            
        }
        static bool IsValidSeriesArgs(string[] args)
        {
            if (args.Length < 3)
            {
                return false;
            }
            foreach (string item in args)
            {
                if (!int.TryParse(item, out int num) || num <0 )
                {
                    return false ;
                }
            }
            return true;
        }
        static void ShwoMenue()
        {
            Console.WriteLine("1. Input a new series (replaces the current one)");
            Console.WriteLine("2. Display the series (original order)");
            Console.WriteLine("3. Display the series in reverse order");
            Console.WriteLine("4.Display the series in sorted order(low to high)");
            Console.WriteLine("5. Display the maximum value");
            Console.WriteLine("6. Display the minimum value");
            Console.WriteLine("7. Display the average value");
            Console.WriteLine("8. Display the number of elements");
            Console.WriteLine("9. Display the sum of the series");
            Console.WriteLine("10. Exit");
            
        }
        static List<int> StringToInt(string[] listy)
        {
            List<int>resulte = new List<int>();
            foreach (string item in listy)
            {
                int num =int.Parse(item );
                resulte.Add(num);
            }
            return resulte;
        }
        static List<int> GetUserNumbers()
        {

            while (true)
            {
                Console.WriteLine("Choose at least three positive numbers separated by a space. ");
                string input = Console.ReadLine();
                string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (IsValidSeriesArgs(parts))
                {
                    return StringToInt(parts);

                }
                else
                {
                     Console.WriteLine("invalid number try again.");
                }
                

            }
            

        }
        static void PrintOrignalseries(List<int> numbers)
        {
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("");
        }
        static void PrintRversedseries(List<int> numbers)
        {
            for (int i= numbers.Count-1;i>=0; i--)
            {
                Console.Write(numbers[i]+ " ");
            }
            Console.WriteLine();
            
        }
        static int Getsum(List<int> numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;

        }
        static double GetAverage(List<int> numbers)
        {
            return (double)Getsum(numbers)/numbers.Count;
        }
        static int GetMaxNumber(List<int> numbers)
        {
            int max = 0;
            foreach(int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }
        static int GetMinNumber(List<int> numbers)
        {
            int min = GetMaxNumber(numbers);
            foreach( int num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }
        static int GetCountItems(List<int> numbers)
        {
            return numbers.Count;
        }
        static void GetSorted(List<int> numbers)
        {
            Console.Write("The sorted series is ");
            List<int> sorted = new List<int>(numbers);
            for (int i = 0; i < sorted.Count; i++)
            {
                for(int j = 0;j< sorted.Count -i - 1; j++)
                {
                    if (sorted[j] > sorted[j + 1])
                    {
                        int temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }
            foreach (int num in sorted)
            {
                Console.Write(num+ ",");
            }
            Console.WriteLine();
            
        }


    }
}
