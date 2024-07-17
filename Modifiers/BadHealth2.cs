using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class BadHealth2 : Negative2Prefix
    {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.healthToggle;

        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraLife -= ServerConfig.healthIncrease;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"-{ServerConfig.healthIncrease} max life", true);
        }
    }
}
