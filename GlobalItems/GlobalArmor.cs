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
            if (!IsArmorPiece(item)) return;

            if (item.prefix == ModContent.PrefixType<Minions>()) ModArmorPlayer(player).extraMinions += minionIncrease;
            if (item.prefix == ModContent.PrefixType<BadMinions>()) ModArmorPlayer(player).extraMinions -= minionIncrease;
            if (item.prefix == ModContent.PrefixType<Health>()) ModArmorPlayer(player).extraLife += healthIncrease;
            if (item.prefix == ModContent.PrefixType<BadHealth>()) ModArmorPlayer(player).extraLife -= healthIncrease;
            if (item.prefix == ModContent.PrefixType<Critical>()) ModArmorPlayer(player).extraCritDamage += critIncrease * 2;
            if (item.prefix == ModContent.PrefixType<BadCritical>()) ModArmorPlayer(player).extraCritDamage -= critIncrease * 2;
            if (item.prefix == ModContent.PrefixType<Regen>()) ModArmorPlayer(player).extraRegen += regenIncrease;
            if (item.prefix == ModContent.PrefixType<BadRegen>()) ModArmorPlayer(player).extraRegen -= regenIncrease;
            if (item.prefix == ModContent.PrefixType<AttackSpeed>()) ModArmorPlayer(player).extraAttackSpeed += attackSpeedIncrease * 2;
            if (item.prefix == ModContent.PrefixType<BadAttackSpeed>()) ModArmorPlayer(player).extraAttackSpeed -= attackSpeedIncrease * 2;
            if (item.prefix == ModContent.PrefixType<AttackSpeed2>()) ModArmorPlayer(player).extraAttackSpeed += attackSpeedIncrease;
            if (item.prefix == ModContent.PrefixType<BadAttackSpeed2>()) ModArmorPlayer(player).extraAttackSpeed -= attackSpeedIncrease;
            if (item.prefix == ModContent.PrefixType<Critical2>()) ModArmorPlayer(player).extraCritDamage += critIncrease;
            if (item.prefix == ModContent.PrefixType<BadCritical2>()) ModArmorPlayer(player).extraCritDamage -= critIncrease;

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

            return ChoosePrefix(item, rand);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!IsArmorPiece(item)) return;

            InsertPrefixTooltips<Minions>(item, tooltips, $"+{minionIncrease} minion slot");
            InsertPrefixTooltips<Health>(item, tooltips, $"+{healthIncrease} max life");
            InsertPrefixTooltips<Critical>(item, tooltips, $"+{critIncrease * 2 * 100}% critical effectiveness");
            InsertPrefixTooltips<Regen>(item, tooltips, $"+{regenIncrease} life regeneration");
            InsertPrefixTooltips<BadHealth>(item, tooltips, $"-{healthIncrease} max life");
            InsertPrefixTooltips<BadCritical>(item, tooltips, $"-{critIncrease * 2 * 100}% critical effectiveness");
            InsertPrefixTooltips<BadMinions>(item, tooltips, $"-{minionIncrease} minion slot");
            InsertPrefixTooltips<BadRegen>(item, tooltips, $"-{regenIncrease} life regeneration");
            InsertPrefixTooltips<AttackSpeed>(item, tooltips, $"+{attackSpeedIncrease * 2 * 100}% attack speed");
            InsertPrefixTooltips<BadAttackSpeed>(item, tooltips, $"-{attackSpeedIncrease * 2 * 100}% attack speed");
            InsertPrefixTooltips<Critical2>(item, tooltips, $"+{critIncrease * 100}% critical effectiveness");
            InsertPrefixTooltips<BadCritical2>(item, tooltips, $"-{critIncrease * 100}% critical effectiveness");
            InsertPrefixTooltips<AttackSpeed2>(item, tooltips, $"+{attackSpeedIncrease * 100}% attack speed");
            InsertPrefixTooltips<BadAttackSpeed2>(item, tooltips, $"-{attackSpeedIncrease * 100}% attack speed");
        }

        private bool TooltipCheck(TooltipLine tt) => (tt.Mod.Equals("Terraria") || tt.Mod.Equals(Mod.Name)) &&
                                                     (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable"));

        private void InsertPrefixTooltips<T>(Item item, List<TooltipLine> tooltips, string tooltip, bool isBad = false) where T : ModPrefix
        {
            if (item.prefix == ModContent.PrefixType<T>())
            {
                int index = tooltips.FindLastIndex(tt => TooltipCheck(tt));
                if (index != -1)
                {
                    TooltipLine ttl = new TooltipLine(Mod, "ArmorPrefixTooltip", tooltip);

                    if (isBad) ttl.IsModifierBad = true;
                    else ttl.IsModifier = true;

                    tooltips.Insert(index + 1, ttl);
                }
            }
        }
    }
}
