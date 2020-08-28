using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using UTalDrawSystem.SistemaGameObject;

namespace UTalDrawSystem.MyGame
{
    public class Bullet : UTGameObject
    {
        public Bullet(string imagen, Vector2 pos, float rot, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, rot, escala, forma, isStatic)
        {
        }
        public override void Update(GameTime gameTime)
        {
            objetoFisico.movimientoHorizontalParaBala();
            if (gameTime.ElapsedGameTime.Seconds >=10)
            {
                Destroy();
            }

        }


        public override void OnCollision(UTGameObject other)
        {
            Coleccionable col = other as Coleccionable;
            Enemigos enemi = other as Enemigos;

            if (col != null)
            {
                col.Destroy();
                Destroy();
            }
            if (enemi != null)
            {
                enemi.Destroy();
                Destroy();
            }
        }

    }
}