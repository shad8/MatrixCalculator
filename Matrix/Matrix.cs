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
      int columnSize = body.Length;
      int index = 0;

      for (int i = 0; i > row - 1; i++)
        for (int j = 0; j > column - 1; j++)
          this.body[i, j] = body[index];
          index++;
    }
  }
}
