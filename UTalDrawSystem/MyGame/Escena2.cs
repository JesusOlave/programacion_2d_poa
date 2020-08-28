using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaGameObject;
using Microsoft.Xna.Framework.Media;


namespace UTalDrawSystem.MyGame
{

    

    public class Escena2 : Escena
    {
        SoundEffect shoot;
        private const double V = 0.1;
        UTGameObject playerUTG;
        //Camara camara;
        Camara camara2;
        bool click = false;
        bool seeC2;
        bool spacePressed;
        double timeSpawnAgujeros;
        double timer = 1f;
        List<Coleccionable> listaAgujeros;
        
        Song musica;
        Random rnd = new Random();
        int contador = 0;
        int contador2 = 0;
        int x;
        int y= 200;



        public Escena2()
        {

            UTGameObjectsManager.Init();

            listaAgujeros = new List<Coleccionable>();

            this.shoot = Game1.INSTANCE.Content.Load<SoundEffect>("Laser Gun Sound Effect"); 

            playerUTG = new Gato("la_navesita_bebelin", new Vector2(1000, 500), .0f, 2f, UTGameObject.FF_form.Circulo);

            
            //murallas a los lados

            //derecha
            new UTGameObject("muralla_laser2", new Vector2(4220, 300), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser2", new Vector2(4220, 600), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser2", new Vector2(4220, 1200), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);

            //izquierda
            new UTGameObject("muralla_laser2", new Vector2(0, 180), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser2", new Vector2(0, 2000), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser2", new Vector2(0, 3000), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);

            
            //muralla de arriba
            new UTGameObject("muralla_laser", new Vector2(270, 0), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser", new Vector2(1010, 0), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser", new Vector2(1750, 0), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser", new Vector2(2490, 0), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser", new Vector2(3500, 0), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);

            //murallas de abajo
            new UTGameObject("muralla_laser", new Vector2(270, 2380), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser", new Vector2(1010, 2380), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser", new Vector2(1750, 2380), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser", new Vector2(2490, 2380), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);
            new UTGameObject("muralla_laser", new Vector2(3500, 2380), 0, 6, UTGameObject.FF_form.Rectangulo, true, false);

            

            camara2 = new Camara(new Vector2(0, 0), 1, 0);

            this.musica = Game1.INSTANCE.Content.Load<Song>("_ Ambient Space Music (No Copyright)");
            MediaPlayer.Play(this.musica);
            

        }
        public override void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            timeSpawnAgujeros += gameTime.ElapsedGameTime.TotalSeconds;
            //timespawn agujeros es la variable que se encarga de la cantidad de agujeros spawneados
            if (timeSpawnAgujeros > 4f)
            {

                new Enemigos("Nave", new Vector2(5000, rnd.Next((int)camara2.pos.Y + 100, (int)camara2.pos.Y - 1000 + Game1.INSTANCE.GraphicsDevice.Viewport.Height * 4)), .5f, 0, UTGameObject.FF_form.Circulo, false, true);
                new Coleccionable("meteoroooo", new Vector2(rnd.Next((int)camara2.pos.X + 100, (int)camara2.pos.X - 1000 + Game1.INSTANCE.GraphicsDevice.Viewport.Width * 4), -2400 + 600 + Game1.INSTANCE.GraphicsDevice.Viewport.Height * 2), .5f, 0, UTGameObject.FF_form.Circulo, false, true);
                timeSpawnAgujeros = 0;
            }
            if (listaAgujeros.Count > 0)
            {
                if (listaAgujeros.First<Coleccionable>().objetoFisico.pos.X < camara2.pos.X - 200)
                {
                    listaAgujeros.First<Coleccionable>().Destroy();
                    listaAgujeros.Remove(listaAgujeros.First<Coleccionable>());
                }
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && timer <=0)
            {
                shoot.Play();
                new Bullet("bullet",playerUTG.objetoFisico.pos, 0, 0.5f, UTGameObject.FF_form.Rectangulo,false);
                timer = 1f;
            }


        }
    }
}
