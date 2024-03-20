using Microsoft.Xna.Framework;
using Library.Esliph.Components.GameObjects;

namespace Pong.Global.Fonts;

public class GlobalFontGameObject : FontGameObject
{
    public GlobalFontGameObject(string fontName, Vector2 position, Color color = new()) : base($"Fonts/{fontName}", position, color) { }
}