
using System;
using System.Collections.Generic;
using System.Linq;
class Result
{
    /*
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as a parameter.
     */
    public static void miniMaxSum(List<int> arr)
    {
        long sum = 0;
        arr.Sort();
        // Calculate the sum of all elements except the last one
        for (int i = 0; i < arr.Count - 1; i++)
        {
            sum += arr[i];
        }
        Console.Write(sum);
        Console.Write(" ");
        // Reset sum and calculate the sum of all elements except the first one
        sum = 0;
        for (int i = 1; i < arr.Count; i++)
        {
            sum += arr[i];
        }
        Console.Write(sum);
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
        Result.miniMaxSum(arr);
    }
}
