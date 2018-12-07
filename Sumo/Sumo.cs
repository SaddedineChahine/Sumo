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
    class Sumo
    {
        Texture2D texture;
        Vector2 vector;
        Vector2 speed;
        protected float angle = 0;
        bool accelerate;
        Vector2 ship_speed = new Vector2();
        const float ship_acc = 0.1f;
        const float ship_max_speed = 4;

        public Sumo(Texture2D texture, float X, float Y, float speedX, float speedY)
        {
            this.texture = texture;
            this.vector.X = X;
            this.vector.Y = Y;
            this.speed.X = speedX;
            this.speed.Y = speedY;


        }

        public void Update(GameWindow window)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (vector.X <= window.ClientBounds.Width - texture.Width && vector.X >= 0)
                {
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    accelerate = true;
                    ship_speed.X += ship_acc * (float)Math.Cos(angle);
                    
                    if (ship_speed.Length() > ship_max_speed)
                    {
                        ship_speed.Normalize();
                        ship_speed *= ship_max_speed;
                    }
                    vector.X += speed.X;
                    angle = 1;
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    accelerate = true;
                    ship_speed.X -= ship_acc * (float)Math.Cos(angle);
                    
                    if (ship_speed.Length() > ship_max_speed)
                    {
                        ship_speed.Normalize();
                        ship_speed *= ship_max_speed;
                    }
                    angle = 180;
                    vector.X -= speed.X;
                }
                }

            if (vector.Y <= window.ClientBounds.Height - texture.Height && vector.Y >= 0)
                {
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    accelerate = true;
                    
                    ship_speed.Y += ship_acc * (float)Math.Sin(angle);
                    if (ship_speed.Length() > ship_max_speed)
                    {
                        ship_speed.Normalize();
                        ship_speed *= ship_max_speed;
                    }
                    angle = 90;
                    vector.Y += speed.Y;
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    accelerate = true;
                    
                    ship_speed.Y -= ship_acc * (float)Math.Sin(angle);
                    if (ship_speed.Length() > ship_max_speed)
                    {
                        ship_speed.Normalize();
                        ship_speed *= ship_max_speed;
                    }
                    vector.Y -= speed.Y;
                    angle = 270;
                }

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
            

            spriteBatch.Draw(texture, vector, null, Color.White, angle + (float)Math.PI / 2,
       new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, 0);

        }
    }
}
