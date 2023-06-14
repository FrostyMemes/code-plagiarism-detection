using System;
namespace ConsoleApp1 {
    class Program 
    {
        delegate double Func (double x);

        static void Table (double x1, double dx, double x2, Func func) 
        {
            double y;
            string Output = "{0:F4}	{1:F4}";
            Console.WriteLine (OutputFormat, "x", "y");
                for (double x = x1; x <= x2; x += dx) 
                {
                    y = func (x);
                    Console.WriteLine (OutputFormat, x, y);
                }
        }

        double Sinus(double x) 
        { 
            return Math.Sin(x); 
        }
            
        double Cosinus(double x) 
        { 
            return Math.Cos(x); 
        }

        double Tangens(double x)
        {
            return Math.Tan(x); 
        }

        static void Main (string[] args) 
        {
            Console.Clear ();
            Func sinus = Sinus;
            Func cosinus = Cosinus;
            Func tangens = Tangens;
            Table(0, Math.PI / 10, Math.PI, sinus);
            Table(0, Math.PI / 10, Math.PI, cosinus);
            Table(0, Math.PI / 10, Math.PI, tangens);
            Console.WriteLine("Press any key");
            Console.WriteLine("Good Luck, see ya!");
            Console.ReadKey();
        }
    }
}