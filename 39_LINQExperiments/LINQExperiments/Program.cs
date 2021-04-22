using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Make(100);
            DrawColumn(collection.ToList(), "Nums", 0);
            DrawColumn(collection.Where(s => s % 2 == 0).ToList(), "Evens", 9);
            DrawColumn(collection.Where(s => s % 2 == 1).ToList(), "Odds", 18);
            DrawColumn(collection.Where(s => s > 50).ToList(), "Big", 27);
            DrawColumn(collection.Where(s => s < 50).ToList(), "Small", 36);
            Console.SetCursorPosition(0, 101);
        }

        static int[] Make(int size) 
        {
            var arr = new int[size];
            for (int i = 0; i < size; i++) 
            {
                arr[i] = i;
            }
            return arr;
        }

        static void DrawColumn(List<int> data, string label, int xPos) 
        {
            Console.SetCursorPosition(xPos, 0);
            Console.Write($"{label,8}");
            foreach (int num in data) 
            {
                Console.SetCursorPosition(xPos, num+1);
                Console.Write($"{num,8}");
            }
        }
    }
}
