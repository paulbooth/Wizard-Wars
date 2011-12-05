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
    public class StationarySprite
    {
        public Texture2D img;
        public Vector2 pos;
        public Vector2 dim;

        public StationarySprite(Texture2D img, Vector2 pos, Vector2 dim)
        {
            this.img = img;
            this.pos = pos;
            this.dim = dim;
        }
        public StationarySprite(StationarySprite a)
        {
            img = a.img;
            pos = a.pos;
            dim = a.dim;
        }
        public virtual Boolean intersects(StationarySprite other)
        {
            return new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y).Intersects(
                   new Rectangle((int)other.pos.X, (int)other.pos.Y,
                        (int)(other.dim.X), (int)(other.dim.Y)));
        }
        public virtual Boolean intersects(Rectangle rect)
        {
            return new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y).Intersects(
                   rect);
        }
        public virtual void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            drawer.Draw(img, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y)
                , null, Color.White, 0, new Vector2(dim.X / 2, dim.Y / 2),
                 SpriteEffects.None, 0);
        }

        public virtual float getYAbove(GravitySprite a)
        {
             return pos.Y - 1;
        }
        public static void draw(StationarySprite a,SpriteBatch drawer, GraphicsDevice graphics,
            SpriteEffects effect, float rot, float depth)
        {
            drawer.Draw(a.img, new Rectangle((int)a.pos.X, (int)a.pos.Y, (int)a.dim.X, (int)a.dim.Y)
                , null, Color.White, rot, new Vector2(a.dim.X / 2, a.dim.Y / 2),
                 effect, depth);
        }

        public Vector2 getCenter()
        {
            return new Vector2(pos.X + dim.X / 2, pos.Y + dim.Y / 2);
        }
        public float distance(StationarySprite other)
        {
            double xDist = Math.Abs(getCenter().X-other.getCenter().X);
            double yDist = Math.Abs(getCenter().Y-other.getCenter().Y);
            return (float)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
        }
        public static float distance(Vector2 a,Vector2 b)
        {
            double xDist = Math.Abs(a.X - b.X);
            double yDist = Math.Abs(a.Y - b.Y);
            return (float)Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2));
        }
        public Rectangle getRect()
        {
            return new Rectangle((int)pos.X,(int)pos.Y,(int)dim.X,(int)dim.Y);
        }
    }
}
