using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoPong
{
    public class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture { get; set; }
        public Rectangle Bounds
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); }
        }


        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public virtual void Move(Vector2 amount)
        {
            Position += amount;
        }

        public static bool CheckPaddleBallCollision(Player player, Ball ball)
        {
            if (player.Bounds.Intersects(ball.Bounds))
                return true;

            return false;
        }
    }
}
