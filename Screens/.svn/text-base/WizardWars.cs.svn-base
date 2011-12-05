//Copyrighted 2008 by Team Captain Falcon
//TODO : Projectiles can blow up in the air
//All units are in pixels/second


using System;
using System.Timers;
using System.Collections.Generic;
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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class WizardWars : GameScreen
    {
        static float GRAVITY = 500;                 //People in the air go down
        static float GROUND_FRICTION = 150;         //Horizontal speeds tend to zero on land by 150px/s
        static float AIR_FRICTION = 100;            //Horizontal speeds tend to zero in air by 100px/s
        static int MAX_SCORE=0;                     //Score to win
        static DateTime END_TIME=DateTime.MinValue; //Time when game ends

        GraphicsDevice graphics;
        SpriteBatch spriteBatch;
        ContentManager content;

        SpriteFont font;
        SpriteFont timeFont;

        Texture2D stun;
        Texture2D background;
        Texture2D wizard;
        Texture2D red;
        Texture2D openRect;
        DateTime FXtime;
        Texture2D DweomerImg;
        public Texture2D black;

        public Boolean drawLightning;
        Texture2D lightning;
        public Vector2 lightningPos;
        public Vector2 lightningDim;

        Random RNG = new Random();

        public Player[] players = new Player[2];
        List<Platform> platforms = new List<Platform>();
        List<Projectile> projectiles = new List<Projectile>();
        List<Area> areas = new List<Area>();
        List<GravitySprite> gravSprites = new List<GravitySprite>();
        Dweomer dweomer;
        public PortalArea[] portals = new PortalArea[2];
        public WizardWars()
        {
            GravitySprite.setGame(this);

            //Set Ending Condition
            MAX_SCORE = OptionsMenuScreen.getMaxScore();
            if (MAX_SCORE == 0)
                END_TIME = DateTime.Now.AddSeconds(OptionsMenuScreen.getTime());
            else END_TIME = DateTime.MinValue;

            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            content.RootDirectory = "Content";
            graphics = ScreenManager.GraphicsDevice;

            Vector2 screensize = OptionsMenuScreen.getScreensize();
            if (screensize.Equals(new Vector2(-1, -1)))
            {
                screensize = new Vector2(graphics.DisplayMode.Width, graphics.DisplayMode.Height);
                ScreenManager.graphicsManager.IsFullScreen = true;
            }
            else ScreenManager.graphicsManager.IsFullScreen = false;
            ScreenManager.graphicsManager.PreferredBackBufferHeight = (int)screensize.Y;
            ScreenManager.graphicsManager.PreferredBackBufferWidth = (int)screensize.X;
            ScreenManager.graphicsManager.ApplyChanges();

            //stops music and starts new music
            AudioManager.PlayMusic("Battle");

            stun = content.Load<Texture2D>("Stun");
            red = content.Load<Texture2D>("red");
            openRect = content.Load<Texture2D>("timebox");
            timeFont = content.Load<SpriteFont>("timefont");
            wizard = content.Load<Texture2D>("wizard");
            DweomerImg = content.Load<Texture2D>("dweomer");
            lightning = content.Load<Texture2D>("lightning");
            Platform.setImages(content.Load<Texture2D>("grass"));
            
            //Set Projectiles images and effects
            //Image = setImage/IMG
            //Effect = SetTexture
            TStopBall.setImages(content.Load<Texture2D>("clock"));
                TStopBall.setTexture(content.Load<Texture2D>("clock"));
            PortalBall.setImg(content.Load<Texture2D>("portalball"));
                PortalBall.setTexture(content.Load<Texture2D>("graveffect"));
            SpeedBall.setImage(content.Load<Texture2D>("clock"));
                SpeedBall.setTexture(content.Load<Texture2D>("graveffect"));
            FireBall.setIMG(content.Load<Texture2D>("fireball"));
                FireBall.setTexture(content.Load<Texture2D>("graveffect"));
            stalagball.setIMG(content.Load<Texture2D>("dirtball"));
                stalagball.setTexture(content.Load<Texture2D>("fireeffect"));
            pitball.setIMG(content.Load<Texture2D>("dirtball"));
                pitball.setTexture(content.Load<Texture2D>("fireeffect"));
            LightningBall.setImages(content.Load<Texture2D>("lightningball"),
                content.Load<Texture2D>("lightning"));
                LightningBall.setTexture(content.Load<Texture2D>("iceeffect"));
            WindBall.setImage(content.Load<Texture2D>("windball"));
                WindBall.setTexture(content.Load<Texture2D>("iceeffect"));
            SmokeBall.setImages(content.Load<Texture2D>("bomb"));
                SmokeBall.setTexture(content.Load<Texture2D>("fireeffect"));
            ReverseBall.setImg(content.Load<Texture2D>("gravityball"));
            ReverseBall.setTexture(content.Load<Texture2D>("graveffect"));
            HeavyBall.setImg(content.Load<Texture2D>("gravityball"));
            HeavyBall.setTexture(content.Load<Texture2D>("graveffect"));
            black = content.Load<Texture2D>("black");

            //Set Area Textures
            PortalArea.setImages(content.Load<Texture2D>("portal1"),
                content.Load<Texture2D>("portal2"));
            Area.SetFX(content.Load<Texture2D>("arrow"),
                content.Load<Texture2D>("reversearrow"),
                content.Load<Texture2D>("clock"),
                content.Load<Texture2D>("leaf1"),
                content.Load<Texture2D>("leaf2"),
                content.Load<Texture2D>("leaf3"),
                content.Load<Texture2D>("leaf4"),
                content.Load<Texture2D>("smoke")
                );
            
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = ScreenManager.SpriteBatch;

            //Make the ground
            Ground.setGround(new Platform(0, graphics.Viewport.Height,
                    graphics.Viewport.Width,
                    1, 100/*Min Terrain Height*/, 200/*Max Terrain Height*/,50));
            Ground.get().setImg(content.Load<Texture2D>("metalplat"));
            platforms.Add(Ground.get());
           
            //Add Platforms
            //platform = number of platforms to be created
            for (int i = graphics.Viewport.Height-250; i > 120; i-=150)
            {
                for (int j=0; j<RNG.Next(1,4); j++)
                    addPlatform(i);
            }
            //Make Font
            font = content.Load<SpriteFont>("font");

            //load projectile textures and effects
            //FireWizard.SetTextures(content.Load<Texture2D>("fireball"), content.Load<Texture2D>("fireeffect"),content.Load<Texture2D>("fireball"), content.Load<Texture2D>("fireeffect"));

            //backgound image
            background = content.Load<Texture2D>("background");
//*****************************************************************
            players[0] = createPlayer(OptionsMenuScreen.getP1Class(), wizard, platforms, 
                OptionsMenuScreen.getP1Power(), 0);
            players[1] = createPlayer(OptionsMenuScreen.getP2Class(), wizard, platforms, 
               OptionsMenuScreen.getP2Power(), 1);
//*************************************
            respawnDweomer();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
            // Allows the game to exit
            if (IsActive)
            {
                int multiplier;

                //Move gravity sprites (players, the dweomer, and projectiles)
                gravSprites = getGravs();
                foreach (GravitySprite p in gravSprites)
                {
                    multiplier = 1;
                    if (timeSpeed(p)) multiplier = 2;
                    if (timeStop(p) && !(p is TimeWizard)) multiplier = 0;
                    p.UpdateSprite(graphics, gameTime, multiplier);
                }

                //Update projecctile effects and kill dead projectiles
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].UpdateFX();
                    if (FXtime.AddMilliseconds(10).CompareTo(DateTime.Now) < 0)
                    {
                        projectiles[i].MakeEffect();
                    }
                    if (!projectiles[i].alive)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }

                //Update area effects and kill dead areas
                for (int i = 0; i < areas.Count; i++)
                {
                    areas[i].UpdateFX();
                    if (FXtime.AddMilliseconds(10).CompareTo(DateTime.Now) < 0)
                    {
                        areas[i].MakeEffects();
                    }

                    if (areas[i].creation.AddMilliseconds(areas[i].lifetime).CompareTo(DateTime.Now) < 0)
                        areas[i] = null;
                }
                while (areas.Remove(null)) ;

                FXtime = DateTime.Now;

                //Check platform collisions (players, dweomer, and projectiles)
                for (int i = 0; i < platforms.Count; i++)
                {
                    for (int j = 0; j < players.Length; j++)
                        if (platforms[i].intersects(players[j]))
                            players[j].collide(gameTime, platforms[i]);
                    if (platforms[i].intersects(dweomer))
                        dweomer.collide(gameTime, platforms[i]);
                    for (int j = 0; j < projectiles.Count; j++)
                        if (platforms[i].intersects(projectiles[j]))
                        {
                            explode(j, i);
                        }

                    // else if (platforms[i].intersectsBase(projectiles[j])) projectiles[j].die();
                }

                //runs through the players
                for (int j = 0; j < players.Length; j++)
                {
                    for (int i = 0; i < projectiles.Count; i++)//checks for hit with fireballs
                        if (projectiles[i] is FireBall && ((projectiles[i] as FireBall).plnum != j) && players[j].intersects(projectiles[i]))
                            projectiles[i].explode(platforms, gravSprites);

                    if (players[j].intersects(dweomer))//checks dweomer stuff
                    {
                        players[j].score += dweomer.value;
                        respawnDweomer();
                    }
                    //Checks if Game is Over
                    if ((MAX_SCORE!=0 && players[j].score >= MAX_SCORE) || 
                        (END_TIME.CompareTo(DateTime.MinValue)!=0 &&
                            DateTime.Now.CompareTo(END_TIME)>0))
                    {
                        ScreenManager.AddScreen(new BackgroundScreen());
                        ScreenManager.AddScreen(new EndingScreen(players[0].score,players[1].score));
                    }
                    if (Ground.get().intersects(players[j]))// checks if in ground
                        players[j].land(Ground.get());
                }

                //Check for portal intersections
                if (portals[0] != null && portals[1] != null)
                    for (int i = 0; i < gravSprites.Count; i++)
                        for (int j = 0; j < portals.Length; j++)
                        {
                            GravitySprite p = gravSprites[i];
                            PortalArea dest = portals[j == 0 ? 1 : 0];
                            if (portals[j].intersects(p))
                            {
                                p.speed.Y *= -1;
                                p.pos = new Vector2(dest.pos.X + (p.speed.X > 0 ? dest.dim.X : -p.dim.X),
                                    dest.pos.Y + (p.speed.Y > 0 ? dest.dim.Y : -p.dim.Y));
                            }
                        }
///888888888888MOVEMENT
                //XBOX Controls
                GamePadState gamepad = GamePad.GetState(PlayerIndex.One);
                if (DateTime.Now.CompareTo(players[0].stun) > 0)
                {
                    multiplier = 1;
                    if (timeSpeed(players[0]))
                        multiplier = 2;
                    if (timeStop(players[0]) && !(players[0] is TimeWizard)) multiplier = 0;
                    Vector2 movement = gamepad.ThumbSticks.Left;
                    if (movement.Y < -.7) players[0].moveDown();
                    if (movement.Y > .7) players[0].moveUp(multiplier);
                    if (movement.X < -.7) players[0].moveLeft(multiplier);
                    if (movement.X > .7) players[0].moveRight(multiplier);

                    if (gamepad.DPad.Left == ButtonState.Pressed) players[0].moveLeft(multiplier);
                    if (gamepad.DPad.Right == ButtonState.Pressed) players[0].moveRight(multiplier);
                    if (gamepad.DPad.Up == ButtonState.Pressed) players[0].moveUp(multiplier);
                    if (gamepad.DPad.Down == ButtonState.Pressed) players[0].moveDown();
                    if (gamepad.Buttons.A == ButtonState.Pressed||
                        gamepad.Buttons.LeftStick == ButtonState.Pressed
                        || gamepad.Buttons.RightStick == ButtonState.Pressed
                        ) players[0].moveUp(multiplier);
                    if (!timeStop(players[0]) || players[0] is TimeWizard)
                        if (gamepad.Triggers.Right > .7f) projectiles.Add(players[0].ability1());
                    if (!timeStop(players[0]) || players[0] is TimeWizard)
                        if (gamepad.Triggers.Left > .7f) projectiles.Add(players[0].ability2());
                    if (!timeStop(players[0]) || players[0] is TimeWizard)
                        if (gamepad.Buttons.B == ButtonState.Pressed) players[0].punch(gravSprites);
                }
                if (gamepad.Buttons.Start == ButtonState.Pressed) ScreenManager.AddScreen(new PauseMenuScreen());
                gamepad = GamePad.GetState(PlayerIndex.Two);

                if (DateTime.Now.CompareTo(players[1].stun) > 0)
                {
                    multiplier = 1;
                    if (timeSpeed(players[1]))
                        multiplier = 2;
                    if (timeStop(players[1]) && !(players[1] is TimeWizard)) multiplier = 0;

                    Vector2 movement = gamepad.ThumbSticks.Left;
                    if (movement.Y < -.7) players[1].moveDown();
                    if (movement.Y > .7) players[1].moveUp(multiplier);
                    if (movement.X < -.7) players[1].moveLeft(multiplier);
                    if (movement.X > .7) players[1].moveRight(multiplier);
                    if (gamepad.DPad.Left == ButtonState.Pressed) players[1].moveLeft(multiplier);
                    if (gamepad.DPad.Right == ButtonState.Pressed) players[1].moveRight(multiplier);
                    if (gamepad.DPad.Up == ButtonState.Pressed) players[1].moveUp(multiplier);
                    if (gamepad.DPad.Down == ButtonState.Pressed) players[1].moveDown();

                    if (gamepad.Buttons.A == ButtonState.Pressed ||
                        gamepad.Buttons.LeftStick == ButtonState.Pressed
                        || gamepad.Buttons.RightStick == ButtonState.Pressed
                        ) players[1].moveUp(multiplier);
                    if (!timeStop(players[1]) || players[1] is TimeWizard)
                        if (gamepad.Triggers.Right >.7f) projectiles.Add(players[1].ability1());
                    if (!timeStop(players[1]) || players[1] is TimeWizard)
                        if (gamepad.Triggers.Left > .7f) projectiles.Add(players[1].ability2());
                    if (!timeStop(players[1]) || players[1] is TimeWizard)
                        if (gamepad.Buttons.B == ButtonState.Pressed) players[1].punch(gravSprites);

                }
               if (gamepad.Buttons.Start== ButtonState.Pressed) ScreenManager.AddScreen(new PauseMenuScreen());
#if !XBOX
                //PC Controls
                KeyboardState keys = Keyboard.GetState();
                if (DateTime.Now.CompareTo(players[0].stun) > 0)
                {
                    GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
                    multiplier = 1;
                    if (timeSpeed(players[0]))
                        multiplier = 3;
                    if (timeStop(players[0]) && !(players[0] is TimeWizard)) multiplier = 0;

                    if (keys.IsKeyDown(Keys.Down)) players[0].moveDown();
                    if (keys.IsKeyDown(Keys.Up)) players[0].moveUp(multiplier);
                    if (keys.IsKeyDown(Keys.Left)) players[0].moveLeft(multiplier);
                    if (keys.IsKeyDown(Keys.Right)) players[0].moveRight(multiplier);
                    if (!timeStop(players[0]) || players[0] is TimeWizard)
                        if (keys.IsKeyDown(Keys.L)) projectiles.Add(players[0].ability1());
                    if (!timeStop(players[0]) || players[0] is TimeWizard)
                        if (keys.IsKeyDown(Keys.K)) projectiles.Add(players[0].ability2());
                    if (keys.IsKeyDown(Keys.I)) players[0].punch(gravSprites);
                }
                if (players.Length > 1 && DateTime.Now.CompareTo(players[1].stun) > 0)
                {
                    GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
                    multiplier = 1;
                    if (timeSpeed(players[1]))
                        multiplier = 3;
                    if (timeStop(players[1]) && !(players[1] is TimeWizard)) multiplier = 0;

                    if (keys.IsKeyDown(Keys.S)) players[1].moveDown();
                    if (keys.IsKeyDown(Keys.W)) players[1].moveUp(multiplier);
                    if (keys.IsKeyDown(Keys.A)) players[1].moveLeft(multiplier);
                    if (keys.IsKeyDown(Keys.D)) players[1].moveRight(multiplier);
                    if (!timeStop(players[1]) || players[1] is TimeWizard)
                        if (keys.IsKeyDown(Keys.F)) projectiles.Add(players[1].ability1());
                    if (!timeStop(players[1]) || players[1] is TimeWizard)
                        if (keys.IsKeyDown(Keys.G)) projectiles.Add(players[1].ability2());
                    if (keys.IsKeyDown(Keys.R)) players[1].punch(gravSprites);
                }

                if (keys.IsKeyDown(Keys.P)) ScreenManager.AddScreen(new PauseMenuScreen());
                if (keys.IsKeyDown(Keys.O))
                {
                    ScreenManager.graphicsManager.IsFullScreen = !ScreenManager.graphicsManager.IsFullScreen;
                    ScreenManager.graphicsManager.ApplyChanges();
                }
                Player.setKeys(keys.GetPressedKeys());
#endif
                //Kill dead projectiles
                while (projectiles.Contains(null))
                {
                    projectiles.Remove(null);
                }

            }
        }

        /// : <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            graphics.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            //draws the background
            spriteBatch.Draw(
                background,
                new Rectangle(0, 0, graphics.Viewport.Width, 
                graphics.Viewport.Height),
                Color.White);

            //Draw Areas
            foreach (Area r in areas) r.draw(spriteBatch, graphics);

            //Draw the lightning if necessary
            if (drawLightning)
            {
                spriteBatch.Draw(lightning, new Rectangle((int)lightningPos.X,
                    (int)lightningPos.Y,(int)lightningDim.X,(int)lightningDim.Y), Color.White);
                drawLightning = false;
            }

            //Draw portals if they exist
            for (int i = 0; i < portals.Length; i++) if (portals[i]!=null) portals[i].draw(spriteBatch, i);
            
            //Draw Projectiles
            foreach (Projectile p in projectiles) p.drawParticles(spriteBatch, graphics);

            //DRAW PLATFORMS
            foreach(Platform p in platforms)
                p.draw(spriteBatch, graphics);
            
            //DRAW SPRITES
            List<StationarySprite> all = All(); 
            for (int i = 0; i < all.Count; i++)
                all[i].draw(spriteBatch, graphics);
            
            //Draw stun halos
            foreach (Player p in players)
                if (DateTime.Now.CompareTo(p.stun) < 0)
                    spriteBatch.Draw(stun, new Rectangle((int)p.pos.X-20, (int)p.pos.Y - 50, 50, 50), Color.White);
            
            //DRAW AREAS
            foreach (Area r in areas) if (r is SmokeArea) r.draw(spriteBatch, graphics);

            //Draw Scoring Rectangles
            if (MAX_SCORE != 0)
            {
                spriteBatch.Draw(openRect, new Rectangle(0, 0, 300, 30), Color.White);
                spriteBatch.Draw(red, new Rectangle(5, 5, 280 * players[1].score / MAX_SCORE, 21)
                    , Color.White);
                spriteBatch.DrawString(font, players[1].score + "/" + 
                    MAX_SCORE, new Vector2(120,4), Color.White);
                spriteBatch.DrawString(font, "Player 2's Score", new Vector2(80, 34), Color.White);
            

                spriteBatch.Draw(openRect, new Rectangle(graphics.Viewport.Width-300, 0, 300, 30), Color.White);
                spriteBatch.Draw(red, new Rectangle(graphics.Viewport.Width - 295, 5, 280 * 
                    players[0].score / MAX_SCORE, 21), Color.White);
                spriteBatch.DrawString(font, players[0].score + "/" +
                       MAX_SCORE, new Vector2(graphics.Viewport.Width-150, 4), Color.White);
                spriteBatch.DrawString(font, "Player 1's Score", 
                    new Vector2(graphics.Viewport.Width-190, 34), Color.White);

            }

            //Draw time till end and score
            if (END_TIME != DateTime.MinValue)
            {
                TimeSpan tr = END_TIME.Subtract(DateTime.Now);
                spriteBatch.DrawString(timeFont, tr.Minutes + ":" + (tr.Seconds<10?"0":"")+tr.Seconds,
                    new Vector2(graphics.Viewport.Width / 2, 0), Color.Black);
                spriteBatch.DrawString(timeFont, players[1].score + "", Vector2.Zero, Color.White);
                spriteBatch.DrawString(timeFont, players[0].score + "",
                    new Vector2(graphics.Viewport.Width - 20, 0), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        //Gets all the sprites (platforms, projectiles, dweomer, and players)
        public List<StationarySprite> All()
        {
            List<StationarySprite> all = new List<StationarySprite>();
            all.Add(Ground.get());
            for (int i=0; i<platforms.Count; i++)
                if (platforms[i]!=null) all.Add(platforms[i]);

            for (int i = 0; i < projectiles.Count; i++)
                if (projectiles[i] != null) all.Add(projectiles[i]);

            if (dweomer != null) all.Add(dweomer);

            for (int i = 0; i < players.Length; i++)
                if (players[i] != null) all.Add(players[i]);
            return all;
        }
        
        //Gets gravity sprites(dweomer, players,projectiles)
        public List<GravitySprite> getGravs()
        {
            List<GravitySprite> gravs = new List<GravitySprite>();
            gravs.Add(dweomer);
            foreach (Player p in players)
                gravs.Add(p);
            foreach (Projectile pr in projectiles)
                gravs.Add(pr);
            return gravs;
        }

        //Check whether a sprite intersects with anything
        public Boolean allIntersects(StationarySprite a)
        {
            List<StationarySprite> all = All();
            foreach (Area r in areas) all.Remove(r);
            for (int i = 0; i < all.Count; i++)
            {
                if (!all[i].Equals(a) && (all[i].intersects(a) || a.intersects(all[i])))
                    return true;
            }
            return false;
        }

        //Adds platform at a given height (the parameter)
        public void addPlatform(int y)
        {
            Boolean intersects;
            Double rand;
            do
            {
                platforms.Add(new Platform(
                    RNG.Next(5, graphics.Viewport.Width - 200), //X
                    y,            //Y
                    RNG.Next(150, 200), RNG.Next(20, 50),                   //Width + Height
                    0, 50,                //Min + Max Height
                    15)); //Platform res
                intersects = allIntersects(platforms[platforms.Count - 1]);
                if (intersects) platforms.RemoveAt(platforms.Count - 1);
            } while (intersects);

            //Pick a random platform texture
            rand = RNG.NextDouble();
            if (rand < 1.0 / 3) platforms[platforms.Count - 1].setImg(content.Load<Texture2D>("brickplat"));
            else if (rand < 2.0 / 3) platforms[platforms.Count - 1].setImg(content.Load<Texture2D>("woodplat"));
            else platforms[platforms.Count - 1].setImg(content.Load<Texture2D>("metalplat"));
        }

        //Respawns the dweomer
        public void respawnDweomer()
        {
            do
            {
                dweomer = new Dweomer(DweomerImg,
                            new Vector2(RNG.Next(0, graphics.Viewport.Width),
                            RNG.Next(0, graphics.Viewport.Height)),
                            new Vector2(30,30),
                            new Vector2(RNG.Next(-10, 10), RNG.Next(-10, 10)),
                            1, false);

            } while (allIntersects(dweomer));
        }

        //Checks whether a sprite (really a player) is in a wind area
        public int isInWindArea(StationarySprite a)
        {
            foreach (Area r in areas) if (r.intersects(a) && r is WindArea)
                {
                    WindArea ar = r as WindArea;
                    if(ar.left)
                        return -1;
                    else
                    {
                        return 1;
                    }
                }
            return 0;
        }

        //Checks whether a sprite is in a time-stopped area
        public Boolean timeStop(StationarySprite a)
        {
            foreach (Area r in areas) if (r.intersects(a) && r is TStopArea)
                    return true;
            return false;
        }
        public Boolean timeSpeed(StationarySprite a)
        {
            foreach (Area r in areas) if (r.intersects(a) && r is SpeedArea)
                    return true;
            return false;
        }

        //Gets the local gravity for a sprite
        public float getGravity(StationarySprite a)
        {
            foreach (Area r in areas)
                if (r.intersects(a)&& r is ReverseArea) return GRAVITY * -1;
            foreach (Area r in areas)
                if (r.intersects(a) && r is HeavyArea) return GRAVITY * 2;
            return GRAVITY;
        }

        //If a player is on land in an anti-grav area, they should go up
        public float getLandGravity(StationarySprite a)
        {
            foreach (Area r in areas)
                if (r.intersects(a) && r is ReverseArea) return GRAVITY * -.5f;
            return 0;
        }
        public float getLandFriction(StationarySprite a)
        {
            foreach (Area r in areas)
                if (r.intersects(a) && r is HeavyArea) return GROUND_FRICTION * 2;
            return GROUND_FRICTION;
        }
        public float getAirFriction(StationarySprite a)
        {
            foreach (Area r in areas)
                if (r.intersects(a) && r is HeavyArea) return AIR_FRICTION * 2;
            return AIR_FRICTION;
        }

        //Gets the earliest portal
        public int earlierPortal()
        {
            if (portals[0] == null) return 0;
            if (portals[1] == null) return 1;
            if (portals[0].timeStamp.CompareTo(portals[1].timeStamp) < 0) return 0;
            return 1;
        }

        //Explodes various projectiles
        public void explode(int projectileIndex, int platformIndex)
        {
            if (projectiles[projectileIndex] is FireBall) 
                projectiles[projectileIndex].
                       explode(platforms, gravSprites);
            else if (projectiles[projectileIndex] is ReverseBall)
                projectiles[projectileIndex].explode(areas);
            else if(projectiles[projectileIndex] is HeavyBall)
                projectiles[projectileIndex].explode(areas);
            else if (projectiles[projectileIndex] is WindBall)
                projectiles[projectileIndex].explode(areas);
            else if (projectiles[projectileIndex] is SmokeBall)
                projectiles[projectileIndex].explode(areas);
            else if (projectiles[projectileIndex] is LightningBall)
                projectiles[projectileIndex].explode(platforms,this);
            if (projectiles[projectileIndex] is pitball)
                projectiles[projectileIndex].explode(platforms[platformIndex]);
            if (projectiles[projectileIndex] is stalagball)
                projectiles[projectileIndex].explode(platforms[platformIndex]);
            if (projectiles[projectileIndex] is TStopBall)
                projectiles[projectileIndex].explode(areas);
            if (projectiles[projectileIndex] is SpeedBall)
                projectiles[projectileIndex].explode(areas);
            if (projectiles[projectileIndex] is PortalBall)
                projectiles[projectileIndex].explode(this);
            else projectiles[projectileIndex].die();
            AudioManager.PlayCue("Explode");
        }

        //Makes a player given their class
        public Player createPlayer(string type,Texture2D img,List<Platform> p,int power,int index)
        {
            switch (type)
            {
                case "Air": return new AirWizard(img, p, power, index);
                case "Earth": return new EarthWizard(img, p, power, index);
                case "Fire": return new FireWizard(img, p, power, index);
                case "Gravity": return new GravityWizard(img, p, power, index);
                case "Portal": return new PortalWizard(img, p, power, index);
                case "Time": return new TimeWizard(img, p, power, index);
                default: return null;
            }
        }
    }
}
