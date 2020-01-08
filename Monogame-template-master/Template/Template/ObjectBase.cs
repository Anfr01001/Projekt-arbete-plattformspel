using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template{

    /**
     * Object base är basklassen för alla rörande föremål förutom spelaren (allt som i spelet flyget mot spelaren gott som ont
    **/

    abstract class ObjectBase {

        protected Vector2 pos = new Vector2();
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

        protected Vector2 CalcDir(int angel, Player player) {
            // Ta reda på vad X respektive Y måste vara för att denna vinklen ska skapas och radien på cirklen ska vara 700
            x = 0 + Math.Cos(angle) * radie;
            y = 0 + Math.Sin(angle) * radie;
            pos = new Vector2((float)x, (float)y); // gör om det till vector för att kunna användas

            // Ställer in rotation mot spelaren och sedan gör om det till direction som sedan används för att uppdatera postionen i Update
            Rotation = (float)Math.Atan2(pos.Y - player.Pos.Y, pos.X - player.Pos.X); // minus player pos
            direction = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));

            return direction;

        }

        public virtual void Update() {
        }

        public bool Dead {
            get { return dead; }
            //set { dead = value; }
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
