using System;
using System.Collections.Generic;
 
class Solution {
    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        Stack<string> stack = new Stack<string>();
        string text = "";
 
        for (int i = 0; i < q; i++) {
            string[] operation = Console.ReadLine().Split();
 
            switch (operation[0]) {
                case "1":
                    stack.Push(text);
                    text += operation[1];
                    break;
 
                case "2":
                    stack.Push(text);
                    int k = Convert.ToInt32(operation[1]);
                    text = text.Substring(0, text.Length - k);
                    break;
 
                case "3":
                    int idx = Convert.ToInt32(operation[1]) - 1;
                    Console.WriteLine(text[idx]);
                    break;
 
                case "4":
                    if (stack.Count > 0)
                        text = stack.Pop();
                    break;
 
                default:
                    break;
            }
        }
    }
}
 
