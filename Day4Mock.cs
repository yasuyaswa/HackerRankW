using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'truckTour' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY petrolpumps as a parameter.
     */

    public static int truckTour(List<List<int>> petrolpumps)
    {
        int n = petrolpumps.Count;
        int start = 0;
        int total = 0;
        int tank = 0;

        for (int i = 0; i < n; i++)
        {
            int petrol = petrolpumps[i][0];
            int distance = petrolpumps[i][1];

            total += petrol - distance;

            if (total < 0)
            {
                start = i + 1;
                total = 0;
            }
        }

        return start;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> petrolpumps = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            petrolpumps.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(petrolpumpsTemp => Convert.ToInt32(petrolpumpsTemp)).ToList());
        }

        int result = Result.truckTour(petrolpumps);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
