using System;
using System.Collections.Generic;

class MinHeap<T> where T : IComparable
{
    List<T> elements;

    public MinHeap()
    {
        elements = new List<T>();
    }

    public MinHeap(int capacity)
    {
        elements = new List<T>(capacity);
    }

    public void Add(T item)
    {
        elements.Add(item);
        Heapify();
    }

    public void Delete(T item)
    {
        int i = elements.IndexOf(item);
        int last = elements.Count - 1;

        elements[i] = elements[last];
        elements.RemoveAt(last);
        Heapify();
    }

    public T Top
    {
        get
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty");
            }
            return elements[0];
        }
    }

    public int Count
    {
        get { return elements.Count; }
    }

    public T PopMin()
    {
        if (elements.Count > 0)
        {
            T item = elements[0];
            Delete(item);
            return item;
        }

        throw new InvalidOperationException("The heap is empty");
    }

    public void Heapify()
    {
        for (int i = elements.Count - 1; i > 0; i--)
        {
            int parentPosition = (i + 1) / 2 - 1;
            parentPosition = parentPosition >= 0 ? parentPosition : 0;

            if (elements[parentPosition].CompareTo(elements[i]) > 0)
            {
                T tmp = elements[parentPosition];
                elements[parentPosition] = elements[i];
                elements[i] = tmp;
            }
        }
    }


}

class Solution
{
    static void Main(String[] args)
    {
        int count = 0;
        int n = Convert.ToInt32(Console.ReadLine());
        var minHeap = new MinHeap<int>(n);
        var maxHeap = new MinHeap<int>(n);
        for (int a_i = 0; a_i < n; a_i++)
        {
            int currentNum = int.Parse(Console.ReadLine());
            if (count == 0 || minHeap.Count == 0)
            {
                maxHeap.Add(-currentNum);
            }
            else
            {//minHeap.Coun!=0
                if (currentNum < minHeap.Top)
                {
                    maxHeap.Add(-currentNum);
                }
                else
                {
                    minHeap.Add(currentNum);
                }
            }

            //balance heaps
            if (maxHeap.Count > minHeap.Count + 1)
                minHeap.Add(-maxHeap.PopMin());

            if (minHeap.Count > maxHeap.Count + 1)
                maxHeap.Add(-minHeap.PopMin());

            count++;
            Console.WriteLine(GetMedian(maxHeap, minHeap, count).ToString("F1"));
        }
    }

    private static float GetMedian(MinHeap<int> leftHalf, MinHeap<int> rightHalf, int count)
    {
        if (count % 2 == 0)
            return (-leftHalf.Top + rightHalf.Top) / 2f;
        else
            return leftHalf.Count > rightHalf.Count ? -leftHalf.Top : rightHalf.Top;
    }
}