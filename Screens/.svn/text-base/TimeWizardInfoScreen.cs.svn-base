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
    class TimeWizardInfoScreen : MenuScreen
    {
        MenuEntry back;
        public TimeWizardInfoScreen()
            :base("TimeWizard")
        {
            back = new MenuEntry("Backwards");
            back.Selected += toMainInstructions; back.Reversed += toMainInstructions;
            MenuEntries.Add(back);
        }
        void toMainInstructions(object sender, EventArgs e)
        {
            LoadingScreen.Load(ScreenManager, false, new InstructionsMenuScreen());
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Time Wizard:"+
            "\n\nThe time wizard has the ability to control the flow of the time-stream itself,"+
            "\nalthough only within a limited area. His first ability allows him to freeze time itself,"+
            "\nparalyzing everything within an area (except the time wizard himself) for several seconds."+
            "\nHis second ability speeds the flow of time in an area, making the time wizard more mobile"+
            "\nand allowing him to jump to truly colossal heights.", new Vector2(100, 350), Color.White);
            spriteBatch.End();
        }


    }
}
