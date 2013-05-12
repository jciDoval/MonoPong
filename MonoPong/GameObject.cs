using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoPong
{
    public class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture { get; set; }



        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public virtual void Move(Vector2 amount)
        {
            Position += amount;
        }
    }
}
