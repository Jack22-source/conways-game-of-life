using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ConwayGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var display = new Display();
            Conway conway = new Conway(display);

            DisplayMainMenu();
            List<CellLife> cellLives = new List<CellLife>();

            int columns = 5;
            int rows = 5;

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();

                if (keyinfo.KeyChar == '1')
                {
                    display.Clear();
                    columns = 5;
                    rows = 5;

                    cellLives = conway.GetBlinkerData();  
                    int milliseconds = 300;

                    for (int i = 0; i < 40; i++)
                    {
                        Thread.Sleep(milliseconds);
                        conway.DrawNextGeneration(cellLives, columns, rows);
                    }
                    DisplayMainMenu();

                }
                else if (keyinfo.KeyChar == '2')
                {
                    display.Clear();
                    display.WriteLine("The following ranges serves as guidance and will not retrict the program from running.");
                    display.WriteLine("Limited error handling is also in place, should the program crash restart the process again.");
                    display.WriteLine("Please enter the number of columns between 1 and 50 and then press enter.");
                    var columnKey = Console.ReadLine();
                    int.TryParse(columnKey.ToString(), out columns);

                    display.WriteLine("Please enter the number of rows between 1 and 100 and then press enter.");
                    var rowKey = Console.ReadLine();
                    int.TryParse(rowKey.ToString(), out rows);

                    display.WriteLine("Please enter the number of generations between 1 and 40 and then press enter.");
                    var generationKey = Console.ReadLine();
                    int generations = 0;
                    int.TryParse(generationKey.ToString(), out generations);

                    cellLives = conway.BuildRandomBoard(columns, rows);

                    int milliseconds = 50;
                    display.Clear();
                    for (int i = 0; i < generations; i++)
                    {
                        Thread.Sleep(milliseconds);
                        conway.DrawNextGeneration(cellLives, columns, rows);
                    }
                    DisplayMainMenu();

                }
                else if (keyinfo.KeyChar == 'x')
                { 
                }
                else
                {
                    display.WriteLine(keyinfo.Key + " is not a valid selection");
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

        }

        private static void DisplayMainMenu()
        {
            var display = new Display();
            display.Clear();
            display.WriteLine("=======================================");
            display.WriteLine("1.) press 1 for blinker ===============");
            display.WriteLine("2.) press 2 for manual setup ==========");
            display.WriteLine("3.) press x to exit          ==========");
            display.WriteLine("=======================================");

        }

    }
}
