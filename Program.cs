using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fibonacci;
            using (FileStream reader = new FileStream("fibonacci.txt", FileMode.Open))
            {
                byte[] array = new byte[reader.Length];
                reader.Read(array, 0, array.Length);
                string data = Encoding.UTF8.GetString(array);
                fibonacci = data.Split(' ');
            }
            int[] fibonacciNumbers = new int[fibonacci.Length];
            fibonacciNumbers[0] = int.Parse(fibonacci[fibonacci.Length - 1]) + int.Parse(fibonacci[fibonacci.Length - 2]);
            fibonacciNumbers[1] = int.Parse(fibonacci[fibonacci.Length - 1]) + fibonacciNumbers[0];
            for (int i = 2; i < fibonacciNumbers.Length; i++)
            {
                fibonacciNumbers[i] = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
            }
            using (StreamWriter writer = new StreamWriter("fibonacci.txt", true))
            {
                for(int i = 0; i < fibonacciNumbers.Length; i++)
                {
                    writer.Write(" " + fibonacciNumbers[i]);
                }
            }

            string[] numbers;
            using (FileStream reader = new FileStream("INPUT.TXT", FileMode.Open))
            {
                byte[] array = new byte[reader.Length];
                reader.Read(array, 0, array.Length);
                string data = Encoding.UTF8.GetString(array);
                numbers = data.Split(' ');
            }
            int sum = int.Parse(numbers[0]) + int.Parse(numbers[1]);
            using (StreamWriter writer = new StreamWriter("OUTPUT.TXT"))
            {
                writer.Write(sum);
            }
        }
    }
}
