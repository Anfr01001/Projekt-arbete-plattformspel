using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template{
    abstract class ObjectBase {

        protected Vector2 pos = new Vector2();
        protected Vector2 velocity;
        protected Texture2D pixel = Assets.Pixel;
        protected Rectangle rectangle;
        protected Color color = Color.Red;
        protected bool dead = false;
        protected float Rotation;
        protected Vector2 direction;
        protected float speed = 1;
        protected double x, y;
        protected int angle;
        protected int radie = 700;

        public bool Dead {
            get { return dead; }
            set { dead = value; }
        }

        public Vector2 Pos {
            get { return pos; }
            set { pos = value; }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Pixel, rectangle, color);
        }

    }
}
