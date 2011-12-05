#region File Description
//-----------------------------------------------------------------------------
// BackgroundScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace WizardWars
{
    /// <summary>
    /// Called when the game is over
    /// </summary>
    class EndingScreen : MenuScreen
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public EndingScreen(int s1,int s2) : base("Ending")
        {
            ScreenManager.graphicsManager.IsFullScreen = false; ScreenManager.graphicsManager.ApplyChanges();
            MenuEntries.Add(new MenuEntry("Player 1's Score: "+s1));
            MenuEntries.Add(new MenuEntry("Player 2's Score: "+s2));
            if (s1 == s2) MenuEntries.Add(new MenuEntry("Draw!"));
            else MenuEntries.Add(new MenuEntry("Player "+(s1>s2?"1":"2")+" wins!"));
            MenuEntry backMenuEntry = new MenuEntry("To Main Menu");
            backMenuEntry.Selected += toMainMenu; backMenuEntry.Reversed += toMainMenu;
            MenuEntries.Add(backMenuEntry);
        }
        void toMainMenu(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new MainMenuScreen());
        }
    }
}
