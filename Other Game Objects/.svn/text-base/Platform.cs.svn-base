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
    public class Platform : StationarySprite
    {
        static Random RNG = new Random();
        static Texture2D terrain;
        const int HEIGHT = 500;

        public int[] heights;

        public Platform(int x, int y, int width, int height, int minH, int maxH, int res)
            :
            base(null, new Vector2(x, y), new Vector2(width, height))
        {
            heights = new int[(int)dim.X];
            heights[heights.Length - 1] = 0;
            heights[0] = 0;
            Curve c=new Curve();
            for (int i = res; i< heights.Length; i += res)
            {
                heights[i] = RNG.Next(minH, maxH);
                c.Keys.Add(new CurveKey(i, heights[i]));
            }
            for (int i = 0; i < heights.Length; i++)
            {
                heights[i] = (int)c.Evaluate(i);
            }
            redoCurve();
        }

        public static void setImages(Texture2D t)
        {
            terrain = t;
        }
        public void setImg(Texture2D i)
        {
            img = i;
        }
        public override void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            drawer.Draw(base.img, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), Color.White);
            for (int i = 0; i < heights.Length; i++)
            {
                drawer.Draw(terrain, new Rectangle(i + (int)pos.X,
                    (int)pos.Y - heights[i], 1, heights[i]),
                    null, Color.White);
            }
        }
        public override Boolean intersects(StationarySprite other)
        {
            return (base.intersects(other)
                    ||
                    intersectsHill(other));
        }
        public Boolean intersectsBase(StationarySprite other)
        {
            return base.intersects(other);
        }
        

        public Boolean intersectsHill(StationarySprite other)
        {
            for (int i = 0; i < heights.Length; i++)
                if (new Rectangle(i + (int)pos.X, (int)pos.Y - heights[i], 1, heights[i]).Intersects(
                    new Rectangle((int)other.pos.X, (int)other.pos.Y, (int)other.dim.X, (int)other.dim.Y)))
                    return true;
            return false;

        }
        public int maxHeight(int low, int high)
        {
            low -= (int)pos.X; high -= (int)pos.X;
            low = Math.Max(low, 0);
            high = Math.Min(high, (int)dim.X - 1);
            int max = 0;
            for (int i = low; i <= high; i++)
                if (heights[i] > max) max = heights[i];
            return max;
        }

        public void dmg(int low, int high, int damage)
        {
            low -= (int)pos.X; high -= (int)pos.X;
            low = Math.Max(low, 0);
            high = Math.Min(high, (int)dim.X - 1);
            for (int i = low; i <= high; i++)
                heights[i] = Math.Max(heights[i] - damage, 1);
            redoCurve();
        }
        public override float getYAbove(GravitySprite player)
        {
            return pos.Y - maxHeight((int)player.pos.X,(int)(player.pos.X + player.dim.X)-1);
        }

        public void redoCurve()
        {
            Curve c = new Curve();
            for (int i=0; i<heights.Length; i+=25)
                c.Keys.Add(new CurveKey(i, heights[i]));
            for (int i = 0; i < heights.Length; i++)
                heights[i] = (int)c.Evaluate(i);
        }
    }
}
