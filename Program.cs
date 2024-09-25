using System;
using System.Diagnostics;

namespace SearchAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a sorted array of 10,000 random numbers
            int[] sortedArray = GenerateSortedArray(10000);

            // Select a random target from within the generated sorted array to ensure it's present
            Random random = new Random();
            int target = sortedArray[random.Next(0, sortedArray.Length)];

            Console.WriteLine($"Searching for {target} in a sorted array of 10,000 elements.");

            // Linear Search
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool linearResult = LinearSearch(sortedArray, target);
            stopwatch.Stop();
            Console.WriteLine($"Linear Search Result: {linearResult}, Time: {stopwatch.Elapsed.TotalMilliseconds} ms");

            // Binary Search
            stopwatch.Restart();
            bool binaryResult = BinarySearch(sortedArray, target, 0, sortedArray.Length - 1);
            stopwatch.Stop();
            Console.WriteLine($"Binary Search Result: {binaryResult}, Time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }

        // Linear Search Method
        static bool LinearSearch(int[] array, int target)
        {
            foreach (int element in array)
            {
                if (element == target)
                {
                    return true;
                }
            }
            return false;
        }

        // Binary Search Method
        static bool BinarySearch(int[] array, int target, int low, int high)
        {
            if (low > high)
            {
                return false;
            }

            int mid = (low + high) / 2;

            if (array[mid] == target)
            {
                return true;
            }
            else if (array[mid] > target)
            {
                return BinarySearch(array, target, low, mid - 1);
            }
            else
            {
                return BinarySearch(array, target, mid + 1, high);
            }
        }

        // Method to generate a sorted array of random integers
        static int[] GenerateSortedArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, size * 10);
            }

            Array.Sort(array);
            return array;
        }
    }
}
