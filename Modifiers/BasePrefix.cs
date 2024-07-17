using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public abstract class BasePrefix : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Custom;

        public override void SetStaticDefaults()
        {
            armorPrefixes.Add(Type);
        }

        public override bool CanRoll(Item item) => IsArmorPiece(item);

        public override float RollChance(Item item) => 1f;

        public virtual void UpdateEquip(Item item, Player player) => throw new NotImplementedException();

        public virtual void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            throw new NotImplementedException();
        }

        protected void InsertTooltips(List<TooltipLine> tooltips, string tooltip, bool isBad)
        {
            int index = tooltips.FindLastIndex(TooltipCheck);
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

        private bool TooltipCheck(TooltipLine tt) => (tt.Mod.Equals("Terraria") || tt.Mod.Equals(Mod.Name)) &&
                                                     (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") ||
                                                      tt.Name.Equals("Defense") || tt.Name.Equals("Equipable"));
    }
}
