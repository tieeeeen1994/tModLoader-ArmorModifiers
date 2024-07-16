using ArmorModifiers.Modifiers;
using Microsoft.Xna.Framework;
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

            if (item.prefix == ModContent.PrefixType<Minions>()) ModArmorPlayer(player).extraMinions += ServerConfig.minionIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<Minions2>()) ModArmorPlayer(player).extraMinions += ServerConfig.minionIncrease;
            else if (item.prefix == ModContent.PrefixType<BadMinions>()) ModArmorPlayer(player).extraMinions -= ServerConfig.minionIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<BadMinions2>()) ModArmorPlayer(player).extraMinions -= ServerConfig.minionIncrease;
            else if (item.prefix == ModContent.PrefixType<Health>()) ModArmorPlayer(player).extraLife += ServerConfig.healthIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<Health2>()) ModArmorPlayer(player).extraLife += ServerConfig.healthIncrease;
            else if (item.prefix == ModContent.PrefixType<BadHealth>()) ModArmorPlayer(player).extraLife -= ServerConfig.healthIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<BadHealth2>()) ModArmorPlayer(player).extraLife -= ServerConfig.healthIncrease;
            else if (item.prefix == ModContent.PrefixType<Critical>()) ModArmorPlayer(player).extraCritDamage += ServerConfig.critIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<BadCritical>()) ModArmorPlayer(player).extraCritDamage -= ServerConfig.critIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<Regen>()) ModArmorPlayer(player).extraRegen += ServerConfig.regenIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<Regen2>()) ModArmorPlayer(player).extraRegen += ServerConfig.regenIncrease;
            else if (item.prefix == ModContent.PrefixType<BadRegen>()) ModArmorPlayer(player).extraRegen -= ServerConfig.regenIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<BadRegen2>()) ModArmorPlayer(player).extraRegen -= ServerConfig.regenIncrease;
            else if (item.prefix == ModContent.PrefixType<AttackSpeed>()) ModArmorPlayer(player).extraAttackSpeed += ServerConfig.attackSpeedIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<BadAttackSpeed>()) ModArmorPlayer(player).extraAttackSpeed -= ServerConfig.attackSpeedIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<AttackSpeed2>()) ModArmorPlayer(player).extraAttackSpeed += ServerConfig.attackSpeedIncrease;
            else if (item.prefix == ModContent.PrefixType<BadAttackSpeed2>()) ModArmorPlayer(player).extraAttackSpeed -= ServerConfig.attackSpeedIncrease;
            else if (item.prefix == ModContent.PrefixType<Critical2>()) ModArmorPlayer(player).extraCritDamage += ServerConfig.critIncrease;
            else if (item.prefix == ModContent.PrefixType<BadCritical2>()) ModArmorPlayer(player).extraCritDamage -= ServerConfig.critIncrease;
            else if (item.prefix == ModContent.PrefixType<Whip>()) ModArmorPlayer(player).extraWhipRange += ServerConfig.whipRangeIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<Whip2>()) ModArmorPlayer(player).extraWhipRange += ServerConfig.whipRangeIncrease;
            else if (item.prefix == ModContent.PrefixType<BadWhip>()) ModArmorPlayer(player).extraWhipRange -= ServerConfig.whipRangeIncrease * 2;
            else if (item.prefix == ModContent.PrefixType<BadWhip2>()) ModArmorPlayer(player).extraWhipRange -= ServerConfig.whipRangeIncrease;
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
            if (!IsArmorPiece(item)) return;

            InsertPrefixTooltips<Minions>(item, tooltips, $"+{ServerConfig.minionIncrease * 2} minion slot", false);
            InsertPrefixTooltips<Minions2>(item, tooltips, $"+{ServerConfig.minionIncrease} minion slot", false);
            InsertPrefixTooltips<Health>(item, tooltips, $"+{ServerConfig.healthIncrease * 2} max life", false);
            InsertPrefixTooltips<Health2>(item, tooltips, $"+{ServerConfig.healthIncrease} max life", false);
            InsertPrefixTooltips<Critical>(item, tooltips, $"+{ServerConfig.critIncrease * 2 * 100}% critical effectiveness", false);
            InsertPrefixTooltips<Regen>(item, tooltips, $"+{ServerConfig.regenIncrease * 2} life regeneration", false);
            InsertPrefixTooltips<Regen2>(item, tooltips, $"+{ServerConfig.regenIncrease} life regeneration", false);
            InsertPrefixTooltips<BadHealth>(item, tooltips, $"-{ServerConfig.healthIncrease * 2} max life", true);
            InsertPrefixTooltips<BadHealth2>(item, tooltips, $"-{ServerConfig.healthIncrease} max life", true);
            InsertPrefixTooltips<BadCritical>(item, tooltips, $"-{ServerConfig.critIncrease * 2 * 100}% critical effectiveness", true);
            InsertPrefixTooltips<BadMinions>(item, tooltips, $"-{ServerConfig.minionIncrease * 2} minion slot", true);
            InsertPrefixTooltips<BadMinions2>(item, tooltips, $"-{ServerConfig.minionIncrease} minion slot", true);
            InsertPrefixTooltips<BadRegen>(item, tooltips, $"-{ServerConfig.regenIncrease * 2} life regeneration", true);
            InsertPrefixTooltips<BadRegen2>(item, tooltips, $"-{ServerConfig.regenIncrease} life regeneration", true);
            InsertPrefixTooltips<AttackSpeed>(item, tooltips, $"+{ServerConfig.attackSpeedIncrease * 2 * 100}% attack speed", false);
            InsertPrefixTooltips<BadAttackSpeed>(item, tooltips, $"-{ServerConfig.attackSpeedIncrease * 2 * 100}% attack speed", true);
            InsertPrefixTooltips<Critical2>(item, tooltips, $"+{ServerConfig.critIncrease * 100}% critical effectiveness", false);
            InsertPrefixTooltips<BadCritical2>(item, tooltips, $"-{ServerConfig.critIncrease * 100}% critical effectiveness", true);
            InsertPrefixTooltips<AttackSpeed2>(item, tooltips, $"+{ServerConfig.attackSpeedIncrease * 100}% attack speed", false);
            InsertPrefixTooltips<BadAttackSpeed2>(item, tooltips, $"-{ServerConfig.attackSpeedIncrease * 100}% attack speed", true);
            InsertPrefixTooltips<Whip>(item, tooltips, $"+{ServerConfig.whipRangeIncrease * 100 * 2}% whip range", false);
            InsertPrefixTooltips<Whip2>(item, tooltips, $"+{ServerConfig.whipRangeIncrease * 100}% whip range", false);
            InsertPrefixTooltips<BadWhip>(item, tooltips, $"-{ServerConfig.whipRangeIncrease * 100 * 2}% whip range", true);
            InsertPrefixTooltips<BadWhip2>(item, tooltips, $"-{ServerConfig.whipRangeIncrease * 100}% whip range", true);
        }

        private bool TooltipCheck(TooltipLine tt) => (tt.Mod.Equals("Terraria") || tt.Mod.Equals(Mod.Name)) &&
                                                     (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") ||
                                                      tt.Name.Equals("Defense") || tt.Name.Equals("Equipable"));

        private void InsertPrefixTooltips<T>(Item item, List<TooltipLine> tooltips, string tooltip, bool isBad) where T : ModPrefix
        {
            if (item.prefix == ModContent.PrefixType<T>())
            {
                int index = tooltips.FindLastIndex(tt => TooltipCheck(tt));
                if (index != -1)
                {
                    TooltipLine ttl = new TooltipLine(Mod, "ArmorPrefixTooltip", tooltip);

                    if (isBad)
                    {
                        ttl.IsModifierBad = true;
                        ttl.OverrideColor = new Color(255, 150, 150);
                    }
                    else ttl.IsModifier = true;

                    tooltips.Insert(index + 1, ttl);
                }
            }
        }
    }
}
