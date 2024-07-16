using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ArmorModifiers.Configs
{
    public class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(10f)]
        [Range(1f, 100f)]
        [Increment(1)]
        public float reforgeCostMultiplier;

        [DefaultValue(1f)]
        [Range(.01f, 10f)]
        [Increment(.01f)]
        public float minionIncrease;

        [DefaultValue(20)]
        [Range(1, 100)]
        [Increment(1)]
        public int healthIncrease;

        [DefaultValue(.2f)]
        [Range(.01f, 1f)]
        [Increment(.01f)]
        public float critIncrease;

        [DefaultValue(1f)]
        [Range(.01f, 10f)]
        [Increment(.01f)]
        public float regenIncrease;

        [DefaultValue(.02f)]
        [Range(.01f, 1f)]
        [Increment(.01f)]
        public float attackSpeedIncrease;

        [DefaultValue(.05f)]
        [Range(.01f, 1f)]
        [Increment(.01f)]
        public float whipRangeIncrease;
    }
}
