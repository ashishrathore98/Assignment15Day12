using System;
using System.Diagnostics;

public class SortingComparison
{
    public static void Main(string[] args)
    {
        int[] arrQuickSort = GenerateRandomArray(40);
        int[] arrMergeSort = new int[arrQuickSort.Length];
        Array.Copy(arrQuickSort, arrMergeSort, arrQuickSort.Length);
        Console.WriteLine("\nQUICK SORT");
        Console.WriteLine("\nUnsorted Array:");
        PrintArray(arrQuickSort);

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        QuickSortAlgorithm(arrQuickSort, 0, arrQuickSort.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("\nSorted Array:");
        PrintArray(arrQuickSort);
        Console.WriteLine("\nTime taken in milliseconds: " + stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine("\nArray Size: " + arrQuickSort.Length);

        Console.WriteLine("\nMERGE SORT");
        Console.WriteLine("\nUnsorted Array:");
        PrintArray(arrMergeSort);

        stopwatch.Restart();
        MergeSortAlgorithm(arrMergeSort, 0, arrMergeSort.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("\nSorted Array:");
        PrintArray(arrMergeSort);
        Console.WriteLine("\nTime taken in milliseconds: " + stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine("\nArraySize: " + arrMergeSort.Length);
    }


    public static void QuickSortAlgorithm(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSortAlgorithm(arr, low, pivotIndex - 1);
            QuickSortAlgorithm(arr, pivotIndex + 1, high);
        }
    }

    public static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i + 1, high);
        return i + 1;
    }

    public static void MergeSortAlgorithm(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int mid = low + (high - low) / 2;
            MergeSortAlgorithm(arr, low, mid);
            MergeSortAlgorithm(arr, mid + 1, high);
            Merge(arr, low, mid, high);
        }
    }

    public static void Merge(int[] arr, int low, int mid, int high)
    {
        int leftSize = mid - low + 1;
        int rightSize = high - mid;

        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        Array.Copy(arr, low, leftArray, 0, leftSize);
        Array.Copy(arr, mid + 1, rightArray, 0, rightSize);

        int i = 0, j = 0, k = low;

        while (i < leftSize && j < rightSize)
        {
            if (leftArray[i] <= rightArray[j])
                arr[k++] = leftArray[i++];
            else
                arr[k++] = rightArray[j++];
        }

        while (i < leftSize)
            arr[k++] = leftArray[i++];

        while (j < rightSize)
            arr[k++] = rightArray[j++];
    }

    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
                return false;
        }
        return true;
    }

    public static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = random.Next(1, 1000);
        }
        return arr;
    }

    public static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}