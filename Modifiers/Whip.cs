using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class Whip : PositivePrefix
    {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.whipRangeToggle;

        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraWhipRange += ServerConfig.whipRangeIncrease * 2;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"+{ServerConfig.whipRangeIncrease * 100 * 2}% whip range", false);
        }
    }
}
