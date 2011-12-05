#region File Description
//-----------------------------------------------------------------------------
// OptionsMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
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

#endregion

namespace WizardWars
{
    /// <summary>
    /// The options screen is brought up over the top of the main menu
    /// screen, and gives the user a chance to configure the game
    /// in various hopefully useful ways.
    /// </summary>
    class OptionsMenuScreen : MenuScreen
    {
        #region Fields

        MenuEntry p1Class;
        MenuEntry p2Class;
        MenuEntry p1Power;
        MenuEntry p2Power;
        MenuEntry start;
        MenuEntry maxScore;
        MenuEntry condition;
        MenuEntry time;
        MenuEntry resolution;
        MenuEntry back;

        enum Wizard
        {
            Air,Earth,Fire,Gravity,Portal,Time
        }
        enum WinCondition
        {
            Score,Time
        }
        enum Resolution
        {
            Small,Medium,Large,Fullscreen
        }

        static Wizard wizard1 = Wizard.Time;
        static Wizard wizard2 = Wizard.Gravity;
        static WinCondition wc = WinCondition.Score;
        static Resolution res = Resolution.Fullscreen;

        static int max_score = 10;
        static int timeLimit = 60;
        static int p1pwr = 100;
        static int p2pwr = 100;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsMenuScreen()
            : base("Options")
        {
            wc = WinCondition.Score;

            // Create our menu entries.
            p1Class = new MenuEntry(string.Empty);
            p2Class = new MenuEntry(string.Empty);
            time = new MenuEntry(string.Empty);
            maxScore = new MenuEntry(string.Empty);
            condition = new MenuEntry(string.Empty);
            p1Power = new MenuEntry(string.Empty);
            p2Power = new MenuEntry(string.Empty);
            resolution = new MenuEntry(string.Empty);
            start = new MenuEntry("Start Game");
            back = new MenuEntry("Back");

            SetMenuEntryText();

            MenuEntry backMenuEntry = new MenuEntry("Back");

            // Hook up menu event handlers.
            start.Selected += startSelected;
            p1Class.Selected += p1ClassSelected; p1Class.Reversed += p1ClassDown;
            p2Class.Selected += p2ClassSelected; p2Class.Reversed += p2ClassDown;
            p1Power.Selected += p1PowerUp; p1Power.Reversed += p1PowerDown;
            p2Power.Selected += p2PowerUp; p2Power.Reversed += p2PowerDown;
            maxScore.Selected += maxScoreSelected; maxScore.Reversed += scoreDown;
            time.Selected += timeUp; time.Reversed += timeDown;
            condition.Selected += ConditionSelected; condition.Reversed += ConditionSelected;
            resolution.Selected += ResolutionUp; resolution.Reversed += ResolutionDown;
            back.Selected += toMainMenu;
            
            // Add entries to the menu.
            MenuEntries.Add(start);
            MenuEntries.Add(p1Class);
            MenuEntries.Add(p2Class);
            MenuEntries.Add(p1Power);
            MenuEntries.Add(p2Power);
#if !XBOX            
            MenuEntries.Add(resolution); 
#endif
            MenuEntries.Add(condition);
            MenuEntries.Add(maxScore);
            MenuEntries.Add(back);
        }
        void ResolutionUp(object sender, EventArgs e)
        {
            res++;
            if (res > Resolution.Fullscreen) res = Resolution.Small;
            SetMenuEntryText();
        }
        void ResolutionDown(object sender, EventArgs e)
        {
            res--;
            if (res < 0) res = Resolution.Fullscreen;
            SetMenuEntryText();
        }
        void startSelected(object sender, EventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, new WizardWars());
        }
        void toMainMenu(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new MainMenuScreen());
        }
        public void p1PowerUp(object sender, EventArgs e)
        {
            p1pwr += 10;
            SetMenuEntryText();
        }
        public void p1PowerDown(object sender, EventArgs e)
        {
            p1pwr -= 10;
            SetMenuEntryText();
        }
        public void p2PowerUp(object sender, EventArgs e)
        {
            p2pwr += 10;
            SetMenuEntryText();
        }
        public void p2PowerDown(object sender, EventArgs e)
        {
            p2pwr -= 10;
            SetMenuEntryText();
        }
        public void timeUp(object sender, EventArgs e)
        {
            timeLimit+=10;
            SetMenuEntryText();
        }
        public void timeDown(object sender, EventArgs e)
        {
            timeLimit-=10;
            SetMenuEntryText();
        }
        public void p1ClassDown(object sender, EventArgs e)
        {
            wizard1--;

            if (wizard1 < Wizard.Air)
                wizard1 = Wizard.Time;

            SetMenuEntryText();
        }
        public void p2ClassDown(object sender, EventArgs e)
        {
            wizard2--;

            if (wizard2 < Wizard.Air)
                wizard2 = Wizard.Time;

            SetMenuEntryText();
        }
        public void scoreDown(object sender, EventArgs e)
        {
            max_score--;
            SetMenuEntryText();
        }

        /// <summary>
        /// Fills in the latest values for the options screen menu text.
        /// </summary>
        void SetMenuEntryText()
        {
            p1Class.Text = "Player 1's Specialty:   " + wizard1;
            p2Class.Text = "Player 2's Specialty:   " + wizard2;
            p1Power.Text = "Player 1's Power: " + p1pwr;
            p2Power.Text = "Player 2's Power: " + p2pwr;
            resolution.Text = "Screen Size: " + res;
            condition.Text = "Win Condition: " + wc;
            maxScore.Text = "Score to Win: " + max_score;
            time.Text = "Game Length - " + timeLimit/60 + ": "+(timeLimit%60==0?"0":"")+timeLimit%60;
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Ungulate menu entry is selected.
        /// </summary>

        void ConditionSelected(object sender, EventArgs e)
        {
            if (wc == WinCondition.Score)
            {
                MenuEntries.Remove(maxScore);
                MenuEntries.Remove(back);
                MenuEntries.Add(time);
                MenuEntries.Add(back);
                wc = WinCondition.Time;
            }
            else if (wc == WinCondition.Time)
            {
                MenuEntries.Remove(time);
                MenuEntries.Remove(back);
                MenuEntries.Add(maxScore);
                MenuEntries.Add(back);
                wc = WinCondition.Score;
            }

            SetMenuEntryText();
        }
        void p1ClassSelected(object sender, EventArgs e)
        {
            wizard1++;

            if (wizard1 > Wizard.Time)
                wizard1 = 0;

            SetMenuEntryText();
        }
        void p2ClassSelected(object sender, EventArgs e)
        {
            wizard2++;

            if (wizard2 > Wizard.Time)
                wizard2 = 0;

            SetMenuEntryText();
        }

        void maxScoreSelected(object sender, EventArgs e)
        {
            max_score++;

            SetMenuEntryText();
        }

        public static string getP1Class()
        {
            switch (wizard1)
            {
                case Wizard.Air: return "Air";
                case Wizard.Earth: return "Earth";
                case Wizard.Fire: return "Fire";
                case Wizard.Gravity: return "Gravity";
                case Wizard.Portal: return "Portal";
                case Wizard.Time: return "Time";
                default: return "";
            }
        }
        public static string getP2Class()
        {
            switch (wizard2)
            {
                case Wizard.Air: return "Air";
                case Wizard.Earth: return "Earth";
                case Wizard.Fire: return "Fire";
                case Wizard.Gravity: return "Gravity";
                case Wizard.Portal: return "Portal";
                case Wizard.Time: return "Time";
                default: return "";
            }
        }
        public static int getMaxScore()
        {
            return wc==WinCondition.Score?max_score:0;
        }
        public static int getTime()
        {
            return wc == WinCondition.Time ? timeLimit : 0;
        }
        public static int getP1Power() { return p1pwr; }
        public static int getP2Power() { return p2pwr; }
        public static Vector2 getScreensize()
        {
            switch(res)
            {
                case Resolution.Small: return new Vector2(1000, 500);
                case Resolution.Medium: return new Vector2(1000, 700);
                case Resolution.Large: return new Vector2(1000, 900);
                case Resolution.Fullscreen: return new Vector2(-1, -1);
                default: return Vector2.Zero;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Player 1 Abilities", new Vector2(170, 480), Color.White);
            spriteBatch.DrawString(font, "Player 2 Abilities", new Vector2(430, 480), Color.White);

            switch (wizard1)
            {
                case Wizard.Air:
                    spriteBatch.DrawString(font, "Left Trigger/K: Lightning Bolt", new Vector2(100, 500),Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/L: Wind", new Vector2(100, 520), Color.White);
                break;
                case Wizard.Earth:
                    spriteBatch.DrawString(font, "Left Trigger/K: Create Earth", new Vector2(100, 500),Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/L: Destroy Earth", new Vector2(100, 520), Color.White);
                break;
                case Wizard.Fire:
                    spriteBatch.DrawString(font, "Left Trigger/K: Smoke", new Vector2(100, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/L: Fireball", new Vector2(100, 520), Color.White);
                break;
                case Wizard.Gravity:
                    spriteBatch.DrawString(font, "Left Trigger/K: Increase Gravity", new Vector2(100, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/L: Reverse Gravity", new Vector2(100, 520), Color.White);
                break;
                case Wizard.Portal:
                    spriteBatch.DrawString(font, "Left Trigger/K: Shoot Portal", new Vector2(100, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/L: Shoot Portal", new Vector2(100, 520), Color.White);
                break;
                case Wizard.Time:
                    spriteBatch.DrawString(font, "Left Trigger/K: Speed Time Up", new Vector2(100, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/L: Time Stop", new Vector2(100, 520), Color.White);
                break;
            }
            switch (wizard2)
            {
                case Wizard.Air:
                    spriteBatch.DrawString(font, "Left Trigger/F: Wind", new Vector2(350, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/G: Lightning Bolt", new Vector2(350, 520), Color.White);
                    break;
                case Wizard.Earth:
                    spriteBatch.DrawString(font, "Left Trigger/F: Destroy Earth", new Vector2(350, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/G: Create Earth", new Vector2(350, 520), Color.White);
                    break;
                case Wizard.Fire:
                    spriteBatch.DrawString(font, "Left Trigger/F: Fireball", new Vector2(350, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/G: Smoke", new Vector2(350, 520), Color.White);
                    break;
                case Wizard.Gravity:
                    spriteBatch.DrawString(font, "Left Trigger/F: Reverse Gravity", new Vector2(350, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/G: Increase Gravity", new Vector2(350, 520), Color.White);
                    break;
                case Wizard.Portal:
                    spriteBatch.DrawString(font, "Left Trigger/F: Shoot Portal", new Vector2(350, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/G: Shoot Portal", new Vector2(350, 520), Color.White);
                    break;
                case Wizard.Time:
                    spriteBatch.DrawString(font, "Left Trigger/F: Time Stop", new Vector2(350, 500), Color.White);
                    spriteBatch.DrawString(font, "Right Trigger/G: Speed Time Up", new Vector2(350, 520), Color.White);
                    break;
            }
            spriteBatch.End();
        }

        #endregion
    }
}
