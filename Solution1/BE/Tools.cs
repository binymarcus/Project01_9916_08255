using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public static class Tools
    {
        public static T[] Flatten<T>(this T[,] arr)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);
            T[] arrFlattened = new T[rows * columns];
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    var test = arr[i, j];
                    arrFlattened[i * rows + j] = arr[i, j];
                }
            }
            return arrFlattened;
        }
        public static T[,] Expand<T>(this T[] arr, int rows)
        {
            int length = arr.GetLength(0);
            int columns = length / rows;
            T[,] arrExpanded = new T[rows, columns];
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    arrExpanded[i, j] = arr[i * rows + j];
                }
            }
            return arrExpanded;
        }
    }
}


