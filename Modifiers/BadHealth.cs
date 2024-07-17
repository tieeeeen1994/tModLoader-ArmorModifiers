using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class BadHealth : NegativePrefix
    {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.healthToggle;

        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraLife -= ServerConfig.healthIncrease * 2;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"-{ServerConfig.healthIncrease * 2} max life", true);
        }
    }
}
