using System;
using System.Collections.Generic;
using System.Text;

namespace ConwayGameOfLife.Interfaces
{
    public interface IDisplay
    {
        void Write(string value);
        void SetCursorPosition(int left, int top);
        void WriteLine(string value);
        void Clear();
    }
}
