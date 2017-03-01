using System;
using System.Collections.Generic;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        var trie = new Trie();
        for (int a0 = 0; a0 < n; a0++)
        {
            string[] tokens_op = Console.ReadLine().Split(' ');
            string op = tokens_op[0];
            string contact = tokens_op[1];
            switch (op)
            {
                case "add":
                    trie.Add(contact);
                    break;
                case "find":
                    Console.WriteLine(trie.GetNode(contact)?.CountWords ?? 0);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}

public class TrieNode
{
    public bool IsTerminal { get; internal set; }
    public char Value { get; internal set; }
    private Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
    public int CountWords { get; internal set; } = 0;

    public TrieNode(char value = '\0', bool isTerminal = false)
    {
        Value = value;
        IsTerminal = isTerminal;
    }

    public IEnumerable<TrieNode> GetChildren()
    {
        return Children.Values;
    }

    public TrieNode GetChild(char c)
    {
        TrieNode result;
        Children.TryGetValue(c, out result);
        return result;
    }

    public void AddChild(char c)
    {
        if (!Children.ContainsKey(c))
            Children[c] = new TrieNode(c);
    }
}

public class Trie
{
    private TrieNode Root { get; set; } = new TrieNode();

    public void Add(string cad)
    {
        if (string.IsNullOrEmpty(cad))
            throw new InvalidOperationException();

        var current = Root;
        foreach (var c in cad)
        {
            current.CountWords++;
            TrieNode child = current.GetChild(c);
            if (child == null)
            {
                current.AddChild(c);
                child = current.GetChild(c);
            }
            current = child;
        }
        current.IsTerminal = true;
        current.CountWords = 1;
    }

    public TrieNode GetNode(string cad)
    {
        var current = Root;
        foreach (var c in cad)
        {
            var child = current.GetChild(c);
            if (child == null)
                return null;
            current = child;
        }
        return current;
    }
}