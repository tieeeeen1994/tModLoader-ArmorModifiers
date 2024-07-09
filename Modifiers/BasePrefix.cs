using Terraria;
using Terraria.ModLoader;
using static ArmorModifiers.ArmorModifiers;

namespace ArmorModifiers.Modifiers
{
    public abstract class BasePrefix : ModPrefix
    {
        protected abstract string PrefixName { get; }

        public override PrefixCategory Category => PrefixCategory.Custom;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault(PrefixName);
            armorPrefixes.Add(Type);
        }

        public override bool CanRoll(Item item) => IsArmorPiece(item);

        public override float RollChance(Item item) => 1f;
    }
}
