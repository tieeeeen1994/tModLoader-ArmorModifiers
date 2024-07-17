using ArmorModifiers.Modifiers;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.GlobalItems
{
    public class GlobalArmor : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return IsArmorPiece(entity);
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (IsArmorPiece(item))
            {
                ItemPrefix(item).UpdateEquip(item, player);
            }
        }

        public override bool ReforgePrice(Item item, ref int reforgePrice, ref bool canApplyDiscount)
        {
            if (IsArmorPiece(item))
            {
                reforgePrice = (int)MathF.Round(reforgePrice * ServerConfig.reforgeCostMultiplier, 0, MidpointRounding.ToEven);
                canApplyDiscount = true;
                return true;
            }

            return base.ReforgePrice(item, ref reforgePrice, ref canApplyDiscount);
        }

        public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
        {
            if (IsArmorPiece(item))
            {
                if (pre == -3) return true;
                else if (pre == -1) return false;
            }

            return base.PrefixChance(item, pre, rand);
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (IsArmorPiece(item)) return armorPrefixes[rand.Next(armorPrefixes.Count)];

            return base.ChoosePrefix(item, rand);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (IsArmorPiece(item))
            {
                ItemPrefix(item).ModifyTooltips(item, tooltips);
            }
        }

        private BasePrefix ItemPrefix(Item item) => (BasePrefix)PrefixLoader.GetPrefix(item.prefix);
    }
}
