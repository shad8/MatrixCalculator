using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
  class Program
  {
    static void Main(string[] args)
    {
      string selection;

      Console.WriteLine("Welcome to aplication......\n");
      printMenu();

      do
      {
        selection = Console.ReadLine();

        switch (selection)
        {
          case "1":
            Console.Clear();
            Console.WriteLine("[1] Matrix operations\n");
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
      } while (selection != "5");
    }

    private static void printMenu()
    {
      Console.WriteLine("Press key to choose:");
      Console.WriteLine("[1] Matrix operations");
      Console.WriteLine("[2] Read/write operations");
      Console.WriteLine("[3] .Net component");
      Console.WriteLine("[4] Autor");
      Console.WriteLine("[5] Exit");
    }
  }
}
