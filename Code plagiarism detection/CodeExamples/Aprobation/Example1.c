using System;
usins Syste
namespace ConsoleApp1 {
    class Program 
    {
        delegate double Function (double x);

        static void GenerateTable (double x1, double dx, double x2, Function f) 
        {
            double y;
            string OutputFormat = "{0:F4}	{1:F4}";
            Console.WriteLine (OutputFormat, "x", "y");
                for (double x = x1; x <= x2; x += dx) 
                {
                    y = f (x);
                    Console.WriteLine (OutputFormat, x, y);
                }
        }

        double GetSinus(double x) 
        { 
            return Math.Sin(x); 
        }
            
        double GetCosinus(double x) 
        { 
            return Math.Cos(x); 
        }

        double GetTangens(double x)
        {
            return Math.Tan(x); 
        }

        static void Main (string[] args) 
        {
            Console.Clear ();
            Function sinusFunction = GetSinus;
            Function cosinusFunction = GetCosinus;
            Function tangensFunction = GetTangens;
            GenerateTable(0, Math.PI / 10, Math.PI, sinusFunction);
            GenerateTable(0, Math.PI / 10, Math.PI, cosinusFunction);
            GenerateTable(0, Math.PI / 10, Math.PI, tangensFunction);
            Console.WriteLine("Press any key");
            Console.WriteLine("Good Luck, see ya!");
            Console.ReadKey();
        }
    }
}