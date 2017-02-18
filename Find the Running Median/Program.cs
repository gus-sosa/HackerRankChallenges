using System;
using System.Collections;

class Solution {
    private static void Swap<T>(ref T v1, ref T v2) {
        T tmp = v1;
        v1 = v2;
        v2 = tmp;
    }

    private static void HeapifyUp(int[] arr, int index) {
        int parent = (index - 1) / 2;
        while (parent >= 0 && arr[parent] > arr[index]) {
            Swap(ref arr[parent], ref arr[index]);
            index = parent;
            parent = (index - 2) / 2;
        }
    }

    private static void HeapifyDown(int[] arr, ref int length) {
        arr[0] = arr[--length];
        int index = 0, leftChildIndex = 1, indexToSwap, rightChildIndex;
        while (leftChildIndex < length) {
            indexToSwap = leftChildIndex;
            rightChildIndex = 2 * index + 2;
            if (rightChildIndex < length && arr[rightChildIndex] < arr[leftChildIndex]) {
                indexToSwap = rightChildIndex;
            }

            if (arr[index] <= arr[indexToSwap]) {
                return;
            }

            Swap(ref arr[index], ref arr[indexToSwap]);
            index = indexToSwap;
            leftChildIndex = 2 * index + 1;
        }
    }

    private static void InsertInHeap(int[] arr, ref int length, int num) {
        arr[length] = num;
        HeapifyUp(arr, length++);
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int sizeHeap = n / 2 + 1;
        int[] leftHalf = new int[sizeHeap];
        int lengthLeftHalf = 0;
        int[] rightHalf = new int[sizeHeap];
        int lengthRightHalf = 0;
        for (int a_i = 0; a_i < n; a_i++) {
            int currentNum = int.Parse(Console.ReadLine());
            if (lengthLeftHalf == 0) {
                InsertInHeap(leftHalf, ref lengthLeftHalf, -currentNum);
            } else {
                if (lengthLeftHalf > lengthRightHalf) {
                    if (currentNum > -leftHalf[0]) {
                        InsertInHeap(rightHalf, ref lengthRightHalf, currentNum);
                    } else {
                        InsertInHeap(rightHalf, ref lengthRightHalf, -leftHalf[0]);
                        HeapifyDown(leftHalf, ref lengthLeftHalf);
                        InsertInHeap(leftHalf, ref lengthLeftHalf, -currentNum);
                    }
                } else {
                    if (currentNum < rightHalf[0]) {
                        InsertInHeap(leftHalf, ref lengthLeftHalf, -currentNum);
                    } else {
                        InsertInHeap(leftHalf, ref lengthLeftHalf, -rightHalf[0]);
                        HeapifyDown(rightHalf, ref lengthRightHalf);
                        InsertInHeap(rightHalf, ref lengthRightHalf, currentNum);
                    }
                }
            }

            Console.WriteLine(GetMedian(leftHalf, rightHalf, lengthLeftHalf + lengthRightHalf).ToString("F1"));
        }
    }

    private static float GetMedian(int[] leftHalf, int[] rightHalf, int count) {
        float result = -leftHalf[0] * 1f;
        if (count % 2 == 0) {
            result = (result + rightHalf[0]) / 2f;
        }
        return result;
    }
}