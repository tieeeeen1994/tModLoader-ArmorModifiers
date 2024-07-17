using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class Critical : PositivePrefix
    {
        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraCritDamage += ServerConfig.critIncrease * 2;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"+{ServerConfig.critIncrease * 2 * 100}% critical effectiveness", false);
        }
    }
}
