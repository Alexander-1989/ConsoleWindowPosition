using System;
using System.Drawing;
using ConsoleWindowPosition.Service;
using ConsoleWindowPosition.Service.Serializer;

namespace ConsoleWindowPosition
{
    class Program
    {
        private static void Main()
        {
            Config config = new Config();
            IntPtr thisConsole = NativeMethods.GetConsoleWindow();

            if (config.ReadConfig())
            {
                NativeMethods.SetWindowPos(thisConsole,
                    NativeMethods.HWNDInsertAfter.HWND_TOP,
                    config.Properties.Location.X,
                    config.Properties.Location.Y,
                    config.Properties.Size.Width,
                    config.Properties.Size.Height,
                    NativeMethods.SWPFlags.SWP_SHOWWINDOW);
            }

            Console.WriteLine("Hello, World!!!");
            Console.ReadKey();

            NativeMethods.GetWindowRect(thisConsole, out RECT rectangle);
            config.Properties.Location = rectangle.Location;
            config.Properties.Size = rectangle.Size;
            config.WriteConfig();
        }
    }
}