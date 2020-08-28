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
    class Enemigos : UTGameObject
    {
        public bool points;
        public Enemigos(string imagen, Vector2 pos, float rot, float escala, FF_form forma, bool isStatic = false, bool isAddpoint = false) : base(imagen, pos, escala, rot, forma, isStatic)
        {
            this.points = isAddpoint;

            if (isAddpoint == true)
            {
                objetoFisico.addPoint();
            }
            objetoFisico.isTrigger = true;
        }


        public override void Update(GameTime gameTime)
        {
            float vel = 100;
            objetoFisico.movimientoHorizontal();
        }
        public bool getIsAddpoint()
        {
            return points;
        }

        public override void OnCollision(UTGameObject other)
        {
            Gato col = other as Gato;
            if (col != null)
            {
                col.Destroy();
                
            }
        }


    }
}

