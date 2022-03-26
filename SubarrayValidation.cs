using System;
using System.Collections.Generic;

namespace SubarrayValidation
{
    internal class Program
    {

        public static bool SubarrayValidation(List<int> array, List<int> sequence)
        {
            bool isSubarray = true; 
			//isSubarray değişkeni ile dizinin altdizi olup olmamasını kotrol eder ve return ifadesi olarak bu değişkeni kullanırız.
            for (int i = 0; i < sequence.Count; i++)
            {
                if (!array.Contains(sequence[i]))
                {
                    isSubarray = false; 
					//Eğer array de sequence dizisinin i indexli değeri bulunmazsa isSubarray değişkenini false setleriz. Dizi altdizi değildir anlamı taşır.
                }
            }
            return isSubarray; 
        }

        static void Main(string[] args)
        {
            List<int> array = new List<int>() { 5, 1, 22, 25, 6, -1, 8, 10 };
            List<int> sequence = new List<int>() { 1, 6, -1, 10 };

            if (SubarrayValidation(array, sequence))
            {
                Console.WriteLine("Array is a subarray.");
            }
            else
            {
                Console.WriteLine(" Array isn't a subarray..");
            }
        }
    }
}
