using System;
using System.Drawing;

namespace ConsoleWindowPosition.Service
{
    [Serializable]
    public class Properties
    {
        public Point Location { get; set; } = new Point(0, 0);
        public Size Size { get; set; } = new Size(800, 600);
    }
}