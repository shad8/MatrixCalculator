using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Math
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
          IndexOf(i, j, body[index]);
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

    public double IndexOf(int row, int column, double? newValue = null)
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
          double value = matrixA.IndexOf(i, j) + matrixB.IndexOf(i, j);
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
          double value = matrixA.IndexOf(i, j) - matrixB.IndexOf(i, j);
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
            double value = productMatrix.IndexOf(i, j) + matrixA.IndexOf(i, k) * matrixB.IndexOf(k, j);
            productMatrix.IndexOf(i, j, value);
          }
        }
      }
      return productMatrix;
    }

    public double ElementCount()
    {
      double sum = 0;

      foreach(double value in this.body)
      {
        sum += value;
      }
      return sum;
    }

    public void Print()
    {
      Console.WriteLine("" + row + " " + column + "\n");
      for (int i = 0; i < row; i++)
      {
        for (int j = 0; j < column; j++)
        {
          Console.Write("\t" + IndexOf(i, j));
        }
        Console.Write(Environment.NewLine + Environment.NewLine);
      }
    }

    public static void ClassInformation()
    {
      Assembly assem = typeof(Matrix).Assembly;
      AssemblyName assemName = assem.GetName();
      Console.WriteLine("\nName: {0}", assemName.Name);
      Console.WriteLine("Version: {0}.{1}",
          assemName.Version.Major, assemName.Version.Minor);
      Console.WriteLine(assem.EntryPoint);

      Assembly assembly = Assembly.GetExecutingAssembly(); 
      AssemblyDescriptionAttribute description = assembly
        .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
        .OfType<AssemblyDescriptionAttribute>()
        .FirstOrDefault();

      AssemblyCompanyAttribute author = assembly
        .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)
        .OfType<AssemblyCompanyAttribute>()
        .FirstOrDefault();
 
      Console.WriteLine(description.Description + "\n");
      Console.WriteLine("Author: " + author.Company + "\n");

      BindingFlags bindingFlags = BindingFlags.Public |
                      BindingFlags.NonPublic |
                      BindingFlags.Instance |
                      BindingFlags.Static;

      Console.WriteLine("Atributes:");
      Console.WriteLine("----------");
      foreach (FieldInfo field in typeof(Matrix).GetFields(bindingFlags))
        Console.WriteLine(field.Attributes + " " + field.FieldType + " " + field.Name);

      Console.WriteLine("\nMethods:");
      Console.WriteLine("----------");
      MethodInfo[] methodInfos = typeof(Matrix)
        .GetMethods(BindingFlags.Public |BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

      foreach (MethodInfo methodInfo in methodInfos)
      {
        string type = methodInfo.IsPublic ? "Public" : "Private";
        string method = type + " " + methodInfo.ReturnParameter + methodInfo.Name + "(" + GetParamInfo(methodInfo) + ")";
        Console.WriteLine(method);
      }
    }

    public void SaveToFile(string path)
    {
      try
      {
        System.IO.StreamWriter file = new System.IO.StreamWriter(path);
        string dimension = row + " " + column;
        file.WriteLine(dimension);
        for (int i = 0; i < row; i++)
        {
          for (int j = 0; j < column; j++)
          {
            file.Write("\t" + IndexOf(i, j));
          }
          file.WriteLine(Environment.NewLine);
        }
        file.Close();
        Console.WriteLine("The operation completed successfully");
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    private static string GetParamInfo(MethodInfo methodInfo)
    {
      string atributes = "";
      ParameterInfo[] parametrs = methodInfo.GetParameters();
      foreach(ParameterInfo parametr in parametrs)
      {
        atributes += parametr.ParameterType + " " + parametr.Name + " "; 
      }
      return atributes;
    }
  }
}
