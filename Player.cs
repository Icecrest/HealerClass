using HealerClass.Items;
using HealerClass.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Microsoft.Xna.Framework.Color;

namespace HealerClass
{
    class Player : ModPlayer
    {
        StringBuilder testString = new StringBuilder();

        private float healMod = 0f;
        private int healValue = 0;

        public bool PlayerHasArmourEquippedOfType(int pieceType, Projectile proj)
        {
            for (int i = 0; i < 3; i++)
            {
                Item item = Main.player[proj.owner].armor[i];
                if (item != null && !item.IsAir && item.type == pieceType)
                {
                    return true;
                }
            }
            return false;
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            Main.NewText(Main.player[proj.owner].armor[1]);
            Main.NewText(proj.magic);
            if (proj.magic == true && PlayerHasArmourEquippedOfType(2761, proj) == true)
            {
                healMod = 0.5f;

                healValue = (int)Math.Floor((float)damage * healMod);

                Healing.VampireHeal(damage, target.position);
                Main.player[proj.owner].statLife += healValue;
                Main.player[proj.owner].HealEffect(healValue);

                Main.NewText("Healing Should Have Triggered...");
            }
        }
    }
}
