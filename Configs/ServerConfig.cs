using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorModifiers.Configs
{
    public class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Base Cost Armor Reforging Multiplier")]
        [Tooltip("The reforge cost to be multiplied for Armor.")]
        [DefaultValue(10f)]
        [Range(1f, 100f)]
        [Increment(1)]
        public float reforgeCostMultiplier;

        [Label("Minion Slot Modifier Bonus")]
        [Tooltip("The bonus given by the modifier. Negative modifier counterpart is inversed from this value.\n" +
                 "The total final value from the modifiers are rounded off.\ne.g. 1.8 total bonus results in a +2 bonus slots.")]
        [DefaultValue(1f)]
        [Range(.01f, 10f)]
        [Increment(.01f)]
        public float minionIncrease;

        [Label("Health Modifier Bonus")]
        [Tooltip("The bonus given by the modifier. Negative modifier counterpart is inversed from this value.")]
        [DefaultValue(20)]
        [Range(1, 100)]
        [Increment(.01f)]
        public int healthIncrease;

        [Label("Critical Damage Modifier Bonus")]
        [Tooltip("The bonus given by the modifier. Negative modifier counterpart is inversed from this value.\n" +
                 "The Tier 2 modifier will get double the value of this.")]
        [DefaultValue(.2f)]
        [Range(.01f, 1f)]
        [Increment(.01f)]
        public float critIncrease;

        [Label("Health Regeneration Modifier Bonus")]
        [Tooltip("The bonus given by the modifier. Negative modifier counterpart is inversed from this value.\n" +
                 "The total final value from the modifiers are rounded off.\ne.g. 0.6 total bonus results in a +1 bonus regen.")]
        [DefaultValue(1f)]
        [Range(.01f, 10f)]
        [Increment(.01f)]
        public float regenIncrease;

        [Label("Attack Speed Modifier Bonus")]
        [Tooltip("The bonus given by the modifier. Negative modifier counterpart is inversed from this value.\n" +
                 "The Tier 2 modifier will get double the value of this.")]
        [DefaultValue(.02f)]
        [Range(.01f, 1f)]
        [Increment(.01f)]
        public float attackSpeedIncrease;
    }
}
