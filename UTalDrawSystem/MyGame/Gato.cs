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
    public class Gato : UTGameObject
    {
        double timer = 1f;
        SoundEffect plonk;
        public Gato(string imagen, Vector2 pos, float rot, float escala, FF_form forma, bool isStatic = false) : base(imagen, pos, rot, escala, forma, isStatic)
        {
            this.plonk = Game1.INSTANCE.Content.Load<SoundEffect>("HITMARKER SOUND EFFECT (FREE DOWNLOAD)");
        }
        public override void Update(GameTime gameTime)
        {

            float vel = 100;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
               
                objetoFisico.AddVelocity(new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds * vel, 0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                objetoFisico.AddVelocity(new Vector2(-(float)gameTime.ElapsedGameTime.TotalSeconds * vel, 0));
            }
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {

                objetoFisico.AddVelocity(new Vector2(0,-(float)gameTime.ElapsedGameTime.TotalSeconds * vel));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                objetoFisico.AddVelocity(new Vector2(0,(float)gameTime.ElapsedGameTime.TotalSeconds * vel));
            }
            

            if (Keyboard.GetState().IsKeyDown(Keys.P))
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
                    plonk.Play();
                    Game1.pantalla = GameState.Final;
                    new Escena3();
                }
                if(enemi != null)
                {
                    enemi.Destroy();
                    Destroy();
                    plonk.Play();
                    Game1.pantalla = GameState.Final;
                    new Escena3();
                }
        }
        
    }
}
