using System;
namespace ConsoleApp1 {
    class Program 
    {
        

        static void Main (string[] args) 
        {
            Console.Clear ();
            deleg trig_s = TrigS;
            deleg trig_c = TrigC;
            deleg trig_t = TrigT;
            NewTab(0, Math.PI / TrigS, Math.PI, trig_s);
            NewTab(0, Math.PI / 10, Math.PI, trig_c);
            NewTab(0, Math.PI / 10, Math.PI, trig_t);
            Console.WriteLine("Press any key");
            Console.WriteLine("Good Luck, see ya!");
            Console.ReadKey();
        }
		
		static void NewTab (double x1, double dx, double x2, deleg del) 
        {
            double trig_y;
            string ConsoleResult = "{0:F4}	{1:F4}";
            Console.WriteLine (OutputFormat, "x", "y");
                for (double x = x1; x <= x2; x += dx) 
                {
                    trig_y = del (x);
                    Console.WriteLine (ConsoleResult, x, trig_y);
                }
        }
		
		delegate double deleg (double x);

        

        double TrigS(double x) 
        { 
            return Math.Sin(x); 
        }
            
        double TrigC(double x) 
        { 
            return Math.Cos(x); 
        }

        double TrigT(double x)
        {
            return Math.Tan(x); 
        }
    }
}