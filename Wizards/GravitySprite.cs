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

/// <summary>
/// Summary description for Class1
/// </summary>
namespace WizardWars
{
    public class GravitySprite : StationarySprite
    {
        static WizardWars game;

        const int WIND = 500;

        public Platform landed;
        public int jumps;

        public Vector2 speed;
        public DateTime time;

        public GravitySprite(Texture2D img, Vector2 pos, Vector2 dim, Vector2 speed)
            : base(img, pos+new Vector2(0,-5), dim)
        {
            this.speed = speed;
        }
        public static void setGame(WizardWars g) { game = g; }
        public virtual void UpdateSprite(GraphicsDevice graphics, GameTime gameTime,
            int multiplier)
        {
            // Move the sprite by speed, scaled by elapsed time.


            pos += multiplier*speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int MaxX = graphics.Viewport.Width - (int)dim.X;
            int MinX = 0;
            int MaxY = graphics.Viewport.Height - (int)dim.Y;
            int MinY = 0;

                speed.X +=multiplier*game.isInWindArea(this) * WIND * 
                    (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (landed == null)
            {
                speed.Y += multiplier*game.getGravity(this) * 
                    (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (speed.X > 0) speed.X = Math.Max(speed.X - multiplier*game.getAirFriction(this) *
                    (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                else speed.X = Math.Min(speed.X + multiplier * game.getAirFriction(this)
                                * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            else
            {
                speed.Y += multiplier * game.getLandGravity(this) * 
                    (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (speed.X > 0) speed.X = Math.Max(speed.X - multiplier * game.getLandFriction(this) *
                    (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                else speed.X = Math.Min(speed.X + multiplier * game.getLandFriction(this)
                                    * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
                jumps = 0;
            }

            if (landed != null && ((pos.X + dim.X < landed.pos.X || pos.X > landed.pos.X + landed.dim.X)
                || pos.Y+dim.Y!=landed.getYAbove(this)))
                landed = null;


            // Check for bounce.
            if (pos.X > MaxX)
            {
                if (this is Projectile) speed.X *= -1;
                else speed.X *=-.7f;
                pos.X = MaxX;
            }

            else if (pos.X < MinX)
            {
                if (this is Projectile) speed.X *= -1;
                else speed.X *=-.7f;
                pos.X = MinX;
            }

            if (pos.Y > MaxY)
            {
                speed.Y = 0;
                if (!(this is Projectile))
                {
                    pos.Y = MaxY;
                    land(Ground.get());
                }

            }

            else if (pos.Y < MinY)
            {
                speed.Y =0;
                pos.Y = MinY;
            }
        }
        public void land(Platform landed)
        {
            this.landed = landed;
            speed = new Vector2((float)(speed.X * .5), 0f);
            pos.Y = landed.getYAbove(this) - dim.Y;
        }
        public Boolean isRightOf(GameTime gameTime,StationarySprite b)
        {
            return speed.X < 0 && pos.X - speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds
                > b.pos.X + b.dim.X;
        }
        public Boolean isLeftOf(GameTime gameTime, StationarySprite b)
        {
            return speed.X > 0 && dim.X + pos.X
                - 2 * speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds
                < b.pos.X;
        }
        public Boolean isAbove(GameTime gameTime, StationarySprite b)
        {
            float newY = (float)pos.Y - speed.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            float newX = (float)pos.X - speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            return speed.Y > 0 && newY + dim.Y < b.pos.Y -
                        (b is Platform ? (b as Platform).maxHeight((int)newX, (int)(newX + dim.X)) : 0)
                        + dim.Y;
        }
        public void collide(GameTime gameTime, Platform b)
        {
           // b = b as Platform;
            if (isRightOf(gameTime, b))
            {
                pos.X = b.pos.X + b.dim.X + 1;
                speed.X = 0;
                return;
            }
            if (isLeftOf(gameTime, b))
            {
                pos.X = b.pos.X - 1 - dim.X;
                speed.X = 0;
                return;
            }
            if (isAbove(gameTime, b))
                land(b);
        }

    }
}