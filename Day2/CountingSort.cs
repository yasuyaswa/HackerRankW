
using System;
using System.Collections.Generic;
class Result
{
    /*
     * Complete the 'countingSort' function below.
     *
     * The function is expected to return a List<int>.
     * The function accepts List<int> arr as a parameter.
     */
    public static List<int> countingSort(List<int> arr)
    {
        List<int> result = new List<int>();
        int s = 0, s1 = 0;
        result.Add(0);
        foreach (int i in arr)
        {
            if (s < i)
            {
                for (int j = 1; j <= i - s; j++)
                {
                    s1 = s1 + 1;
                    if (s1 < i)
                    {
                        result.Add(0);
                    }
                    else
                    {
                        result.Add(1);
                    }
                }
                s = s1;
            }
            else
            {
                result[i]++;
            }
        }
        for (int k = 0; k < 100 - s - 1; k++)
        {
            result.Add(0);
        }
        return result;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        int n = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        List<int> result = Result.countingSort(arr);
        textWriter.WriteLine(String.Join(" ", result));
        textWriter.Flush();
        textWriter.Close();
    }
}
