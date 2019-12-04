using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Template
{
    class Player
    {
        //Spelarens textur och position
        private Texture2D texture;
        private Rectangle rec = new Rectangle(10,-70,20,40); //x,y,size,size
        private Vector2 pos;

        private Rectangle testrec = new Rectangle(10,-70,20,40);
        private bool CanMove = true;
        private bool CanMoveX = true;
        private bool CanJump = true;

        private List<Rectangle> tempLista = new List<Rectangle>();

        public Rectangle Rec {
            get { return rec; }
        }

        private Vector2 velocity;
        private KeyboardState kState;

        public Player(Texture2D texture)
        {
            this.texture = texture;
           
        }

        
        private void move(Map map) {
            /*
             *  Testar Flytta en osynlig kub till platsen spelaren ska till kolla om den koliderar med något om inte flytta spelaren dit 
             */


            // Testrektanglen till samma plats som spelaren
            testrec.X = rec.X;
            testrec.Y = rec.Y;

            //input från spelaren flyttar den osynliga kuben
            kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.A)) {
                testrec.X -= 2;
            }
            if (kState.IsKeyDown(Keys.D)) {
                testrec.X += 2;
            }

            //Hoppa med space eller W 
            if ((kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.Space)) && CanJump) {
                testrec.Y -= 10; // Komma från marken (så den inte är "fast")      
                  velocity.Y = -10;
                CanJump = false;
            }
                

            //"gavitation"
            if (velocity.Y < 3)
                velocity.Y += 1;

            //kolla kolission
            CanMove = true;
            foreach (ColisionTiles tile in map.ColisionTiles) {
                if (testrec.Intersects(tile.Rectangle)) {
                    tempLista.Add(tile.Rectangle);
                    velocity.Y = 0;
                    CanMove = false;
                }
            }

            //Kolla om kolitionen sker underifrån i så fall ska man kunna gå
            CanMoveX = true;
            foreach (Rectangle tile in tempLista) {
                if (tile.Y - testrec.Y < 30)
                    CanMoveX = false;
            }

            tempLista.Clear();

            pos = new Vector2(testrec.X, testrec.Y);
            pos += velocity;


            if (CanMove) {
                rec.X = (int)pos.X;
                rec.Y = (int)pos.Y;
            } else {
                CanJump = true;
                //Hoppa oberoende av CanMove
                if(rec.Y > (int)pos.Y)
                   rec.Y = (int)pos.Y;
            }

            if (CanMoveX)
               rec.X = (int)pos.X;


        }

        public void Update(Map map)
        {
            move(map);

        }
        public  void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rec, Color.Yellow);
            //spriteBatch.Draw(texture, testrec, Color.Black);
        }

    }
}
