using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Template
{
    class Player
    {
        //Spelarens textur och position
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;

        public Player(Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(-20, 230);
        }

        public void Update()
        {

        }
        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
