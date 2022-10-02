
using System.Net.Security;
using System.Runtime.Serialization;

namespace ConsoleApp18
{
    class Program
    {
        public static void Swap(ref int a , ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        public static void Quick(int[] ints, int min, int max) 
        {
            if (min >= max) return;

            var pilar = QuickSort(ints, min, max); 
            Quick(ints, min, pilar - 1);
            Quick(ints, pilar+1, max);
        }
        public static int QuickSort(int[] ints, int min, int max)
        {
            var pilar = min - 1;

            for (int i = min; i < max; i++)
                if (ints[i] < ints[max]) Swap(ref ints[i], ref ints[++pilar]);
            Swap(ref ints[max], ref ints[++pilar]);

            return pilar;
        }
        public static void Merge(int[] ints)
        {
            if (ints.Length < 2) return;

            int[] left= new int[ints.Length/2];
            int[] right = new int[ints.Length - ints.Length/2];

            for (int i = 0; i < ints.Length/2; i++)
                left[i] = ints[i];
            for (int i = ints.Length/2; i < ints.Length ; i++)
                right[i - ints.Length/2] = ints[i];
            Merge(left);
            Merge(right);
            MergeSort(ints, left, right);
        }

        public static void MergeSort(int[] ints, int[] left, int[] right)
        {
            int Eints = 0;
            int Eleft = 0;
            int Eright = 0;

            while(left.Length > Eleft && right.Length > Eright)
            {
                if (left[Eleft] < right[Eright]) ints[Eints++] = left[Eleft++];
                else ints[Eints++] = right[Eright++];
            }
            while(left.Length > Eleft) ints[Eints++] = left[Eleft++];
            while(right.Length > Eright) ints[Eints++] = right[Eright++];

        }

        public static void ShellSort(int[] ints)
        {
            int step = ints.Length/2;

            while(step != 0)
            {
                for (int i = step; i < ints.Length; i++)
                {
                    int j = i;
                    while(j >= step && ints[j-step] > ints[j])
                    {
                        Swap(ref ints[j],ref ints[j - step]);
                        j -= step;
                    }

                }
                step /= 2;
            }
        }

        public static void BubleSort(int[] ints)
        {
            for (int i = 0; i < ints.Length-1; i++)
            {
                for (int j = i; j < ints.Length; j++)
                    if (ints[i] > ints[j]) Swap(ref ints[i], ref ints[j]);
            }
        }

        public static void InsertionSort(int[] ints)
        {
            int index = 0;
            for (int i = 0; i < ints.Length - 1; i++)
            {
                for (int j = i; j < ints.Length; j++)
                    if (ints[i] > ints[j]) index = j;
                Swap(ref ints[i], ref ints[index]);
            }
        }

        public static void Main()
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            Random random = new Random();
            int[] a = new int[100] ;

            for (int i = 0; i < a.Length; i++)
                a[i] = random.Next(0,10);

            InsertionSort(a);

            for (int i = 0; i < a.Length; i++)
                Console.Write($"{a[i]} ");

             
        }
    }
}