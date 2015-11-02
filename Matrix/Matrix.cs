using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
  public class Matrix
  {
    private double[,] body;
    private int row, column;

    public Matrix(double[] body, int row, int column)
    {
      this.row = row;
      this.column = column;
      this.body = new double[row, column];
      int columnSize = body.Length;
      int index = 0;

      for (int i = 0; i < row; i++)
      {
        for (int j = 0; j < column; j++)
        {
          this.IndexOf(i, j, body[index]);
          index++;
        }
      }
    }

    public Matrix(int row, int column)
    {
      this.row = row;
      this.column = column;
      this.body = new double[row, column];
    }

    public double IndexOf(int row, int column, double? newValue)
    {
      if (newValue.HasValue)
        this.body[row, column] = newValue.Value;
      return this.body[row, column];
    }


    public static Matrix operator +(Matrix matrixA, Matrix matrixB)
    {
      int row = matrixA.row;
      int column = matrixA.column;

      Matrix sumMatrix = new Matrix(row, column);

      for (int i = 0; i < row; i++)
      {
        for (int j = 0; j < column; j++)
        {
          double value = matrixA.IndexOf(i, j, null) + matrixB.IndexOf(i, j, null);
          sumMatrix.IndexOf(i, j, value);
        }
      }
      return sumMatrix;
    }

    public static Matrix operator -(Matrix matrixA, Matrix matrixB)
    {
      int row = matrixA.row;
      int column = matrixA.column;

      Matrix differenceMatrix = new Matrix(row, column);

      for (int i = 0; i < row; i++)
      {
        for (int j = 0; j < column; j++)
        {
          double value = matrixA.IndexOf(i, j, null) - matrixB.IndexOf(i, j, null);
          differenceMatrix.IndexOf(i, j, value);
        }
      }
      return differenceMatrix;
    }

    public static Matrix operator *(Matrix matrixA, Matrix matrixB)
    {
      int row = matrixA.row;
      int column = matrixB.column;

      Matrix productMatrix = new Matrix(row, column);

      for (int i = 0; i < row; i++)
      {
        for (int j = 0; j < column; j++)
        {
          for (int k = 0; k < matrixA.column; k++)
          {
            double value = productMatrix.IndexOf(i, j, null) + matrixA.IndexOf(i, k, null) * matrixB.IndexOf(k, j, null);
            productMatrix.IndexOf(i, j, value);
          }
        }
      }
      return productMatrix;
    }

    public void Print()
    {
      for (int i = 0; i < this.row; i++)
      {
        for (int j = 0; j < this.column; j++)
        {
          Console.Write(string.Format("{0} ", this.IndexOf(i, j, null)));
        }
        Console.Write(Environment.NewLine + Environment.NewLine);
      }
    }
  }
}
