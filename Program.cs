using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace RotateMatrix
{
    class Program
    {
        static void FillMatrix(int[,] matrix)
        {
            for(int i=0;i<matrix.GetLength(0);i++)
            {
                for(int j=0;j<matrix.GetLength(1);j++)
                {
                    Console.WriteLine("Enter element [{0},{1}]", i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        static void PrintMatrix(int[,] matrix)
        {
            for(int i=0;i<matrix.GetLength(0);i++)
            {
                for(int j=0;j<matrix.GetLength(1);j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void RotateMatrix(int[,] matrix,int temp,int temp1)
        {
            MoveElementsForward(matrix, 0, matrix.GetLength(1)-1, ref temp);
            MoveElementsDownward(matrix, matrix.GetLength(0) - 1, matrix.GetLength(1) - 1, ref temp, ref temp1);
            MoveElementsBackward(matrix, matrix.GetLength(0) - 1, 0, ref temp, ref temp1);
            MoveElementsUpward(matrix, 0, 0, ref temp);
        }
        static void MoveElementsForward(int[,] matrix,int row,int col,ref int temp)
        {
            temp = matrix[row, col];
            while(true)
            {
                if(col==0)
                { 
                    break;
                }
                matrix[row, col] = matrix[row, col-1];
                col--;
            }
        }
        static void MoveElementsDownward(int[,] matrix,int row,int col,ref int temp,ref int temp1)
        {
            temp1 = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            while(true)
            {
                if(row==1)
                {
                    break;
                }
                matrix[row,col] = matrix[row-1, col];
                row--;
            }
            matrix[row, matrix.GetLength(1) - 1] = temp;
        }
        static void MoveElementsBackward(int[,] matrix,int row,int col,ref int temp,ref int temp1)
        {
           temp = matrix[matrix.GetLength(0) - 1, 0];
           while(true)
            {
                if(col==matrix.GetLength(1)-2)
                {
                    break;
                }
                matrix[row,col] = matrix[row, col+1];
                col++;
            }
            matrix[matrix.GetLength(0) - 1,col] = temp1;
        }
        static void MoveElementsUpward(int[,] matrix,int row,int col,ref int temp)
        {
            while(true)
            {
                if(row==matrix.GetLength(0)-2)
                {
                    break;
                }
                matrix[row, col] = matrix[row+1,col];
                row++;
            }
            matrix[row, 0] = temp;
        }
        static void Main()
        {
            Console.WriteLine("Enter size of the matrix:");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int temp = 0, temp1 = 0;
            FillMatrix(matrix);
            PrintMatrix(matrix);
            RotateMatrix(matrix,temp,temp1);
            Console.WriteLine();
            PrintMatrix(matrix);
        }
    }
}
