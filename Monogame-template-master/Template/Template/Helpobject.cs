using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template {

    /**
    * Samma rörelser som fienden men om spelaren träffar denna får spelaren extra "blocka" att stå på och överleva längre (träffar den marken händer inget)
    **/

    class Helpobject : ObjectBase {

        Random r = new Random();
        Player player;
        Map map;

        int mapX, mapY; // temp

        int[,] maparray;


        public Helpobject(Player player, Map map) {
            this.player = player;
            this.map = map;

            color = Color.Green;

            angle = r.Next(0, 361);

            direction = CalcDir(angle, player);
        }

        public override void Update() {

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);

            pos -= direction * speed;

            Colission();
        }

        private void Colission() {

            //om skottet träffar spelaren lägg till en ruta med block
            if (rectangle.Intersects(player.Rec)) {
                dead = true;

                maparray = map.MapArray;

                for (int y = -3; y != 3; y++) {
                    for (int x = -3; x != 3; x++) {
                        mapX = ((int)pos.X / 10) + x;
                        mapY = ((int)pos.Y / 10) + y;


                        
                        if (mapX < 0) { mapX = 0; }
                        if (mapX > 79) { mapX = 79; }
                        if (mapY > 49) { mapY = 49; }
                        if (mapY < 0) { mapY = 0; }

                        //ändra arrayen
                        maparray[mapY, mapX] = 1;

                        map.Generate(maparray, 10, true);
                    }
                }
            }

            foreach (ColisionTiles tile in map.ColisionTiles) {
                if (rectangle.Intersects(tile.Rectangle)) {

                    dead = true;

                }
            }

        }



    }
}
