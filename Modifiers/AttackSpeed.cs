using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class AttackSpeed : PositivePrefix
    {
        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraAttackSpeed += ServerConfig.attackSpeedIncrease * 2;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"+{ServerConfig.attackSpeedIncrease * 2 * 100}% attack speed", false);
        }
    }
}
