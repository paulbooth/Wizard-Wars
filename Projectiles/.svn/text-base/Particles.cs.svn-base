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
    public class Particles
    {
        Vector2 pos;
        
        Texture2D texture;
        Random RNG;
        public int lifetime;
        public Particles(Vector2 inpos, Texture2D intext, int lifeMax)
        {
            RNG = new Random((Int32) DateTime.Now.Millisecond);

            pos = inpos;
            texture = intext;
            lifetime = RNG.Next(6, lifeMax);
        }
        public void Wander()
        {
            pos.X += RNG.Next(-1, 2);
            pos.Y += RNG.Next(-2, 2);
            lifetime--;

        }
        public void Rise()
        {
            pos.X += RNG.Next(-1, 2);
            pos.Y -= RNG.Next(1, 3);
            lifetime--;
        }

        public void Fall()
        {
            pos.X += RNG.Next(-1, 2);
            pos.Y += RNG.Next(1, 3);
            lifetime--;

        }
        public void Blow(Boolean left)
        {
            if (left)
            {
                pos.X -= RNG.Next(1, 5);
                pos.Y += RNG.Next(-2, 3);
                lifetime--;
            }
            else
            {
                pos.X += RNG.Next(1, 5);
                pos.Y += RNG.Next(-2, 3);
                lifetime--;
            }


        }
        public void Nothing()
        {
            lifetime--;
        }

        public void DrawSelf(SpriteBatch drawer, GraphicsDevice graphics, int w, int h)
        {
            drawer.Draw(texture, new Rectangle((int)pos.X,(int)pos.Y,w,h), Color.White);
        }
        public void DrawSelf(SpriteBatch drawer, GraphicsDevice graphics, int w, int h, float depth)
        {
            //drawer.Draw(texture, new Rectangle((int)pos.X, (int)pos.Y, w, h), Color.White);
            drawer.Draw(texture, new Rectangle((int)pos.X, (int)pos.Y, w, h), null, Color.White,
                0, new Vector2((int)(pos.X + w / 2), (int)(pos.Y + h / 2)), SpriteEffects.None, depth);
        
        }
    }
}
