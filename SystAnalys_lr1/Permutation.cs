using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticNumberSearch
{
    public class Permutation
    {
        public static List<List<T>> GetAllPermutations<T>(List<T> list1)
        {
            var permutations = new List<List<T>>();
            List<T> list = list1.ToList<T>();
            list.Sort();

            while (true)
            {
                permutations.Add(new List<T>(list));

                int i = list.Count - 2;
                while (i >= 0 && Comparer<T>.Default.Compare(list[i], list[i + 1]) >= 0)
                {
                    i--;
                }

                if (i < 0)
                {
                    break;
                }

                int j = list.Count - 1;
                while (j > i && Comparer<T>.Default.Compare(list[j], list[i]) <= 0)
                {
                    j--;
                }

                Swap(list, i, j);
                Reverse(list, i + 1, list.Count - 1);
            }

            return permutations;
        }

        private static void Swap<T>(List<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        private static void Reverse<T>(List<T> list, int start, int end)
        {
            while (start < end)
            {
                Swap(list, start, end);
                start++;
                end--;
            }
        }
    }
}
