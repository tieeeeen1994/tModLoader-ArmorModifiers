using System;
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

        public static Action<Item, Player> lol;
    }
}
