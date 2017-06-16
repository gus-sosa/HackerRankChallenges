using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock_and_Anagrams
{
    public class Trie
    {
        internal class Node
        {
            private bool _terminal;

            public Node()
            {
                Root = true;
            }

            public Node(Node parent, IEnumerable<Tuple<char, Node>> children = null)
            {
                Root = false;
                Parent = parent;
                if (children != null)
                    foreach (var item in children)
                        Children[item.Item1] = item.Item2;
            }

            public char Value { get; set; }
            public int Count { get; private set; }
            public Node Parent { get; set; }
            public bool Root { get; }
            public bool Terminal
            {
                get
                {
                    return _terminal;
                }
                set
                {
                    _terminal = value;
                    Count++;
                }
            }
            public IDictionary<char, Node> Children { get; set; } = new Dictionary<char, Node>();
        }

        private Node Root { get; set; } = new Node();


        /// <summary>
        /// Add a word
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>
        /// the number of instances of <paramref name="cad"/> in the trie.
        /// If returns 0 that means it did not add <paramref name="cad"/>
        /// </returns>
        public int Add(string cad)
        {
            if (string.IsNullOrEmpty(cad))
                return 0;

            Node currentNode = Root;
            for (int i = 0; i < cad.Length; i++)
            {
                char currentChar = cad[i];
                if (currentNode.Children.ContainsKey(currentChar))
                    currentNode = currentNode.Children[currentChar];
                else
                {
                    var newNode = new Node(currentNode) { Value = currentChar };
                    currentNode.Children.Add(currentChar, newNode);
                    currentNode = newNode;
                }
            }

            currentNode.Terminal = true;
            return currentNode.Count;
        }
    }

    class Program
    {
        static int sherlockAndAnagrams(string s)
        {
            var trie = new Trie();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
                for (int j = i; j < s.Length; j++)
                {
                    char[] substr = s.Substring(i, j - i + 1).ToArray();
                    Array.Sort(substr);
                    var tmpCount = trie.Add(new string(substr));
                    count += tmpCount == 1 ? 0 : tmpCount - 1;
                }

            return count;
        }

        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string s = Console.ReadLine();
                int result = sherlockAndAnagrams(s);
                Console.WriteLine(result);
            }
        }
    }
}
