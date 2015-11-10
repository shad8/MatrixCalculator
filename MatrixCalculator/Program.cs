using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math;
using System.Reflection;
using System.IO;

namespace MatrixCalculator
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to aplication......\n");
      Menu();
    }

    private static void MatrixOperations()
    {
      Console.Clear();
      Console.WriteLine("Matrix operations: \n");
      PrintSubMenu();

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
            Menu();
            break;
        }
      }
    }

    private static void ReadWriteOperations()
    {
      Console.WriteLine("Read/Write operations: \n");
      PrintSubMenu2();

      string selection;
      while (true)
      {
        selection = Console.ReadLine();

        switch (selection)
        {
          case "1":
            Console.Clear();
            WriteMatrixToFile();
            break;
          case "2":
            Console.Clear();
            ReadMatrixFormFile();
            break;
          case "3":
            Environment.Exit(0);
            break;
          default:
            Console.Clear();
            Menu();
            break;
        }
      }
    }

    private static void ReadMatrixFormFile()
    {
      Console.WriteLine("Press file name:");
      string fileName = Console.ReadLine();
      string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      string path = myDocs + @"\" + fileName + ".txt";

      bool first = true;
      try
      {
        string[] file = File.ReadAllLines(path);
        foreach (var line in file)
        {
          if (first)
          {
            var dimension = line.Split(' ');
            Console.WriteLine(dimension[0] + " " + dimension[1]);
            first = false;
          }
          else
          {
            var data = line.Split('\t');
            foreach (var value in data)
              Console.Write(value + "\t");
            Console.WriteLine(Environment.NewLine);
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        Console.WriteLine("Try again or press 1 tu back:");

        string selection = Console.ReadLine();

        if (selection == "1")
          MatrixOperations();
        else
          ReadMatrixFormFile();
      }
    }

    private static void WriteMatrixToFile()
    {
      Matrix matrix = CreateMatrix();
      string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

      matrix.Print();

      Console.WriteLine("Your matrix will be save to file");
      Console.WriteLine("Your file will be save in: " + myDocs);
      Console.WriteLine("Press file name:");

      string fileName = Console.ReadLine();
      string path = myDocs + @"\" + fileName + ".txt";

      matrix.SaveToFile(path);
    }

    private static void MultiplicationMatrix()
    {
      Matrix A = CreateMatrix();
      Console.Clear();
      Matrix B = CreateMatrix();
      Matrix C = A * B;
      Console.WriteLine(" Result:\n");
      C.Print();
    }

    private static void SumOfElements()
    {
      Matrix A = CreateMatrix();
      Console.Clear();
      A.Print();
      Console.WriteLine(" " + "Sum of matrix element: " + A.ElementCount());
    }

    private static void SubtractionMatrix()
    {
      Matrix A = CreateMatrix();
      Console.Clear();
      Matrix B = CreateMatrix();
      Matrix C = A - B;
      Console.WriteLine("Result:\n");
      C.Print();
    }

    private static void AdditionMatrix()
    {
      Matrix A = CreateMatrix();
      Console.Clear();
      Matrix B = CreateMatrix();
      Matrix C = A + B;
      Console.WriteLine("Result:\n");
      C.Print();
    }

    private static Matrix CreateMatrix()
    {
      Console.WriteLine("Define A matrix by row (eg 1,2,3.5,4):");
      double[] matrixBody = Console.ReadLine().ConvertStringToDoubleArray(',');
      Console.WriteLine("Number of colum:");
      int column;
      int row;
      Int32.TryParse(Console.ReadLine(), out column);
      Console.WriteLine("Number of row:");
      Int32.TryParse(Console.ReadLine(), out row);
      return new Math.Matrix(matrixBody, row, column);
    }

    private static void Menu()
    {
      string selection;
      PrintMenu();
      while(true)
      {
        selection = Console.ReadLine();

        switch (selection)
        {
          case "1":
            Console.Clear();
            MatrixOperations();
            break;
          case "2":
            Console.Clear();
            ReadWriteOperations();
            break;
          case "3":
            Console.Clear();
            Math.Matrix.ClassInformation();
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
            PrintMenu();
            break;
        }
      }
    }

    private static void PrintMenu()
    {
      Console.WriteLine("Choose number and press enter to choose options:");
      Console.WriteLine("[1] Matrix operations");
      Console.WriteLine("[2] Read/write operations");
      Console.WriteLine("[3] .Net component");
      Console.WriteLine("[4] Autor");
      Console.WriteLine("[5] Exit");
    }

    private static void PrintSubMenu()
    {
      Console.WriteLine("[1] Addition");
      Console.WriteLine("[2] Subtraction");
      Console.WriteLine("[3] Multiplication Matrix");
      Console.WriteLine("[4] Sum of matrix elements");
      Console.WriteLine("[5] EXIT");
      Console.WriteLine("[ENTER] Back");
    }

    private static void PrintSubMenu2()
    {
      Console.WriteLine("[1] Write matrix to file");
      Console.WriteLine("[2] Read matrix to file");
      Console.WriteLine("[5] EXIT");
      Console.WriteLine("[ENTER] Back");
    }
  }
}
