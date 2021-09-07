using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace seainvaders
{
    class Bullet : Entity
    {
        public Bullet() : base()
        {
            y = 0;
            sprite = new Bitmap(1,4);
            
            for(int i = 0; i < 4; i++)
            {
                sprite.SetPixel(0, i, Color.Wheat);
            }
        }
        public override void Update()
        {
            y -= 4;
            if (y < 0)
            {
                Delete();
            }
            else
            {
                for (int i = 0; i < Game.EntityList.Count; i++)
                {
                    Entity entity = Game.EntityList[i];
                    if (entity is Enemy)
                    {
                        if (x <= (entity.x + entity.width) && x >= entity.x && y <= entity.y && y >= (entity.y - entity.height))
                        {
                            ((Enemy) entity).Hit(); // static casting needs to be enclosed in brackets to be treated as a single thing
                            Delete();
                        }
                    }
                    else if( entity is Shield)
                    {
                        if (IsColliding(entity))
                        {
                            int[] location = ((Shield)entity).FindIntersect(this);
                            if (location[0] != -1)
                            {
                                BulletExplosion explosion = new BulletExplosion(x - 4, y - 2);
                                ((Shield)entity).Damage(explosion);
                                Delete();
                            }
                        }
                    }
                }
            }
        }
    }
}
