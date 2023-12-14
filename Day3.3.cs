using System;
using System.IO;

class Result
{
    /*
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
    {
        int alphabetSize = 26;
        char[] text = s.ToCharArray();
        System.Text.StringBuilder encryptedText = new System.Text.StringBuilder();

        if (k > alphabetSize)
        {
            k = k % alphabetSize;
        }

        for (int i = 0; i < text.Length; i++)
        {
            char letter = text[i];
            char encryptedLetter = EncryptLetter(letter, k);
            encryptedText.Append(encryptedLetter);
        }

        return encryptedText.ToString();
    }

    private static char EncryptLetter(char letter, int k)
    {
        if (char.IsLetter(letter))
        {
            char baseLetter = char.IsUpper(letter) ? 'A' : 'a';
            return (char)((letter - baseLetter + k) % 26 + baseLetter);
        }
        return letter;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
