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
            Console.WriteLine("Choose one of the options one to ten.");
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
        

    }
}
