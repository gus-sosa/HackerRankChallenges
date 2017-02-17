using System;
class Solution {
    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        for (int a_i = 0; a_i < n; a_i++) {
            int length = a_i;
            InsertSort(arr, length++, int.Parse(Console.ReadLine()));
            Console.WriteLine(GetMedian(arr, length).ToString("F1"));
        }
    }

    private static void InsertSort(int[] arr, int length, int value) {
        int indexToInsert = 0, tmp;
        while (indexToInsert < length && value >= arr[indexToInsert]) {
            indexToInsert++;
        }
        while (indexToInsert < length) {
            tmp = arr[indexToInsert];
            arr[indexToInsert++] = value;
            value = tmp;
        }
        arr[length] = value;
    }

    private static float GetMedian(int[] arr, int length) {
        int mid = length / 2;
        return length % 2 == 0 ? (arr[mid] + arr[mid - 1]) / 2f : arr[mid] * 1f;
    }
}