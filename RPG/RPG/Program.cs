using System;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.run();
        }
    }
}
