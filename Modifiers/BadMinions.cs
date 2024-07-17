using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class BadMinions : NegativePrefix
    {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.minionToggle;

        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraMinions -= ServerConfig.minionIncrease * 2;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"-{ServerConfig.minionIncrease * 2} minion slot", true);
        }
    }
}
