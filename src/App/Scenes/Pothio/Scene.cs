using Microsoft.Xna.Framework;
using Library.Esliph.Common;
using Pong.Scenes.Pothio.Entities;
using System.Timers;
using Pong.Global;
using Pong.Scenes.Pothio;

namespace Test.Scenes;

public class PothioScene : Scene
{
    public PothioScene() : base("Pothio", Color.Black) { }

    public override void Initialize()
    {
        var player = new Player();

        Interval.SetTimeout((object o, ElapsedEventArgs e) =>
        {
            int X = 0, Y = 0;

            if (GlobalGame.random.Next(0, 2) == 0)
            {
                X = GlobalGame.random.Next(0, 2) == 0 ? -(int)PothioGlobal.ENEMY_DIMENSION.Width : (int)GlobalGame.WINDOW_DIMENSION.Width;
                Y = GlobalGame.random.Next(-(int)PothioGlobal.ENEMY_DIMENSION.Height, (int)GlobalGame.WINDOW_DIMENSION.Height);
            }
            else
            {
                Y = GlobalGame.random.Next(0, 2) == 0 ? -(int)PothioGlobal.ENEMY_DIMENSION.Height : (int)GlobalGame.WINDOW_DIMENSION.Height;
                X = GlobalGame.random.Next(-(int)PothioGlobal.ENEMY_DIMENSION.Width, (int)GlobalGame.WINDOW_DIMENSION.Width);
            }

            var enemy = new Enemy(player, new(900, 207));

            this.AddGameObjects(enemy);
        });

        this.AddGameObjects(player);

        base.Initialize();
    }
}