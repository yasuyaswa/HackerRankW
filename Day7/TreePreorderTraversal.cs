using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Solution {
    public static List<string> preOrder(List<int> nodes) {
        var res = new List<string> ();
        if (nodes.Count == 0)
            return res;
        
        res.Add(nodes[0].ToString());
        var left = nodes.Where(x => x < nodes[0]).ToList();
        if (left.Count > 0)
            res.AddRange(preOrder(left));
            
        var right = nodes.Where(x => x > nodes[0]).ToList();
        if (right.Count > 0)
            res.AddRange(preOrder(right));
        return res;

}
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string input = Console.ReadLine();
        input = Console.ReadLine();
        var nodes = new List<int>();
        foreach(var part in input.Split(' ')){
            nodes.Add(Convert.ToInt32(part));
          //  Console.Error.WriteLine("part= {0}",part);
        }
        List<string> pre = preOrder(nodes);
        Console.WriteLine(String.Join(" ", pre.ToArray()));
    }
}
