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
     * Complete the 'gridChallenge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING_ARRAY grid as parameter.
     */
 
    public static string gridChallenge(List<string> grid)
    {
        int rows = grid.Count;
        int cols = grid[0].Length;
 
        // Convert each row to a char array and sort it lexicographically
        for (int i = 0; i < rows; i++)
        {
            char[] rowArray = grid[i].ToCharArray();
            Array.Sort(rowArray);
            grid[i] = new string(rowArray);
        }
 
        // Check if each column is lexicographically sorted
        for (int j = 0; j < cols; j++)
        {
            for (int i = 1; i < rows; i++)
            {
                if (grid[i][j] < grid[i - 1][j])
                {
                    return "NO";
                }
            }
        }
 
        // If all columns are lexicographically sorted, return "YES"
        return "YES";
    }
}
 
    
 
 
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        int t = Convert.ToInt32(Console.ReadLine().Trim());
 
        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
 
            List<string> grid = new List<string>();
 
            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }
 
            string result = Result.gridChallenge(grid);
 
            textWriter.WriteLine(result);
        }
 
        textWriter.Flush();
        textWriter.Close();
    }
}
 
