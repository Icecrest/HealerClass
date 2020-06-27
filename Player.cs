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
        private Item[] equipArmor = Main.player[Main.myPlayer].armor;


        public float PlayerHasArmourEquippedOfType(int pieceType)
        {
            for (int i = 0; i < 3; i++)
            {
                Item item = equipArmor[i];
                if (item != null && !item.IsAir && item.type == pieceType)
                {
                    return 0.5f;
                }
            }
            return 0f;
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            testString.Append("Hit! ");
            testString.Append("\n Damage: " + damage.ToString());

            // Trouble Code:  && PlayerHasArmourEquippedOfType(ArmorIDs.Body.NebulaBreastplate) == 0.5f
            if (proj.magic == true)
            {
                healMod = 0.5f;

                healValue = (int)Math.Floor((float)damage * healMod);

                Healing.VampireHeal(damage, target.position);
                Main.player[Main.myPlayer].statLife += healValue;
                Main.player[Main.myPlayer].HealEffect(healValue);
                testString.Append(" Healing: " + ((float)damage * healMod).ToString() + " Actual: " + healValue.ToString());
            }

            

            Main.NewTextMultiline(testString.ToString(), true, Microsoft.Xna.Framework.Color.DarkCyan);
            testString.Clear();
        }

    }
}
