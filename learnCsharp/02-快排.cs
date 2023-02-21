using System;

public class QuickSort
{
    static void quickSort(int[] a, int beg, int end)
    {
        if (beg >= end) return;
        int l = beg, r = end;
        int x = a[l];
        while (l < r)
        {
            while (l < r && a[r] >= x)
            {
                r--;
            }

            if (l >= r) break;
            a[l] = a[r];
            a[r] = x;
            while (l < r && a[l] <= x)
            {
                l++;
            }

            if (l >= r) break;
            a[r] = a[l];
            a[l] = x;
        }

        quickSort(a, beg, l - 1);
        quickSort(a, l + 1, end);
    }

    static void show(int[] a)
    {
        foreach (var i in a)
        {
            Console.Write(i + ",");
        }

        Console.WriteLine();
    }

    public static void testQuickSort()
    {
        Random r = new Random();
        int[] a = new int[30];
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = r.Next() % 100;
        }

        show(a);
        quickSort(a, 0, a.Length - 1);
        show(a);
        Console.WriteLine("done");
    }
}