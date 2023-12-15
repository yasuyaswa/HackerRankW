using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
 
 
 
class Result
{
 
    /*
     * Complete the 'bfs' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     *  3. 2D_INTEGER_ARRAY edges
     *  4. INTEGER s
     */
 
    public static List<int> bfs(int n, int m, List<List<int>> edges, int s)
    {
        Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
        for (int i = 1; i <= n; i++)
        {
            adjacencyList[i] = new List<int>();
        }
 
        // Build adjacency list from edges
        foreach (var edge in edges)
        {
            adjacencyList[edge[0]].Add(edge[1]);
            adjacencyList[edge[1]].Add(edge[0]);
        }
 
        // Perform BFS
        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
        List<int> distances = new List<int>(new int[n]);
 
        queue.Enqueue(s);
        visited.Add(s);
 
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
 
            foreach (int neighbor in adjacencyList[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                    distances[neighbor - 1] = distances[current - 1] + 6;
                }
            }
        }
 
        // Set unreachable nodes to -1
        for (int i = 0; i < distances.Count; i++)
        {
            if (distances[i] == 0)
            {
                distances[i] = -1;
            }
        }
 
        // Remove distance to starting node
        distances.RemoveAt(s - 1);
 
        return distances;
 
    }
 
}
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        int q = Convert.ToInt32(Console.ReadLine().Trim());
 
        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
            int n = Convert.ToInt32(firstMultipleInput[0]);
 
            int m = Convert.ToInt32(firstMultipleInput[1]);
 
            List<List<int>> edges = new List<List<int>>();
 
            for (int i = 0; i < m; i++)
            {
                edges.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(edgesTemp => Convert.ToInt32(edgesTemp)).ToList());
            }
 
            int s = Convert.ToInt32(Console.ReadLine().Trim());
 
            List<int> result = Result.bfs(n, m, edges, s);
 
            textWriter.WriteLine(String.Join(" ", result));
        }
 
        textWriter.Flush();
        textWriter.Close();
    }
}
