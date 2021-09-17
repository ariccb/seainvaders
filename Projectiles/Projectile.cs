using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    abstract class Projectile : Entity
    {
        public Bitmap[] sprites = new Bitmap[4]; //means the array is 4 units long
        public abstract char[][,] graphics { get; } //abstract means it's going to be declared on a class somewhere down the line, and that there will be a get function somewhere down the line
        public int SpriteFrame = 0;
        public int FrameCount = 0;

        public Projectile(int x , int y) : base()
        {
            this.x = x;
            this.y = y;
            y = 0;
            sprite = new Bitmap(1, 4);

            for (int i = 0; i < 4; i++)
            {
                sprites[i] = CharArrayToBitmap(graphics[i]);
            }
            sprite = sprites[SpriteFrame];
        }
        public override void Update()
        {
            if (y > 223)
            {
                Delete();
            }
            else
            {
                for (int i = 0; i < Game.EntityList.Count; i++)
                {
                    Entity entity = Game.EntityList[i];
                    if (entity is Player)
                    {
                        if (x <= (entity.x + entity.width) && x >= entity.x && y <= entity.y && y >= (entity.y - entity.height))
                        {
                            ((Player)entity).Hit(); // static casting needs to be enclosed in brackets to be treated as a single thing
                            Delete();
                        }
                    }
                    else if (entity is Shield)
                    {
                        if (IsColliding(entity))
                        {
                            int[] location = ((Shield)entity).FindIntersect(this); //looking for a single [x] 
                            if (location[0] != -1) //if the array location doens't equal -1 (would be above the window extents). 
                            {
                                ProjectileExplosion explosion = new ProjectileExplosion(x - 4, y + 3);
                                ((Shield)entity).Damage(explosion);
                                Delete();
                            }
                        }
                    }
                }
            }
            if(FrameCount % 3 == 2) //0%3 = 0, 1%3 = 1, 2%3 = 2, 3%3 = 0, 4%3 = 1, 5%3 = 2
            {
                SpriteFrame = ++SpriteFrame%4;
                sprite = sprites[SpriteFrame];
                y += 2;
            }
            FrameCount++;
        }
    }
}
