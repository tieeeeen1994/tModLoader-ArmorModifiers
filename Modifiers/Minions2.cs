using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class Minions2 : Positive2Prefix
    {
        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraMinions += ServerConfig.minionIncrease;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"+{ServerConfig.minionIncrease} minion slot", false);
        }
    }
}
