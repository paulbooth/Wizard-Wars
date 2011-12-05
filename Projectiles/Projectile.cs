using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace WizardWars
{
    public class Projectile : GravitySprite
    {

        Random RNG = new Random();
        List<Particles> effects = new List<Particles>();
        public Boolean alive = true;
        protected float power;
        float rot = 0f;
        Texture2D FX;


        //inputs: img is the picture for the projectile, pos is start point, 
        //spd is velocity, fxtext is the texture for the effects 

        public Projectile(Texture2D img, Vector2 pos, Vector2 dim,
                Vector2 spd,float power, Texture2D inFX)
            : base(img, pos,dim, spd)
        {
            this.power = power;
            FX = inFX;
        }
        //makes the particles that just chill around
        public void MakeEffect()
        {
            for (int i = 0; i <= RNG.Next(5, 10); i++)
            {
                effects.Add(new Particles(new Vector2(pos.X + dim.X / 2, pos.Y + dim.Y / 2), FX, 20));
            }
        }
        //tells the particles to move and removes dead ones.
        public void UpdateFX()
        {
            for (int i = 0; i < effects.Count; i++)
            {
                effects[i].Wander();
                if (effects[i].lifetime == 0)
                    effects[i] = null;
            }
            while (effects.Contains(null))
                effects.Remove(null);
        }

        //goes through the particles and tells each one to draw itself.
        public void drawParticles(SpriteBatch drawer, GraphicsDevice graphics)
        {
            for (int i = 0; i < effects.Count; i++)
            {
                effects[i].DrawSelf(drawer, graphics,2,2);
            }
        }

        public virtual void explode(WizardWars game,Platform p)
        {
            die();
        }
        public virtual void explode(WizardWars game)
        {
            die();
        }
        public virtual void explode(List<Area> a)
        {
            die();
        }
        //FIRE BALL
        public virtual void explode(List<Platform> plats, List<GravitySprite> g)
        {
            die();
        }
        public virtual void explode(List<Platform> plats,WizardWars game)
        {
            die();
        }

        public virtual void explode(Platform p)
        {
            die();
        }

        public override void UpdateSprite(GraphicsDevice graphics, GameTime gameTime,
            int multiplier)
        {
            int MaxY = graphics.Viewport.Height - (int)dim.Y;
            if (pos.Y >= MaxY)
                die();
            else
                base.UpdateSprite(graphics, gameTime,multiplier);
        }
        public void die()
        {
            alive = false;
        }
        //draws projectiles
        public override void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            rot = (float)Math.Atan2(speed.Y, speed.X); //returns angle in radians
            drawer.Draw(img, new Vector2(pos.X+(dim.X/2),pos.Y+(dim.Y/2)),
                new Rectangle(0, 0, img.Width, img.Height),
                Color.White, rot, new Vector2(img.Width/2, img.Height/2),
                new Vector2(dim.X / img.Width, dim.Y / img.Height), SpriteEffects.None, 0f);
            drawParticles(drawer, graphics);
        }
    }
}
