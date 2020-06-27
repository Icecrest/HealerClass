using HealerClass.Items;
using HealerClass.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Microsoft.Xna.Framework.Color;

namespace HealerClass
{
    class Player : ModPlayer
    {

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            
            Projectile.NewProjectile(target.position.X, target.position.Y, 0f, 0f, ModContent.ProjectileType<Healing>(), 255, 255, damage);
            
            Main.NewText("Hit!", Color.DarkRed, true);
        }

    }
}
