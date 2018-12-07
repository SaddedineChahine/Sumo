using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumo
{
    class bakgrund
    {
        Texture2D texture;
        Vector2 vector;
        Vector2 speed;

        public bakgrund(Texture2D texture, float X, float Y)
        {
            this.texture = texture;
            vector = new Vector2(X - texture.Width/2, Y - texture.Height/2);
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, vector, Color.White);

        }
    }
}
