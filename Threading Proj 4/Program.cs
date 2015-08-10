using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Threading_Proj_4
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a word to be inserted in the Randomized list: ");
            string word = Console.ReadLine();
            Console.WriteLine("Input a size for the list (will be in multiples of 10): ");
            int size = int.Parse(Console.ReadLine());

            List<string> list = GenerateAndShuffleList(word, size);

            Stopwatch naiveStopwatch = new Stopwatch();
            naiveStopwatch.Start();
            NaiveSearch(list, word);
            naiveStopwatch.Stop();
            TimeSpan naiveTS = naiveStopwatch.Elapsed;
            Console.WriteLine(naiveTS.ToString());


            Console.ReadKey();
           

            
        }

        static void  NaiveSearch (List<string> list, string word)
        {
            int index;

            
            for(int i=0; i < list.Count; i++)
            {
                if (list[i] == word)
                {
                    index =  i; 
                }
            }
        }

        static List<string> GenerateAndShuffleList(string word, int size)
        {
            size *= 10;
            List<string> list = new List<string>();
            list.Add(word);

            for (int i = 1; i < size; i++)
            {
                list.Add(RandomString(word.Length));
            }

            Console.WriteLine("Your list of generated strings");
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            int k = 3;
            while (k > 0)
            {
                k--;
                list.Shuffle();
            }

            Console.WriteLine("List Shuffled 3 times:");
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }

            return list; 
        }

        static string RandomString(int wordLength)
        {
            string fileName = Path.GetRandomFileName();
            fileName = fileName.Replace(".", "");
            fileName = fileName.Remove(wordLength); 
            return fileName; 
        }

        static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;  
            while (n > 1)
            {
                n--;  
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
