
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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */
    public static string timeConversion(string s)
    {
        string[] subStrings = s.Split(':');
    int hour = int.Parse(subStrings[0]);
    if (s[8] == 'A' && hour == 12) {
        hour = 0;
    } else if (s[8] == 'P' && hour != 12) {
        hour += 12;
    }
    return hour.ToString("D2") + ":" + subStrings[1] + ":" + subStrings[2].Substring(0, 2);
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string s = Console.ReadLine();
        string result = Result.timeConversion(s);
        textWriter.WriteLine(result);
        textWriter.Flush();
        textWriter.Close();
    }
}
