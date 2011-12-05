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
        public override void LoadContent()
        {
        }
        public TimeWizardInfoScreen()
            :base("TimeWizard")
        {
            //spriteBatch.DrawString(font, "youuuu", Vector2.Zero, Color.Black);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Time Wizard: \n\nThe time wizard casts magical time balls to alter the time speed to his advantage. \nHis first attack spawns a giant time ball that freezes the enemy once he touches it. \nHis second atack launches millions of tiny time balls that speed up time within that \narea. This attack is traditionally used by the time wizard to speed himself up as \nhe races for the dweomer. Contrastingly, the giant time ball is normally used to \nimpede the opponent.       ", new Vector2(100, 350), Color.White);
            spriteBatch.End();
        }

    }
}
