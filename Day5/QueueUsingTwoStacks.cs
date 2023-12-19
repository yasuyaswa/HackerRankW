using System;
using System.Collections.Generic;
 
class Solution {
    static void Main(String[] args) {
        int queries = Convert.ToInt32(Console.ReadLine());
 
        Stack<int> enqueueStack = new Stack<int>();
        Stack<int> dequeueStack = new Stack<int>();
 
        for (int i = 0; i < queries; i++) {
            string[] query = Console.ReadLine().Split(' ');
            int operation = Convert.ToInt32(query[0]);
 
            switch (operation) {
                case 1:
                    int valueToEnqueue = Convert.ToInt32(query[1]);
                    enqueueStack.Push(valueToEnqueue);
                    break;
 
                case 2:
                    DequeueFromQueue(enqueueStack, dequeueStack);
                    break;
 
                case 3:
                    PrintFrontOfQueue(enqueueStack, dequeueStack);
                    break;
            }
        }
    }
 
    static void DequeueFromQueue(Stack<int> enqueueStack, Stack<int> dequeueStack) {
        if (dequeueStack.Count == 0) {
            while (enqueueStack.Count > 0) {
                dequeueStack.Push(enqueueStack.Pop());
            }
        }
        if (dequeueStack.Count > 0) {
            dequeueStack.Pop();
        }
    }
 
    static void PrintFrontOfQueue(Stack<int> enqueueStack, Stack<int> dequeueStack) {
        if (dequeueStack.Count == 0) {
            while (enqueueStack.Count > 0) {
                dequeueStack.Push(enqueueStack.Pop());
            }
        }
        if (dequeueStack.Count > 0) {
            Console.WriteLine(dequeueStack.Peek());
        }
    }
}
