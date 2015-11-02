using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;

namespace MatrixCalculator
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to aplication......\n");
      menu();
    }

    private static void matrixOperations()
    {
      Console.WriteLine("Matrix operations: \n");
      printSubMenu();

      string selection;
      while(true)
      {
        selection = Console.ReadLine();

        switch (selection)
        {
          case "1":
            Console.Clear();
            AdditionMatrix();
            break;
          case "2":
            Console.Clear();
            SubtractionMatrix();
            break;
          case "3":
            Console.Clear();
            MultiplicationMatrix();
            break;
          case "4":
            Console.Clear();
            SumOfElements();
            break;
          case "5":
            Environment.Exit(0);
            break;
          default:
            Console.Clear();
            menu();
            break;
        }
      }
    }

    private static void MultiplicationMatrix()
    {
      Matrix.Matrix A = createMatrix();
      Console.Clear();
      Matrix.Matrix B = createMatrix();
      Matrix.Matrix C = A * B;
      Console.WriteLine("Result:\n");
      C.Print();
    }

    private static void SumOfElements()
    {
      throw new NotImplementedException();
    }

    private static void SubtractionMatrix()
    {
      Matrix.Matrix A = createMatrix();
      Console.Clear();
      Matrix.Matrix B = createMatrix();
      Matrix.Matrix C = A - B;
      Console.WriteLine("Result:\n");
      C.Print();
    }

    private static void AdditionMatrix()
    {
      Matrix.Matrix A = createMatrix();
      Console.Clear();
      Matrix.Matrix B = createMatrix();
      Matrix.Matrix C = A + B;
      Console.WriteLine("Result:\n");
      C.Print();
    }

    private static Matrix.Matrix createMatrix()
    {
      Console.WriteLine("Define A matrix by row (eg 1 2 3.5 4):");
      double[] matrixBody = Console.ReadLine().ConvertStringToDoubleArray();
      Console.WriteLine("Number of colum:");
      int column;
      int row;
      Int32.TryParse(Console.ReadLine(), out column);
      Console.WriteLine("Number of row:");
      Int32.TryParse(Console.ReadLine(), out row);
      return new Matrix.Matrix(matrixBody, row, column);
    }

    private static void menu()
    {
      string selection;
      printMenu();
      while(true)
      {
        selection = Console.ReadLine();

        switch (selection)
        {
          case "1":
            Console.Clear();
            matrixOperations();
            break;
          case "2":
            Console.Clear();
            Console.WriteLine("[2] Read/write operations\n");
            break;
          case "3":
            Console.Clear();
            Console.WriteLine("[3] .Net component\n");
            break;
          case "4":
            Console.Clear();
            Console.WriteLine("Autor:\n Urszula Hołodniak ITS\n");
            break;
          case "5":
            Environment.Exit(0);
            break;
          default:
            Console.Clear();
            printMenu();
            break;
        }
      }
    }

    private static void printMenu()
    {
      Console.WriteLine("Choose number and press enter to choose options:");
      Console.WriteLine("[1] Matrix operations");
      Console.WriteLine("[2] Read/write operations");
      Console.WriteLine("[3] .Net component");
      Console.WriteLine("[4] Autor");
      Console.WriteLine("[5] Exit");
    }

    private static void printSubMenu()
    {
      Console.WriteLine("[1] Addition");
      Console.WriteLine("[2] Subtraction");
      Console.WriteLine("[3] Multiplication Matrix");
      Console.WriteLine("[4] Sum of matrix elements");
      Console.WriteLine("[5] EXIT");
      Console.WriteLine("[ENTER] Back");
    }
  }
}
