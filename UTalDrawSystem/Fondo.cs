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
    public class Fondo
    {
        Texture2D texturaFinal;
        public int i=-1080, j=0;
        
        

        public void Content(ContentManager Content, string nombreTextura)
        {
            texturaFinal = Content.Load<Texture2D>(nombreTextura);
        }
        public void Update(GameTime gameTime)
        {
            j +=10;
            i +=10;
            if (j == 1080)
            {
                j = 0;
            }
            if (i == 0)
            {
                i = -1080;
            }
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(texturaFinal, new Rectangle(j, 0, 1280, 720), Color.White);
            Game1.spriteBatch.Draw(texturaFinal, new Rectangle(i, 0, 1280, 720), Color.White);
        }

    }
}
