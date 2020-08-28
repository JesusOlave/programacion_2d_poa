using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTalDrawSystem
{
    public class Pantallas
    {
        Texture2D texturaPantallas;

        public void Content(ContentManager Content, string nombreTextura)
        {
            texturaPantallas = Content.Load<Texture2D>(nombreTextura);
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(texturaPantallas, new Rectangle(0, 0, 1280, 720), Color.White);
        }
    }
}
