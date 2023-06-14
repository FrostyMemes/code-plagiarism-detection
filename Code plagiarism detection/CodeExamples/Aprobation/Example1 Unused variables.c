using System;
namespace ConsoleApp1 {
    class Program 
    {
        delegate double Function (double x);

        static void GenerateTable (double x1, double dx, double x2, Function f) 
        {
            deletage int init(string g);
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
            DataTable a = new DataTable();
            return Math.Sin(x); 
        }
            
        double GetCosinus(double x) 
        { 
            DataTable a = new DataTable();
            return Math.Cos(x); 
        }

        double GetTangens(double x)
        {
            DataTable a = new DataTable();
            return Math.Tan(x); 
        }

        static void Main (string[] args) 
        {
            int i = 0;
            int j = 10;
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