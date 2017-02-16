using System;
using System.Collections.Generic;
class Queue<T> {
    Stack<T> items = new Stack<T>();
    Stack<T> auxStack = new Stack<T>();

    private void DropItems(Stack<T> stack1, Stack<T> stack2) {
        while (stack1.Count > 0) {
            stack2.Push(stack1.Pop());
        }
    }

    private void PrepareItemsStack() {
        if (items.Count == 0) {
            DropItems(auxStack, items);
        }
    }

    public T Top() {
        PrepareItemsStack();
        if (items.Count == 0) {
            throw new InvalidOperationException();
        }
        return items.Peek();
    }

    public int Count { get { return items.Count + auxStack.Count; } }

    public T Dequeue() {
        PrepareItemsStack();
        if (items.Count == 0) {
            throw new InvalidOperationException();
        }
        return items.Pop();
    }

    public void Enqueue(T item) {
        auxStack.Push(item);
    }
}

class Solution {
    static void Main(String[] args) {
        int n = int.Parse(Console.ReadLine());
        Queue<string> myQueue = new Queue<string>();
        while (n-- > 0) {
            string[] input_tokens = Console.ReadLine().Split(' ');
            switch (input_tokens[0]) {
                case "1":
                    myQueue.Enqueue(input_tokens[1]);
                    break;
                case "2":
                    myQueue.Dequeue();
                    break;
                default:
                    Console.WriteLine(myQueue.Top());
                    break;
            }
        }
    }
}