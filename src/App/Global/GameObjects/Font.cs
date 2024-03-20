using Microsoft.Xna.Framework;
using Library.Esliph.Components.GameObjects;
using System.IO;

namespace Pong.Global.Fonts;

public class GlobalFontGameObject : FontGameObject
{
    public GlobalFontGameObject(string fontName, Vector2 position, Color color = new()) : base(Path.Combine("Fonts", fontName), position, color) { }
}