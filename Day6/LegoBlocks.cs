using System;
 
class Result
{
    const int MOD = 1000000007;
 
    public static int legoBlocks(int n, int m)
    {
        // Initialize a DP array to store the number of ways to build the wall for each width
        long[] ways = new long[m + 1];
        ways[0] = 1;
 
        // Store the count of each block's combination for given width 'i'
        for (int i = 1; i <= m; i++)
        {
            // Initialize the count of ways for each width 'i'
            ways[i] = 0;
 
            // For each block type (4 different block types)
            for (int j = 1; j <= 4; j++)
            {
                // If the current block size doesn't exceed the current width 'i'
                if (i >= j)
                {
                    // Calculate the number of ways for current width 'i' using block size 'j'
                    ways[i] += ways[i - j];
                    ways[i] %= MOD;
                }
            }
        }
 
        // Now, calculate the total ways to build the wall of height 'n' and width 'm'
        long[] power = new long[m + 1];
        for (int i = 0; i <= m; i++)
        {
            power[i] = modPow(ways[i], n);
        }
 
        // DP to count valid wall formations
        long[] dp = new long[m + 1];
        dp[0] = 1;
 
        for (int i = 1; i <= m; i++)
        {
            dp[i] = power[i];
 
            for (int j = 1; j < i; j++)
            {
                dp[i] -= (dp[j] * power[i - j]) % MOD;
                dp[i] = (dp[i] + MOD) % MOD;
            }
        }
 
        return (int)dp[m];
    }
 
    private static long modPow(long x, long y)
    {
        long result = 1;
        while (y > 0)
        {
            if (y % 2 == 1)
            {
                result = (result * x) % MOD;
            }
            x = (x * x) % MOD;
            y /= 2;
        }
        return result;
    }
}
 
class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());
 
        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int m = Convert.ToInt32(firstMultipleInput[1]);
 
            int result = Result.legoBlocks(n, m);
            Console.WriteLine(result);
        }
    }
}
