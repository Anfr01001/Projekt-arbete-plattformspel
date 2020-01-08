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

    /**
    * Detta är spelets fiende och när den träffar marken förstörs marken och om spelaren skulle bli träffan blir spelaren knuffad 
    **/
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

            direction = CalcDir(angle, player);


        }

        public override void Update() {
            
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
                            if (mapY < 0) { mapY = 0; }

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
