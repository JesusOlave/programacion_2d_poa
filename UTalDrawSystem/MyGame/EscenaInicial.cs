using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaFisico;
using UTalDrawSystem.SistemaGameObject;
using Microsoft.Xna.Framework.Graphics;


namespace UTalDrawSystem.MyGame
{
    public class EscenaInicial:Escena
    {
        public SpriteBatch spriteBatch;
        public Vector2 posicionTexto = new Vector2(200, 400);
        Camara camara2;

        public EscenaInicial()
        {
            UTGameObjectsManager.Init();
            camara2 = new Camara(new Vector2(0, 0), .3f, 0);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
