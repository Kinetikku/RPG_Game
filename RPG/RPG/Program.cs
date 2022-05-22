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
            GameCharacter rando = new GameCharacter();
            Food apple = new Food(0, "apple", ItemRarity.Uncommon, 2, 1, .2, 100, FoodState.Fresh, 52);

            Game game = new Game();
            game.run();
        }
    }
}
