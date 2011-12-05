#region File Description
//-----------------------------------------------------------------------------
// Game.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace WizardWars
{
    /// <summary>
    /// Sample showing how to manage different game states, with transitions
    /// between menu screens, a loading screen, the game itself, and a pause
    /// menu. This main game class is extremely simple: all the interesting
    /// stuff happens in the ScreenManager component.
    /// </summary>
    public class Menu : Microsoft.Xna.Framework.Game
    {
        #region Fields

        GraphicsDeviceManager graphics;
        ScreenManager screenManager;

        #endregion

        #region Initialization


        /// <summary>
        /// The main game constructor.
        /// </summary>
        public Menu()
        {
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);

            // Create the screen manager component.
            screenManager = new ScreenManager(this);
            ScreenManager.graphicsManager = graphics;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 900;

            Components.Add(screenManager);
            AudioManager.Initialize(this, @"Content\Wizard Wars.xgs",
                @"Content\Wave Bank.xwb", @"Content\Sound Bank.xsb");

            // Activate the first screens.
            screenManager.AddScreen(new BackgroundScreen());
            screenManager.AddScreen(new MainMenuScreen());
        }


        #endregion

        #region Draw


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            // The real drawing happens inside the screen manager component.
            base.Draw(gameTime);
        }


        #endregion
    }


    #region Entry Point

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static class Program
    {
        static void Main()
        {
            using (Menu game = new Menu())
            {
                game.Run();
            }
        }
    }

    #endregion
}
