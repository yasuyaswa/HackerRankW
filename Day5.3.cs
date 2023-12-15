using System;
using System.Collections.Generic;
 
class Result
{
    /*
     * Complete the 'isBalanced' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */
 
    public static string isBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();
 
        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return "NO";
                }
 
                char top = stack.Pop();
 
                if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                {
                    return "NO";
                }
            }
        }
 
        return stack.Count == 0 ? "YES" : "NO";
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
            string s = Console.ReadLine();
 
            string result = Result.isBalanced(s);
 
            textWriter.WriteLine(result);
        }
 
        textWriter.Flush();
        textWriter.Close();
    }
}
