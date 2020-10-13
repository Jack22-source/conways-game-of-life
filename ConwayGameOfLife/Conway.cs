using ConwayGameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwayGameOfLife
{
    public class Conway
    {
        public readonly IDisplay _display;

        public Conway(IDisplay display)
        {
            _display = display;
        }

        public List<CellLife> GetBlinkerData()
        {
            var blinker = new List<CellLife>();
            Display display = new Display();
            int width = 10;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    _display.SetCursorPosition(j + width + j, i);

                    blinker.Add(new CellLife() { X = i, Y = j, CurrentState = 0, PreviousState = 0 });
                    _display.Write(" 0 ");
                }
            }

            for (int b = 1; b < 4; b++)
            {
                var blink = blinker.Where(w => w.X == 2 && w.Y == b).First();
                blink.PreviousState = 1;
                blink.CurrentState = 1;

            }

            return blinker;

        }

        public List<CellLife> BuildRandomBoard(int columns, int rows)
        {
            int width = 10;
            List<CellLife> lifeCells = new List<CellLife>();
            var random = new Random();

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    _display.SetCursorPosition(j + width + j, i);

                    if (random.Next(0, 2) == 1)
                    {
                        lifeCells.Add(new CellLife() { X = i, Y = j, CurrentState = 1, PreviousState = 1 });
                        _display.Write(" * ");

                    }
                    else
                    {
                        lifeCells.Add(new CellLife() { X = i, Y = j, CurrentState = 0, PreviousState = 0 });
                        _display.Write(" 0 ");
                    }

                }
            }
            return lifeCells;
        }

        public void DrawNextGeneration(List<CellLife> cellLives, int columns, int rows)
        {
            int width = 10;

            foreach (var cellLife in cellLives)
            {
                _display.SetCursorPosition(cellLife.Y + width + cellLife.Y, cellLife.X);
                var sum = 0;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        sum += cellLives.Where(w => w.X == ((cellLife.X + i + columns) % columns) && w.Y == ((cellLife.Y + j + rows) % rows)).Select(s => s.PreviousState).First();
                    }
                }

                sum -= cellLife.PreviousState;

                //Rules
                if (cellLife.PreviousState == 0 && sum == 3)
                {
                    cellLife.CurrentState = 1;
                    _display.Write(" * ");
                }
                else if (cellLife.PreviousState == 1 && (sum < 2 || sum > 3))
                {
                    cellLife.CurrentState = 0;
                    _display.Write(" 0 ");
                }
                else
                {
                    if (cellLife.CurrentState == 1)
                        _display.Write(" * ");
                    else
                        _display.Write(" 0 ");
                }


            }
            foreach (var lifeCell in cellLives)
            {
                lifeCell.PreviousState = lifeCell.CurrentState;
            }
        }
    }
}
