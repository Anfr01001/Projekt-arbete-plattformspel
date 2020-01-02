using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template {
    class Fiende : ObjectBase {
        Random r = new Random();
        Player player;
        Map map;

        int mapX, mapY; // temp

        int[,] maparray;

        public Fiende(Player player, Map map) {
            this.player = player;
            this.map = map;


            angle = r.Next(0, 361);

            // Ta reda på vad X respektive Y måste vara för att denna vinklen ska skapas och radien på cirklen ska vara 700
            x = 0 + Math.Cos(angle) * radie;
            y = 0 + Math.Sin(angle) * radie;
            pos = new Vector2((float)x, (float)y); // gör om det till vector för att kunna användas

            // Ställer in rotation mot spelaren och sedan gör om det till direction som sedan används för att uppdatera postionen i Update
            Rotation = (float)Math.Atan2(pos.Y - player.Pos.Y, pos.X - player.Pos.X); // minus player pos
            direction = new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));


        }

        public void Update() {
            
           rectangle = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);

           pos -= direction * speed; 

           Colission();
        }

        private void Colission() {

            //om skottet träffar spelaren "putta" honnom
            if (rectangle.Intersects(player.Rec)) {
                player.pushPlayer(direction);
                dead = true;
            }

            foreach (ColisionTiles tile in map.ColisionTiles) {
                if (rectangle.Intersects(tile.Rectangle)) {
                    dead = true;

                    maparray = map.MapArray;

                    for (int y = -3; y != 3; y++) {
                        for (int x = -3; x != 3; x++) {
                            mapX = ((int)pos.X / 10) + x;
                            mapY = ((int)pos.Y / 10) + y;


                            //kolla så att vi inte försöker spränga utanför mappen
                            if (mapX < 0) { mapX = 0; }
                            if (mapX > 79) { mapX = 79; }
                            if (mapY > 49) { mapY = 49; }
                            
                            //ändra arrayen
                            maparray[mapY, mapX] = 0;

                            map.Generate(maparray, 10, true);
                        }
                    }

                    break;

                }
            }

        }


    }
}
