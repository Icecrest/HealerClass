using HealerClass.Items;
using HealerClass.Projectiles;
using Terraria;
using Terraria.ModLoader;

namespace HealerClass
{
    class Player : ModPlayer
    {

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if(player.armor[2].legSlot.Equals(ModContent.ItemType<HealerBoots>()))
            {
                Projectile.NewProjectile(target.position.X, target.position.Y, 0f, 0f, ModContent.ProjectileType<Healing>(), 255, 255, damage);
            }
        }

    }
}
