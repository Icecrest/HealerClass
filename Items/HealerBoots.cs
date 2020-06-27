using IL.Terraria;
using IL.Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace HealerClass.Items
{
    [AutoloadEquip(EquipType.Legs)]
    class HealerBoots : ModItem
    {
       
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Boots are Modded\nIts a Baby!");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.maxStack = 1;
            item.value = 100;
            item.rare = -13;
        }

        public override void UpdateEquip(Terraria.Player player)
        {
            player.AddBuff(BuffID.BabyGrinch, -1);
            player.UpdatePet(ProjectileID.BabyGrinch);
        }

        public override void AddRecipes()
            {
                ModRecipe recipeIron = new ModRecipe(mod);
                recipeIron.AddIngredient(ItemID.MeteoriteBar, 15);
                recipeIron.AddIngredient(ItemID.Silk, 10);
                recipeIron.AddIngredient(ItemID.IronBar, 10);
                recipeIron.AddTile(TileID.Anvils);
                recipeIron.SetResult(this);

                ModRecipe recipeLead = new ModRecipe(mod);
                recipeLead.AddIngredient(ItemID.MeteoriteBar, 15);
                recipeLead.AddIngredient(ItemID.Silk, 10);
                recipeLead.AddIngredient(ItemID.LeadBar, 10);
                recipeLead.AddTile(TileID.Anvils);
                recipeLead.SetResult(this);
            }


    }
}
