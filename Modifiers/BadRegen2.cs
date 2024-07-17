using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class BadRegen2 : Negative2Prefix
    {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.regenToggle;

        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraRegen -= ServerConfig.regenIncrease;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"-{ServerConfig.regenIncrease} life regeneration", true);
        }
    }
}
