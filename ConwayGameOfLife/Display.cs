using ConwayGameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGameOfLife
{
    public class Display : IDisplay
    {
        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
