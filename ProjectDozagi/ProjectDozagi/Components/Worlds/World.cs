using Microsoft.Xna.Framework;
using ProjectDozagi.Components.Objects;
using ProjectDozagi.Components.Players;
using ProjectDozagi.Components.Worlds;
using ProjectDozagi.Engine.Cores.Sprites;
using System.Collections.Generic;

namespace ProjectDozagi.Components.World
{
    public class World
    {
        public Hero Hero { get; set; }
        
        public Ground Ground { get; set; }

        public List<Projectile> Projectiles { get; set; }

        public World()
        {
            Hero = new Hero("Sprites\\Character_Idle_01", new Vector2(300, 300), new Vector2(96, 96), new Rectangle(300, 300, 96, 96));
            Projectiles = new List<Projectile>();

            GameGlobal.PassProjectiles = AddProjectiles;
        }

        public virtual void AddProjectiles(object obj)
        {
            Projectiles.Add((Projectile)obj);
        }

        public virtual void Update()
        {

            Hero.Update();

            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Update(Vector2.Zero);

                if (Projectiles[i].IsDone)
                {
                    Projectiles.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void Draw(Vector2 offset = default)
        {
            Hero.Draw(offset);

            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Draw(Vector2.Zero);
            }
        }
    }
}
