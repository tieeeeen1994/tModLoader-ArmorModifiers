using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class BadMinions2 : Negative2Prefix
    {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.minionToggle;

        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraMinions -= ServerConfig.minionIncrease;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"-{ServerConfig.minionIncrease} minion slot", true);
        }
    }
}
