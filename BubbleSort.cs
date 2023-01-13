using System;

class BubbleSort
{
    static void DisplayNumWSpace(int num)
    {
        Console.Write(num + " ");
    }

    static void DisplayArr(int[] arr)
    {
        foreach (int elem in arr)
        {
            DisplayNumWSpace(elem);
        }
        Console.WriteLine();
    }

    static void Swap2Num(ref int num1, ref int num2)
    {
        int tampon = num1;
        num1 = num2;
        num2 = tampon;
    }

    static void BubbleSorting(int[] arrToSort)
    {
        int index = arrToSort.Length;
        bool atLeast1swap;
        do
        {
            atLeast1swap = false;
            index--;
            for (int i = 0; i < index; i++)
            {
                if (arrToSort[i] > arrToSort[i + 1])
                {
                    Swap2Num(ref arrToSort[i], ref arrToSort[i + 1]);
                    atLeast1swap = true;
                }
            }
        } while (atLeast1swap);
    }
    static void SortAndDisplayArr(int[] unTableau)
    {
        BubbleSorting(unTableau);
        DisplayArr(unTableau);
        Console.WriteLine();
    }

    static void Main()
    {
        int[] arr1 = { 3, 9, 1, 4, 1, 8, 5 };
        int[] arr2 = { 14, 60, 92, 37, 26, 50 };
        int[] arr3 = new int[13] { 3, 1, 4, 1, 5, 9, 2, 7, 1, 8, 2, 8, 1 };
        Console.WriteLine("Not sorted arrays:");
        DisplayArr(arr1);
        DisplayArr(arr2);
        DisplayArr(arr3);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Sorted arrays:");
        SortAndDisplayArr(arr1);
        SortAndDisplayArr(arr2);
        SortAndDisplayArr(arr3);

        Console.ReadKey();
    }
}
