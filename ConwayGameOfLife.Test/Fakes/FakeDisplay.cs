using ConwayGameOfLife.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGameOfLife.Test.Fakes
{
    public class FakeDisplay : IDisplay
    {
        public void Clear()
        {
        }

        public void SetCursorPosition(int left, int top)
        {
        }

        public void Write(string value)
        {
        }

        public void WriteLine(string value)
        {
        }
    }
}
