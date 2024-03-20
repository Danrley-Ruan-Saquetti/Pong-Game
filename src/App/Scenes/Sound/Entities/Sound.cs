using System.IO;
using Library.Esliph.Common;
using Microsoft.Xna.Framework.Audio;

namespace Pong.Scenes.Sound.Entities;

public class Sound : GameObject
{
    private SoundEffect sound;

    public Sound() : base()
    {
        this.sound = this.gameController.GetContentManager().Load<SoundEffect>(Path.Combine("Sounds", "ambient-game"));
        this.AddTags("Sound");
    }
}