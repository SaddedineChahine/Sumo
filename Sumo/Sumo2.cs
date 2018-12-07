using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;                                                          
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sumo
{
    class Sumo2
    {
        
        Texture2D texture;
        Vector2 vector;
        Vector2 speed;

        public Sumo2(Texture2D texture, float X, float Y, float speedX, float speedY)
        {
            this.texture = texture;
            this.vector.X = X;
            this.vector.Y = Y;
            this.speed.X = speedX;
            this.speed.Y = speedY;
            const float sumo_acc = 0.1f;
            const float sumo_max_speed = 4;
        }

        public void Update(GameWindow window)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (vector.X <= window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.D))
                    vector.X += speed.X;
                if (keyboardState.IsKeyDown(Keys.A))
                    vector.X -= speed.X;
            }

            if (vector.Y <= window.ClientBounds.Height - texture.Height && vector.Y >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.S))
                    vector.Y += speed.Y;
                if (keyboardState.IsKeyDown(Keys.W))
                    vector.Y -= speed.Y;

            }
            ///

            if (vector.X < 0)
                vector.X = 0;

            if (vector.X > window.ClientBounds.Width - texture.Width)
                vector.X = window.ClientBounds.Width - texture.Width;

            if (vector.Y < 0)
                vector.Y = 0;
            
            if (vector.Y > window.ClientBounds.Height - texture.Height)
                vector.Y = window.ClientBounds.Height - texture.Height;

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, vector, Color.White);

        }
    }
}
