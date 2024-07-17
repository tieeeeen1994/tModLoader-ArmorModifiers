using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class Regen : PositivePrefix
    {
        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraRegen += ServerConfig.regenIncrease * 2;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"+{ServerConfig.regenIncrease * 2} life regeneration", false);
        }
    }
}
