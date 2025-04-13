using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BucketSort
{
    internal class Program
    {
        public static int[] bucketSort(int[] arr)
        {
            int range = 5;
            int max = int.MinValue;
            int min = int.MaxValue;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            //int[] buckets = new int[max / range];
            
            List<int>[] buckets = new List<int>[max / range];
            for(int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }
            for(int i = 0; i < arr.Length; i++)
            {
                
                buckets[arr[i] / range - 1].Add(arr[i]);
            }

            for(int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = InsertionSort(buckets[i].ToArray<int>()).ToList();
            }

            for(int i = 0; i < buckets.Length; i++)
            {
                for(int j = 0; j < buckets[i].Count; j++)
                {
                    arr[i] = buckets[i][j];
                }
            }

            return arr;


        }
        static T[] InsertionSort<T>(T[] values) where T : IComparable<T>
        {
            T a = default;
            T b = default;

            for (int i = 1; i < values.Length; i++)
            {
                int z = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (values[z].CompareTo(values[j]) < 0)
                    {
                        T prevValue = values[j];
                        values[j] = values[z];
                        values[z] = prevValue;
                    }
                    else
                    {
                        break;
                    }
                    z--;
                }



            }
            return values;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[100];
            Random random = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = (random.Next(0, 100));
            }

            arr = bucketSort(arr);

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr);
            }
        }
    }
}
