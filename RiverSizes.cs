using System;
using System.Collections.Generic;
public class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[,] {{ 1, 0, 0, 1, 0 },
                                    { 1, 0, 1, 0, 0 },
                                    { 0, 0, 1, 0, 1 },
                                    { 1, 0, 1, 0, 1 },
                                    { 1, 0, 1, 1, 0 }};

        foreach (var size in RiverSizes(matrix))
        {
            Console.Write(size + " ");
        }

    }
    public static List<int> RiverSizes(int[,] matrix)
    {
        List<int> sizes = new List<int>();
        bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)]; // ziyaret edilen nodeları true setler.
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (visited[i, j]) // node ziyaret edildiyse sonraki i veya j değerine geçer.
                {
                    continue;
                }
                int currentRiverSize = 0; //river size değeri tanımlanır.
                Stack<int[]> nodesToExplore = new Stack<int[]>(); // gezilmemiş düğümleri tutan bir yığın
                nodesToExplore.Push(new int[] { i, j }); // i,j indexli node pushlar
                while (nodesToExplore.Count != 0) // stack boyutu 0 olmadığı sürece çalışan bir while döngüsü
                {
                    int[] currentNode = nodesToExplore.Pop();
                    i = currentNode[0];
                    j = currentNode[1];
                    visited[i, j] = true; // node ziyaret edilen listesine eklenir
                    if (matrix[i, j] == 1) //eğer i,j indexli node değeri 1 ise sayma komşularına bakılır
                    {
                        currentRiverSize++;
                        List<int[]> unvisitedNeighbors = new List<int[]>();
                        if (i > 0 && !visited[i - 1, j])
                        {
                            unvisitedNeighbors.Add(new int[] { i - 1, j });
                        }
                        if (i < matrix.GetLength(0) - 1 && !visited[i + 1, j])
                        {
                            unvisitedNeighbors.Add(new int[] { i + 1, j });
                        }
                        if (j > 0 && !visited[i, j - 1])
                        {
                            unvisitedNeighbors.Add(new int[] { i, j - 1 });
                        }
                        if (j < matrix.GetLength(1) - 1 && !visited[i, j + 1])
                        {
                            unvisitedNeighbors.Add(new int[] { i, j + 1 });
                        }
                        foreach (var neighbor in unvisitedNeighbors)
                        {
                            nodesToExplore.Push(neighbor);
                        }
                    }

                }
                if ((currentRiverSize > 0) && (!sizes.Contains(currentRiverSize)))
                // nehir uzunluğu 0 dan büyükse ve tekrar etmiyorsa sizes dizine eklenir.
                {
                    sizes.Add(currentRiverSize);
                }
            }
        }
        return sizes; // sizes dizisi geri döndürülür.
    }
}
