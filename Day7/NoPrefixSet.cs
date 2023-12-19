using System;
using System.Collections.Generic;

class Result
{
    /*
     * Complete the 'noPrefix' function below.
     *
     * The function accepts STRING_ARRAY words as a parameter.
     */

    public static void noPrefix(List<string> words)
    {
        TrieNode root = new TrieNode();

        foreach (string word in words)
        {
            if (!InsertWord(root, word))
            {
                Console.WriteLine($"BAD SET\n{word}");
                return;
            }
        }

        Console.WriteLine("GOOD SET");
    }

    private static bool InsertWord(TrieNode root, string word)
    {
        TrieNode currentNode = root;

        foreach (char c in word)
        {
            if (currentNode.Children[c - 'a'] == null)
            {
                currentNode.Children[c - 'a'] = new TrieNode();
            }
            else if (currentNode.Children[c - 'a'].IsEndOfWord)
            {
                return false; // Prefix found
            }

            currentNode = currentNode.Children[c - 'a'];
        }

        currentNode.IsEndOfWord = true;

        foreach (TrieNode child in currentNode.Children)
        {
            if (child != null)
            {
                return false; // Prefix found
            }
        }

        return true;
    }
}

class TrieNode
{
    public TrieNode[] Children { get; private set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = new TrieNode[26];
        IsEndOfWord = false;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> words = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string wordsItem = Console.ReadLine();
            words.Add(wordsItem);
        }

        Result.noPrefix(words);
    }
}
