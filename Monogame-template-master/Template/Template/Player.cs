using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace Template
{
    class Player
    {
        //Spelarens textur och position
        private Texture2D texture;
        private Rectangle rec = new Rectangle(10,10,10,10); //x,y,size,size

        public Rectangle Rec {
            get { return rec; }
        }

        private Vector2 velocity;
        private KeyboardState kState;

        public Player(Texture2D texture)
        {
            this.texture = texture;
           
        }

        public void move() {

            kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.A))
                rec.X -= 3;
            if (kState.IsKeyDown(Keys.D))
                rec.X += 3;
            //hoppa ?? knapp??
            if (kState.IsKeyDown(Keys.W))
                rec.Y -= 3;
            //temp ska falla nedåt 
            if (kState.IsKeyDown(Keys.S))
                rec.Y += 3;

        }

        public void Update()
        {
            move();
        }
        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rec, Color.White);
        }

    }
}
