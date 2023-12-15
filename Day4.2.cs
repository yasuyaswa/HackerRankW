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
     * Complete the 'superDigit' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING n
     *  2. INTEGER k
     */
 
    public static int superDigit(string n, int k)
    {
        // Calculate the sum of digits of n
        long sum = n.Sum(c => (c - '0'));
 
        // Multiply the sum by k
        long multipliedSum = sum * k;
 
        // If multiplied sum is a single-digit number, return it
        if (multipliedSum < 10)
        {
            return (int)multipliedSum;
        }
        // Otherwise, recursively calculate the super digit of the multiplied sum
        else
        {
            return superDigit(multipliedSum.ToString(), 1);
        }
 
    }
 
}
 
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
 
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
 
        string n = firstMultipleInput[0];
 
        int k = Convert.ToInt32(firstMultipleInput[1]);
 
        int result = Result.superDigit(n, k);
 
        textWriter.WriteLine(result);
 
        textWriter.Flush();
        textWriter.Close();
    }
}
