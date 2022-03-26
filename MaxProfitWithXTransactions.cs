using System;
public class Program
{
    static void Main(string[] args)
    {
       
        int[] prices = new int[] { 5, 11, 3, 50, 60, 90 };
        int x = 2;

        int[,] profits;
        Console.WriteLine(MaxProfitWithXTransactions(prices, x, out profits));
      
    }
    public static int MaxProfitWithXTransactions(int[] prices, int x, out int [,] profits)
    {
         profits = new int[x + 1, prices.Length]; 
        for (int i = 1; i <= x; i++)
        {
            int maxDiff = -prices[0]; // max fark setlenir.
            for (int j = 1; j < prices.Length; j++)
            {
                profits[i, j] = Math.Max(profits[i, j - 1], prices[j] + maxDiff); // kar hesabı burda yapılır ve profits dizisine atanır.
                maxDiff = Math.Max(maxDiff, profits[i - 1, j] - prices[j]); // max farkı tekrar belirleriz.
            }
        }
        return profits[x, prices.Length - 1]; // iterasyonlar sonunda elde ettiğimiz maximum karı döndürürüz.
    }
}
