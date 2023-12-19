using System;
using System.Collections.Generic;
 
class Solution {
    public static int Cookies(int k, int[] A) {
        Array.Sort(A); // Sort the array initially
        int operations = 0;
        var pq = new PriorityQueue<int>();
 
        foreach (int sweetness in A) {
            pq.Enqueue(sweetness);
        }
 
        while (pq.Count >= 2) {
            if (pq.Peek() >= k) {
                return operations;
            }
 
            int leastSweet = pq.Dequeue();
            int secondLeastSweet = pq.Dequeue();
 
            int newSweetness = leastSweet + 2 * secondLeastSweet;
            pq.Enqueue(newSweetness);
            operations++;
        }
 
        if (pq.Count > 0 && pq.Peek() >= k) {
            return operations;
        }
 
        return -1; // If not possible
    }
 
    static void Main(string[] args) {
        string[] nk = Console.ReadLine().Trim().Split(' ');
        int n = Convert.ToInt32(nk[0]);
        int k = Convert.ToInt32(nk[1]);
        int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
        int result = Cookies(k, arr);
        Console.WriteLine(result);
    }
}
 
// Implementation of PriorityQueue
public class PriorityQueue<T> where T : IComparable<T> {
    private List<T> heap;
 
    public int Count {
        get { return heap.Count; }
    }
 
    public PriorityQueue() {
        heap = new List<T>();
    }
 
    public void Enqueue(T item) {
        heap.Add(item);
        int i = heap.Count - 1;
        while (i > 0) {
            int parent = (i - 1) / 2;
            if (heap[parent].CompareTo(heap[i]) <= 0) break;
            T temp = heap[i];
            heap[i] = heap[parent];
            heap[parent] = temp;
            i = parent;
        }
    }
 
    public T Dequeue() {
        if (heap.Count == 0) throw new InvalidOperationException("Priority queue is empty");
        int lastIndex = heap.Count - 1;
        T frontItem = heap[0];
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);
 
        --lastIndex;
        int parent = 0;
        while (true) {
            int leftChild = parent * 2 + 1;
            if (leftChild > lastIndex) break;
            int rightChild = leftChild + 1;
            int minChild = leftChild;
            if (rightChild <= lastIndex && heap[rightChild].CompareTo(heap[leftChild]) < 0) minChild = rightChild;
            if (heap[parent].CompareTo(heap[minChild]) <= 0) break;
            T temp = heap[parent];
            heap[parent] = heap[minChild];
            heap[minChild] = temp;
            parent = minChild;
        }
        return frontItem;
    }
 
    public T Peek() {
        if (heap.Count == 0) throw new InvalidOperationException("Priority queue is empty");
        return heap[0];
    }
}
