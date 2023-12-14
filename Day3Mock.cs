using System;
using System.IO;

class Result
{
    /*
     * Complete the 'palindromeIndex' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as a parameter.
     */

    public static int palindromeIndex(string s)
    {
        int length = s.Length;

        for (int i = 0, j = length - 1; i < j; i++, j--)
        {
            if (s[i] != s[j])
            {
                // Check if removing character at i makes it a palindrome
                if (IsPalindrome(s, i + 1, j))
                {
                    return i;
                }
                // Check if removing character at j makes it a palindrome
                else if (IsPalindrome(s, i, j - 1))
                {
                    return j;
                }
                // If removing either i or j doesn't make it a palindrome, the string is not a valid palindrome
                else
                {
                    return -1;
                }
            }
        }

        return -1; // The string is already a palindrome
    }

    private static bool IsPalindrome(string s, int start, int end)
    {
        while (start < end)
        {
            if (s[start] != s[end])
            {
                return false;
            }
            start++;
            end--;
        }
        return true;
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
            string s = Console.ReadLine();

            int result = Result.palindromeIndex(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
