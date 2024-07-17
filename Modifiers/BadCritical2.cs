using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public class BadCritical2 : Negative2Prefix
    {
        public override bool IsLoadingEnabled(Mod mod) => ServerConfig.critToggle;

        public override void UpdateEquip(Item item, Player player)
        {
            ModArmorPlayer(player).extraCritDamage -= ServerConfig.critIncrease;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            InsertTooltips(tooltips, $"-{ServerConfig.critIncrease * 100}% critical effectiveness", true);
        }
    }
}
