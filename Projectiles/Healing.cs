using Terraria.ModLoader;
using Terraria;
using IL.Terraria.ID;
using Microsoft.Xna.Framework;

namespace HealerClass.Projectiles
{
    class Healing : ModProjectile
    {
        private int dmg;
        private Vector2 targetPos = new Vector2();

        public Healing(int damage, Vector2 target)
        {
            dmg = damage;
            targetPos = target;
        }

        public void VampireHeal(int Damage, Vector2 Position)
        {
            float num = (float)dmg * 0.075f;
            if ((int)num != 0 && !(Main.player[Main.myPlayer].lifeSteal <= 0f))
            {
                Main.player[Main.myPlayer].lifeSteal -= num;
                int num2 = 255;
                NewProjectile(Position.X, Position.Y, 0f, 0f, 305, 0, 0f, 255, num2, num);
            }
        }

        public static int FindOldestProjectile()
        {
            int result = 1000;
            int num = 9999999;
            for (int i = 0; i < 1000; i++)
            {
                if (!Main.projectile[i].netImportant && Main.projectile[i].timeLeft < num)
                {
                    result = i;
                    num = Main.projectile[i].timeLeft;
                }
            }
            return result;
        }

        public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int num = 1000;
            for (int i = 0; i < 1000; i++)
            {
                if (!Main.projectile[i].active)
                {
                    num = i;
                    break;
                }
            }
            if (num == 1000)
            {
                num = FindOldestProjectile();
            }
            Projectile projectile = Main.projectile[num];
            projectile.SetDefaults(Type);
            projectile.position.X = X - (float)projectile.width * 0.5f;
            projectile.position.Y = Y - (float)projectile.height * 0.5f;
			projectile.owner = Owner;
			projectile.velocity.X = SpeedX;
			projectile.velocity.Y = SpeedY;
			projectile.damage = Damage;
			projectile.knockBack = KnockBack;
			projectile.identity = num;
			projectile.gfxOffY = 0f;
			projectile.stepSpeed = 1f;
			projectile.wet = Collision.WetCollision(projectile.position, projectile.width, projectile.height);
            if (projectile.ignoreWater) { projectile.wet = false; }

            return num;
        }

    }
}
