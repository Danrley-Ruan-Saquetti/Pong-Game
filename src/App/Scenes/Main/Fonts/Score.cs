using Microsoft.Xna.Framework;
using Pong.Global.Fonts;
using Pong.Scenes.Main.Entities;

namespace Pong.Scenes.Main.Fonts;

public class ScoreFont : GlobalFontGameObject
{
    private Player player;

    public ScoreFont(Player player, Vector2 position) : base("Score", position, Color.White)
    {
        this.player = player;
        this.AddTags("Score");
    }

    public override void Update()
    {
        this.GetFontShape().SetContent($"Score: {this.player.score}");
        base.Update();
    }
}