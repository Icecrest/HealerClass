using Terraria.ModLoader;
using Terraria;
using IL.Terraria.ID;

namespace HealerClass.Projectiles
{
    class Healing : ModProjectile
    {

        public override void SetDefaults()
        {
            projectile.CloneDefaults(305);
            aiType = 298;
        }

    }
}
